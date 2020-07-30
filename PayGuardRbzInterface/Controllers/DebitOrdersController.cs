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
    public class DebitOrdersController : Controller
    {

        private readonly ITimerDebitOrdersForwardingToRecipientBanks sTimerDebitOrdersForwardingToRecipientBanks;
        //start the service
        public DebitOrdersController(ITimerDebitOrdersForwardingToRecipientBanks sTimerDebitOrdersForwardingToRecipientBanks)
        {
            this.sTimerDebitOrdersForwardingToRecipientBanks = sTimerDebitOrdersForwardingToRecipientBanks;
        }


        private dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }



        /// <summary>
        /// gamuchira debit order from the client portal 
        /// create debit order instructions and store into db
        /// does not credit
        /// does not debit
        /// credit and debit is handled by the service that sends debit orders to the client/debitee bank
        /// </summary>
        /// <param name="debit_order"></param>
        /// <returns></returns>
        [HttpPost("UploadDebitOrder")]
        public async Task<JsonResult> UploadDebitOrder([FromBody] MDebitOrders debit_order)
        {
            try
            {
                //create debit instructions for each bankcode and store into db
                foreach (var item in debit_order.MDebitOrdersClients)
                {
                    var debit_instuction = new MAccountDebitInstructions();
                    debit_instuction.Date = DateTime.Now;
                    debit_instuction.ClientBankCode =item.ClientBankSwiftCode;
                    debit_instuction.ClientAccountNumber = item.ClientAccountNumber;
                    debit_instuction.SenderBankCode = debit_order.BankCode;//swift code
                    debit_instuction.SenderAccountNumber = debit_order.AccountNumber;
                    debit_instuction.Amount = item.ClientAmount;
                    debit_instuction.Reference = debit_order.Reference;
                    db.MAccountDebitInstructions.Add(debit_instuction);
                }
                await db.SaveChangesAsync();
                //
                return Json(new
                {
                    res = "ok",
                    data = "Debit Order Submitted"
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
        /// recieves processed debit orders from the debitee bank
        /// debits the debitee "bank" suspence account
        /// credits the debitors "bank" suspense account
        /// recieved debits are converted into payment instructions 
        /// a service will process the payment instructions
        /// processed_debit_orders are debit orders that have successfuly debited the "debitee/client" account at his/her bank
        /// and are sent back to rbz to debit/credit the suspense accounts respectively
        /// debit/credit the suspense accounts respectively
        /// </summary>
        /// <param name="debit_orders"></param>
        /// <returns></returns>
        [HttpPost("UploadProcessedDebitOrders")]
        public async Task<JsonResult> UploadProcessedDebitOrders([FromBody] List<MAccountDebitInstructionsProcessed> processed_debit_orders)
        {
            try
            {
                //create payment instructions for each bankcode and store into db
                //convert processed debit orders into payment instructions
                foreach (var item in processed_debit_orders)
                {
                    var payment_instuction = new MAccountCreditInstructions();
                    payment_instuction.Date = DateTime.Now;
                    payment_instuction.RecipientBankCode = item.SenderBankCode;//the original sender is now the reciver
                    payment_instuction.RecipientAccountNumber = item.SenderAccountNumber;//original sender is now the reciever
                    payment_instuction.SenderBankCode = item.ClientBankCode;//reciever is now the sender
                    payment_instuction.SenderAccountNumber = item.ClientAccountNumber;//reciever is now the sender
                    payment_instuction.Amount = item.Amount;
                    payment_instuction.Reference = item.Reference;
                    db.MAccountCreditInstructions.Add(payment_instuction);
                }
                await db.SaveChangesAsync();
                //since all payments are coming from the same bank(one bank) and are going to the same bank(one bank)...
                //...group total_amount,  debitee_bank_code, debitor_bank_code
                var total_amount = processed_debit_orders.Sum(i => i.Amount);
                var debitee_bank_code = processed_debit_orders.First().ClientBankCode;//the original client/recipient of the debit order is not the sender
                var debitor_bank_code = processed_debit_orders.First().SenderBankCode;//the original sender is now the benificiary
                //debit the debitee suspense "bank" account
                Globals.DebitSuspenseAccount(debitee_bank_code, total_amount);
                //credit the debitor suspense "bank" account
                Globals.CreditSuspenseAccount(debitor_bank_code, total_amount);
                return Json(new
                {
                    res = "ok",
                    data = "Processed Debit Order Submitted"
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
        /// <param name="bank_swift_code">the bank code where we are routing this request</param>
        /// <returns></returns>
        [HttpGet("ViewDebitOrderErrors")]
        public async Task<JsonResult> ViewDebitOrderErrors(string bank_swift_code, string sender_account)
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
                    .GetAsync($"{bank.EndPoint}/PayGuard/v1/ViewDebitOrderErrors?sender_account={sender_account}")
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
