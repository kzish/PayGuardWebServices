using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayGuard.Models;
using PayGuardBankInterface.Models;

namespace PayGuardBankInterface.Controllers
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
        /// return the available funds in the given account
        /// </summary>
        /// <param name="account_number"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private decimal GetAccountBalance(string account_number)
        {
            try
            {
                return 45000;
            }
            catch (Exception ex)
            {
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
                return 0;
            }
        }

        /// <summary>
        /// debit the payers account
        /// </summary>
        /// <param name="account_number"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private bool DebitAccount(string account_number, decimal amount)
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


        [HttpPost("UploadBulkPayment")]
        public async Task<JsonResult> UploadBulkPayment([FromBody] MBulkPayments bulk_payment)
        {
            try
            {

                decimal total_recipient_amount = bulk_payment.MBulkPaymentsRecipients.Sum(i => i.RecipientAmount);
                decimal transaction_fee = 0;
                decimal total_amount_to_debit = (total_recipient_amount + transaction_fee);
                var available_balance = GetAccountBalance("");

                if (available_balance < total_amount_to_debit)
                {
                    return Json(new
                    {
                        res = "err",
                        msg = $"Insufficient balance. Available balance: {available_balance.ToString("0.00")}"
                    });
                }

                //add bulk payment
                var m_bulk_payments_incoming = new MBulkPaymentsIncoming();
                m_bulk_payments_incoming.IdAtClient = bulk_payment.Id;
                m_bulk_payments_incoming.DatePosted = DateTime.Now;
                m_bulk_payments_incoming.DateCreatedAtClient = bulk_payment.Date;
                m_bulk_payments_incoming.Reference = bulk_payment.Reference;
                m_bulk_payments_incoming.CompanyId = bulk_payment.CompanyId;
                m_bulk_payments_incoming.AspNetUserId = bulk_payment.AspNetUserId;
                db.MBulkPaymentsIncoming.Add(m_bulk_payments_incoming);
                await db.SaveChangesAsync();
                //add recipients
                foreach (var item in bulk_payment.MBulkPaymentsRecipients)
                {
                    var m_bulk_payments_incoming_recipients = new MBulkPaymentsIncomingRecipients();
                    m_bulk_payments_incoming_recipients.MBulkPaymentsIncomingId = m_bulk_payments_incoming.Id;
                    m_bulk_payments_incoming_recipients.IdAtClient = item.Id;
                    m_bulk_payments_incoming_recipients.RecipientName = item.RecipientName;
                    m_bulk_payments_incoming_recipients.RecipientBankSwiftCode = item.RecipientBankSwiftCode;
                    m_bulk_payments_incoming_recipients.RecipientAccountNumber = item.RecipientAccountNumber;
                    m_bulk_payments_incoming_recipients.RecipientAmount = item.RecipientAmount;
                    m_bulk_payments_incoming_recipients.BulkPaymentId = item.BulkPaymentId;
                    db.MBulkPaymentsIncomingRecipients.Add(m_bulk_payments_incoming_recipients);
                }

                await db.SaveChangesAsync();

                DebitAccount(bulk_payment.AccountNumber, total_amount_to_debit);

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
