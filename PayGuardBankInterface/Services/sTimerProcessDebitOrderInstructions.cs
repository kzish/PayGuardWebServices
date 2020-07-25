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
    /// processes debit orders recieved from rbz
    /// </summary>
    public class sTimerProcessDebitOrderInstructions : ITimerProcessDebitOrderInstructions
    {

        private Timer timer;
        private bool busy;
        private string source = "PayGuardBankInterface.Services.sTimerProcessDebitOrderInstructions";
        //constructor
        public sTimerProcessDebitOrderInstructions()
        {
            var autoEvent = new AutoResetEvent(false);
            timer = new Timer(RunTask, autoEvent, 0, 5000);//5 sec timer
        }

        /// <summary>
        /// task will process the debit order instruction
        /// debits the cleint/debitee account
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
                    //pick up a debit instruction from the db
                    var debit = db.MAccountDebitInstructions.FirstOrDefault();
                    //
                    if (debit == null) return;
                    //debit recipient account
                    var success = Globals.DebitAccount(debit.ClientAccountNumber, debit.Amount);
                    if (success)
                    {
                        //save into processed table and remove the debit
                        var processed_debit = new MAccountDebitInstructionsProcessed();
                        processed_debit.Date = debit.Date;
                        processed_debit.ClientBankCode = debit.ClientBankCode;
                        processed_debit.ClientAccountNumber = debit.ClientAccountNumber;
                        processed_debit.SenderBankCode = debit.SenderBankCode;
                        processed_debit.SenderAccountNumber = debit.SenderAccountNumber;
                        processed_debit.Amount = debit.Amount;
                        processed_debit.Reference = debit.Reference;
                        //add proccessed debit
                        db.MAccountDebitInstructionsProcessed.Add(processed_debit);
                        //remove debit instruction
                        db.MAccountDebitInstructions.Remove(debit);
                        db.SaveChanges();
                    }
                    else
                    {
                        //save into failed table and remove the debit
                        var failed_debit = new MAccountDebitInstructionsFailed();
                        failed_debit.Date = debit.Date;
                        failed_debit.ClientBankCode = debit.ClientBankCode;
                        failed_debit.ClientAccountNumber = debit.ClientAccountNumber;
                        failed_debit.SenderBankCode = debit.SenderBankCode;
                        failed_debit.SenderAccountNumber = debit.SenderAccountNumber;
                        failed_debit.Amount = debit.Amount;
                        failed_debit.Reference = debit.Reference;
                        //add proccessed debit
                        db.MAccountDebitInstructionsFailed.Add(failed_debit);
                        //remove debit instruction
                        db.MAccountDebitInstructions.Remove(debit);
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
