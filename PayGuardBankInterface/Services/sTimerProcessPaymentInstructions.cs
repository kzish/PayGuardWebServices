using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.ServiceModel;
using PayGuardBankInterface.Models;
using PayGuard.Models;

namespace PayGuardBankInterface.Services
{

    /// <summary>
    /// processes payment instructions recieved from rbz
    /// </summary>
    public class sTimerProcessPaymentInstructions : ITimerProcessPaymentInstructions
    {

        private Timer timer;
        private bool busy;
        private string source = "PayGuardBankInterface.Services.sTimerProcessPaymentInstructions";
        //constructor
        public sTimerProcessPaymentInstructions()
        {
            var autoEvent = new AutoResetEvent(false);
            timer = new Timer(RunTask, autoEvent, 0, 5000);//5 sec timer
        }

        /// <summary>
        /// task will process the payment instruction
        /// credits the beneficiary account
        /// stores the payment instruction into the processed table
        /// </summary>
        /// <param name="state"></param>
        public void RunTask(object state)
        {
            //
            if (busy) return;

            try
            {
                //
                busy = true;
                //
                using (var db = new dbContext())
                {
                    var payment = db.MAccountCreditInstructions.FirstOrDefault();
                    //
                    if (payment == null) return;
                    //credit recipient account
                    var success=Globals.CreditAccount(payment.RecipientAccountNumber, payment.Amount);
                    if(success)
                    {
                        //save into processed table and remove the payment
                        var processed_payment = new MAccountCreditInstructionsProcessed();
                        processed_payment.Date = DateTime.Now;
                        processed_payment.RecipientBankCode = payment.RecipientBankCode;
                        processed_payment.RecipientAccountNumber = payment.RecipientAccountNumber;
                        processed_payment.SenderBankCode = payment.SenderBankCode;
                        processed_payment.SenderAccountNumber = payment.SenderAccountNumber;
                        processed_payment.Amount = payment.Amount;
                        processed_payment.Reference = payment.Reference;
                        //add proccessed payment
                        db.MAccountCreditInstructionsProcessed.Add(processed_payment);
                        //remove payment instruction
                        db.MAccountCreditInstructions.Remove(payment);
                        db.SaveChanges();
                    }
                    else
                    {
                        //save into failed table and remove the payment
                        var processed_payment = new MAccountCreditInstructionsFailed();
                        processed_payment.Date = DateTime.Now;
                        processed_payment.RecipientBankCode = payment.RecipientBankCode;
                        processed_payment.RecipientAccountNumber = payment.RecipientAccountNumber;
                        processed_payment.SenderBankCode = payment.SenderBankCode;
                        processed_payment.SenderAccountNumber = payment.SenderAccountNumber;
                        processed_payment.Amount = payment.Amount;
                        processed_payment.Reference = payment.Reference;
                        //add proccessed payment
                        db.MAccountCreditInstructionsFailed.Add(processed_payment);
                        //remove payment instruction
                        db.MAccountCreditInstructions.Remove(payment);
                        db.SaveChanges();
                    }
                    db.Dispose();
                }//using

            }
            catch (Exception ex)
            {
                using (var db = new dbContext())
                {
                    var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                    db.MErrors.Add(error);
                    db.SaveChanges();
                    db.Dispose();
                }
            }
            finally
            {
                busy = false;
            }


        }//runtask





    }//sTimer







}//namespace
