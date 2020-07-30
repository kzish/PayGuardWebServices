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
    /// return processed debit orders to rbz
    /// </summary>
    public class sTimerReturnProcessedDebitOrdersToRbz : ITimerReturnProcessedDebitOrdersToRbz
    {

        private Timer timer;
        private bool busy;
        private string source = "PayGuardBankInterface.Services.sTimerReturnProcessedDebitOrdersToRbz";
        //constructor
        public sTimerReturnProcessedDebitOrdersToRbz()
        {
            var autoEvent = new AutoResetEvent(false);
            timer = new Timer(RunTask, autoEvent, 0, 5000);//5 sec timer
        }

        /// <summary>
        /// task will pick a processed debit order from db
        /// send the processed debit order to rbz
        /// removes the debit from the processed db 
        /// stores the processed debit into the returned to rbz table
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
                    var processed_debit_orders = db.MAccountDebitInstructionsProcessed
                        .Take(1000)//move 1k at a time
                        .ToList();
                    //
                    var access_token = Globals.GetAccessToken(Globals.rbz_end_point);
                    if (string.IsNullOrEmpty(access_token)) return;
                    //
                    var http_client = new HttpClient();
                    http_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");
                    var response = http_client
                        .PostAsJsonAsync($"{Globals.rbz_end_point}/PayGuard/v1/UploadProcessedDebitOrders", processed_debit_orders)
                        .Result
                        .Content
                        .ReadAsStringAsync()
                        .Result;

                    dynamic response_json = JsonConvert.DeserializeObject(response);
                    if(response_json.res=="ok")
                    {
                        //move thes to the returned to rbz table
                        foreach(var item in processed_debit_orders)
                        {
                            var returned_to_rbz = new MAccountDebitInstructionsSentToRbz();
                            returned_to_rbz.Date = DateTime.Now;
                            returned_to_rbz.ClientBankCode = item.ClientBankCode;
                            returned_to_rbz.ClientAccountNumber = item.ClientAccountNumber;
                            returned_to_rbz.SenderBankCode = item.SenderBankCode;
                            returned_to_rbz.SenderAccountNumber = item.SenderAccountNumber;
                            returned_to_rbz.Amount = item.Amount;
                            returned_to_rbz.Reference = item.Reference;
                            //add
                            db.MAccountDebitInstructionsSentToRbz.Add(returned_to_rbz);
                            //remove
                            db.MAccountDebitInstructionsProcessed.Remove(item);
                        }
                    }
                    else
                    {
                        //store error
                        var error = new MErrors() { Date=DateTime.Now,Data1="Failed to upload processed debit orders to rbz",Data2=(string)response_json.msg};
                        db.MErrors.Add(error);
                        db.SaveChanges();
                    }
                    db.SaveChanges();
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
