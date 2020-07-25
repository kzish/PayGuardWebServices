using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PayGuard.Models;
using PayGuardRbzInterface.Models;
using PayGuardRbzInterface.Services;

namespace PayGuardRbzInterface.Controllers
{
    /// <summary>
    /// bank interface presents an unified interface for all the banks
    /// </summary>

    [Route("PayGuard/v1")]
    [Authorize(AuthenticationSchemes = "Bearer")]//allow only authorized by Bearer
    public class BulkPayments : Controller
    {

        private readonly ITimerBulkPaymentsForwardingToRecipientBanks sTimerBulkPaymentsForwardingToRecipientBanks;
        //start the service
        public BulkPayments(ITimerBulkPaymentsForwardingToRecipientBanks sTimerBulkPaymentsForwardingToRecipientBanks)
        {
            this.sTimerBulkPaymentsForwardingToRecipientBanks = sTimerBulkPaymentsForwardingToRecipientBanks;
        }


        private dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }



        /// <summary>
        /// gamuchira bulk payment from the client bank 
        /// create payment instructions and store into db
        /// debits the senders suspense account for the total amount in the bulkpayment
        /// credits the recipient suspense account for the corresponding total amount in the bulkpayment
        /// </summary>
        /// <param name="bulk_payment"></param>
        /// <returns></returns>
        [HttpPost("UploadBulkPayment")]
        public async Task<JsonResult> UploadBulkPayment([FromBody] MBulkPaymentsIncoming bulk_payment)
        {
            try
            {
                //create payment instructions for each bankcode and store into db
                foreach (var item in bulk_payment.MBulkPaymentsIncomingRecipients)
                {
                    var payment_instruction = new MAccountCreditInstructions();
                    payment_instruction.Date = DateTime.Now;
                    payment_instruction.RecipientBankCode = item.RecipientBankSwiftCode;
                    payment_instruction.RecipientAccountNumber = item.RecipientAccountNumber;
                    payment_instruction.SenderBankCode = bulk_payment.BankCode;//swift code
                    payment_instruction.SenderAccountNumber = bulk_payment.AccountNumber;
                    payment_instruction.Amount = item.RecipientAmount;
                    payment_instruction.Reference = bulk_payment.Reference;
                    db.MAccountCreditInstructions.Add(payment_instruction);
                }
                //
                await db.SaveChangesAsync();
                //debit the suspense account
                //transaction fee stays with the payers bank, it is not debited from the suspense account
                decimal total_recipient_amount = bulk_payment.MBulkPaymentsIncomingRecipients.Sum(i => i.RecipientAmount);
                Globals.DebitSuspenseAccount(bulk_payment.BankCode, total_recipient_amount);
                //credit each recipient bank
                var banks = db.MBank.ToList();
                foreach (var bank in banks)
                {
                    var total_amount_to_credit_for_this_bank = bulk_payment
                        .MBulkPaymentsIncomingRecipients
                        .Where(i => i.RecipientBankSwiftCode == bank.SwiftCode)
                        .Sum(i => i.RecipientAmount);
                    //
                    Globals.CreditSuspenseAccount(bank.SwiftCode, total_amount_to_credit_for_this_bank);
                }
                //
                return Json(new
                {
                    res = "ok",
                    data = "Bulk Payment Submitted"
                });
            }
            catch (Exception ex)
            {
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }



        /// <summary>
        /// view the errors 
        /// bulk payments errors
        /// route the request to the specified bank
        /// </summary>
        /// <param name="sender_account">the account of the sender</param>
        /// <returns></returns>
        [HttpGet("ViewBulkPaymentErrors")]
        public async Task<JsonResult> ViewBulkPaymentErrors(string bank_swift_code, string sender_account)
        {
            try
            {

                var bank = db.MBank
                    .Where(i => i.SwiftCode == bank_swift_code)//the selected bank
                    .FirstOrDefault();

                var http_client = new HttpClient(Globals.GetHttpHandler());
                var access_token = Globals.GetAccessToken(bank.EndPoint);
                if (string.IsNullOrEmpty(access_token))
                {
                    return Json(new
                    {
                        res = "err",
                        msg = "failed to get accesss token"
                    });
                }

                http_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");
                var request_errors = await http_client
                    .GetAsync($"{bank.EndPoint}/PayGuard/v1/ViewBulkPaymentErrors?sender_account={sender_account}")
                    .Result
                    .Content
                    .ReadAsStringAsync()
                    ;

                dynamic request_errors_json = JsonConvert.DeserializeObject(request_errors);
                if (request_errors_json.res == "ok")
                {
                    return Json(new
                    {
                        res = "ok",
                        data = request_errors_json.data
                    });
                }
                else
                {
                    return Json(new
                    {
                        res = "err",
                        msg = request_errors
                    });
                }


            }
            catch (Exception ex)
            {
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }

    }
}
