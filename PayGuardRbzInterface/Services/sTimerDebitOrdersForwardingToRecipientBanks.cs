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
using PayGuard.Models;
using PayGuardRbzInterface.Models;

namespace PayGuardRbzInterface.Services
{

    /// <summary>
    /// sends the debit orders to each recipient bank
    /// </summary>
    public class sTimerDebitOrdersForwardingToRecipientBanks : ITimerDebitOrdersForwardingToRecipientBanks
    {

        private Timer timer;
        private bool busy;
        private string source = "PayGuardBankInterface.Services.sTimerDebitOrdersForwardingToRecipientBank";
        //constructor
        public sTimerDebitOrdersForwardingToRecipientBanks()
        {
            var autoEvent = new AutoResetEvent(false);
            timer = new Timer(RunTask, autoEvent, 0, 5000);//5 sec timer
        }
        /// <summary>
        /// group payment instructions by bank code
        /// forward messages to bank endpoint
        /// grouping messages reduces number of requests
        /// does not credit/debit suspense accounts
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
                    var banks = db.MBank.ToList();
                    foreach (var bank in banks)
                    {
                        //grab 1k records for this bank
                        var debits = db.MAccountDebitInstructions
                            .Where(i => i.ClientBankCode == bank.SwiftCode)//group by bank
                            .Take(1000)//send only 1k at a time
                            .ToList();

                        if (debits.Count == 0) continue;//skip this iteration if no records

                        //get access token
                        var http_client = new HttpClient();
                        var access_token = Globals.GetAccessToken(bank.EndPoint);
                        if (string.IsNullOrEmpty(access_token))
                        {
                            var error = new MErrors() { Date = DateTime.Now, Data1 = source + ".RunTask", Data2 = "failed to fetch access token" };
                            db.MErrors.Add(error);
                            db.SaveChanges();
                            db.Dispose();
                            return;//finally block is executed 
                        }
                        //add token
                        http_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");
                        //serialize and send payments to recipient bank end point       
                        var json_string = JsonConvert.SerializeObject(debits, new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                        var http_content = new StringContent(json_string, Encoding.UTF8, "application/json");
                        var post_response = http_client.PostAsync($"{bank.EndPoint}/PayGuard/v1/UploadDebitInstructions", http_content)
                            .Result
                            .Content
                            .ReadAsStringAsync()
                            .Result;
                        //
                        dynamic response = JsonConvert.DeserializeObject(post_response);
                        if ((string)response.res == "ok")
                        {
                            //store into processed and remove this debit order
                            foreach(var item in debits)
                            {
                                var processed = new MAccountDebitInstructionsProcessed();
                                processed.Date = item.Date;
                                processed.ClientBankCode = item.ClientBankCode;
                                processed.ClientAccountNumber = item.ClientAccountNumber;
                                processed.SenderBankCode = item.SenderBankCode;
                                processed.SenderAccountNumber = item.SenderAccountNumber;
                                processed.Amount = item.Amount;
                                processed.Reference = item.Reference;
                                db.MAccountDebitInstructionsProcessed.Add(processed);//add to processed
                                db.MAccountDebitInstructions.Remove(item);//remove from inbox
                            }
                            db.SaveChanges();//save
                        }
                        else
                        {
                            db.SaveChanges();//save
                            var error = new MErrors() { Date = DateTime.Now, Data1 = source + ".RunTask failed to route debit instructions instructions to recipient bank", Data2 = (string)response.msg };
                            db.MErrors.Add(error);
                            db.SaveChanges();
                        }
                    }//foreach
                    db.Dispose();
                }//using

            }//try
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
