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
using PayGuardBankInterface.Services;

namespace PayGuardBankInterface.Controllers
{
    /// <summary>
    /// bank interface presents an unified interface for all the banks
    /// </summary>

    [Route("PayGuard/v1")]
    [Authorize(AuthenticationSchemes = "Bearer")]//allow only authorized by Bearer
    public class DebitOrdersController : Controller
    {
        private dbContext db = new dbContext();

        //timers
        private readonly ITimerTimerBulkPaymentsForwardingToRbz ITimerTimerBulkPaymentsForwardingToRbz;
        private readonly ITimerTimerProcessPaymentInstructions ITimerTimerProcessPaymentInstructions;
        //
        public DebitOrdersController(ITimerTimerBulkPaymentsForwardingToRbz ITimerTimerBulkPaymentsForwardingToRbz, ITimerTimerProcessPaymentInstructions ITimerTimerProcessPaymentInstructions)
        {
            this.ITimerTimerBulkPaymentsForwardingToRbz = ITimerTimerBulkPaymentsForwardingToRbz;
            this.ITimerTimerProcessPaymentInstructions = ITimerTimerProcessPaymentInstructions;
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
        /// gamuchira list of debit order instructions from rbz
        /// store debit orders instructions in the database
        /// they will be processed async by another service
        /// </summary>
        /// <param name="payments"></param>
        /// <returns></returns>
        [HttpPost("UploadDebitInstructions")]
        public async Task<JsonResult> UploadDebitInstructions([FromBody] List<MAccountDebitInstructions> debit_orders)
        {
            try
            {
                //
                foreach (var item in debit_orders)
                {
                    var debit_order = new MAccountDebitInstructions();
                    debit_order.Date = item.Date;
                    debit_order.ClientBankCode = item.ClientBankCode;
                    debit_order.ClientAccountNumber = item.ClientAccountNumber;
                    debit_order.SenderBankCode = item.SenderBankCode;
                    debit_order.SenderAccountNumber = item.SenderAccountNumber;
                    debit_order.Amount = item.Amount;
                    debit_order.Reference = item.Reference;
                    db.MAccountDebitInstructions.Add(debit_order);
                }
                await db.SaveChangesAsync();
                return Json(new
                {
                    res = "ok",
                    data = "Bulk Payments Submitted"
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
        /// </summary>
        /// <param name="sender_account">the account of the sender</param>
        /// <returns></returns>
        [HttpGet("ViewBulkPaymentErrors")]
        public JsonResult ViewBulkPaymentErrors(string sender_account)
        {
            try
            {
                var errors = db.MAccountCreditInstructionsFailed//failed transactions
                    .Where(i => i.SenderAccountNumber == sender_account)//sender account
                    .ToList();

                return Json(new
                {
                    res = "ok",
                    data = errors
                });
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
