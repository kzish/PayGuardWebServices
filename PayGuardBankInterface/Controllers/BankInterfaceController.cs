﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayGuard.Models;
using PayGuardBankInterface.Models;
using PayGuardBankInterface.Services;

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

        //timers
        private readonly ITimerBulkPaymentsForwardingToRbz ITimerBulkPaymentsForwardingToRbz;
        public BankInterfaceController(ITimerBulkPaymentsForwardingToRbz ITimerBulkPaymentsForwardingToRbz)
        {
            this.ITimerBulkPaymentsForwardingToRbz = ITimerBulkPaymentsForwardingToRbz;
        }

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
        //[HttpGet("GetAccountBalance")]
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
        //[HttpPost("DebitAccount")]
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

        /// <summary>
        /// gamuchira bulk payment from the client portal 
        /// save bulk payment into the db
        /// accepts MBulkPayments type and converts into MBulkPaymentsIncoming
        /// debits the bank account
        /// debits the transaction fee
        /// todo: put transaction fee into another account
        /// </summary>
        /// <param name="bulk_payment"></param>
        /// <returns></returns>
        [HttpPost("UploadBulkPayment")]
        public async Task<JsonResult> UploadBulkPayment([FromBody] MBulkPayments bulk_payment)
        {
            try
            {
                //transaction fee stays with the payers bank, it is not debited from the suspense account
                decimal total_recipient_amount = bulk_payment.MBulkPaymentsRecipients.Sum(i => i.RecipientAmount);
                decimal transaction_fee = 0;//todo: get transaction fee from each bank

                decimal total_amount_to_debit = total_recipient_amount + transaction_fee;
                decimal account_balance = GetAccountBalance(bulk_payment.AccountNumber);

                if (account_balance < total_amount_to_debit)
                {
                    return Json(new
                    {
                        res = "err",
                        msg = $"Insufficient balance. Available funds: {account_balance}"
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
                m_bulk_payments_incoming.AccountNumber = bulk_payment.AccountNumber;
                m_bulk_payments_incoming.BankCode = bulk_payment.BankCode;
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
                //
                await db.SaveChangesAsync();
                //
                DebitAccount(bulk_payment.AccountNumber, total_amount_to_debit);
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
