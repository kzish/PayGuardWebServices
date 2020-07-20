using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayGuard.Models;
using PayGuardRbzInterface.Models;

namespace PayGuardRbzInterface.Controllers
{
    /// <summary>
    /// bank interface presents an unified interface for all the banks
    /// </summary>

    [Route("PayGuard/v1")]
    [Authorize(AuthenticationSchemes = "Bearer")]//allow only authorized by Bearer
    public class BankInterfaceController : Controller
    {
        private dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }


        /// <summary>
        /// debit the banks suspense account
        /// </summary>
        /// <param name="account_number"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private bool DebitSuspenseAccount(string suspense_account_number, decimal amount)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
                return false;
            }
        }

        /// <summary>
        /// credit the banks suspense account
        /// </summary>
        /// <param name="account_number"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private bool CreditSuspenseAccount(string suspense_account_number, decimal amount)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
                return false;
            }
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
                    payment_instruction.SenderAccountNumber = item.RecipientAccountNumber;
                    payment_instruction.Amount = item.RecipientAmount;
                    payment_instruction.Reference = bulk_payment.Reference;
                    db.MAccountCreditInstructions.Add(payment_instruction);
                }
                //
                await db.SaveChangesAsync();
                //debit the suspense account
                //transaction fee stays with the payers bank, it is not debited from the suspense account
                decimal total_recipient_amount = bulk_payment.MBulkPaymentsIncomingRecipients.Sum(i => i.RecipientAmount);
                DebitSuspenseAccount(bulk_payment.BankCode, total_recipient_amount);
                //credit each recipient bank
                var banks = db.MBank.ToList();
                foreach( var bank in banks)
                {
                    var total_amount_to_credit_for_this_bank = bulk_payment
                        .MBulkPaymentsIncomingRecipients
                        .Where(i => i.RecipientBankSwiftCode == bank.SwiftCode)
                        .Sum(i => i.RecipientAmount);
                    //
                    CreditSuspenseAccount(bank.SwiftCode, total_amount_to_credit_for_this_bank);
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


    }
}
