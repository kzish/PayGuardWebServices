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
        /// gamuchira bulk payment from the client bank 
        /// save bulk payment into the db
        /// accepts MBulkPayments type and converts into MBulkPaymentsIncoming
        /// debits the suspense account
        /// </summary>
        /// <param name="bulk_payment"></param>
        /// <returns></returns>
        [HttpPost("UploadBulkPayment")]
        public async Task<JsonResult> UploadBulkPayment([FromBody] MBulkPaymentsIncoming bulk_payment)
        {
            try
            {
                //transaction fee stays with the payers bank, it is not debited from the suspense account
                decimal total_recipient_amount = bulk_payment.MBulkPaymentsIncomingRecipients.Sum(i => i.RecipientAmount);
                //create new bulkPayment object, copy values, add bulk payment into db
                var m_bulk_payments_incoming = new MBulkPaymentsIncoming();
                m_bulk_payments_incoming.IdAtClient = bulk_payment.IdAtClient;
                m_bulk_payments_incoming.DatePosted = bulk_payment.DatePosted;
                m_bulk_payments_incoming.DateCreatedAtClient = bulk_payment.DateCreatedAtClient;
                m_bulk_payments_incoming.Reference = bulk_payment.Reference;
                m_bulk_payments_incoming.CompanyId = bulk_payment.CompanyId;
                m_bulk_payments_incoming.AspNetUserId = bulk_payment.AspNetUserId;
                m_bulk_payments_incoming.AccountNumber = bulk_payment.AccountNumber;
                //add recipients
                foreach (var item in bulk_payment.MBulkPaymentsIncomingRecipients)
                {
                    var recipient = new MBulkPaymentsIncomingRecipients();
                    recipient.MBulkPaymentsIncomingId = item.MBulkPaymentsIncomingId;
                    recipient.IdAtClient = item.IdAtClient;
                    recipient.RecipientName = item.RecipientName;
                    recipient.RecipientBankSwiftCode = item.RecipientBankSwiftCode;
                    recipient.RecipientAccountNumber = item.RecipientAccountNumber;
                    recipient.RecipientAmount = item.RecipientAmount;
                    recipient.BulkPaymentId = item.BulkPaymentId;
                    m_bulk_payments_incoming.MBulkPaymentsIncomingRecipients.Add(recipient);
                }
                //
                db.MBulkPaymentsIncoming.Add(m_bulk_payments_incoming);
                //
                await db.SaveChangesAsync();
                //debit the suspense account
                DebitSuspenseAccount(bulk_payment.AccountNumber, total_recipient_amount);
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
