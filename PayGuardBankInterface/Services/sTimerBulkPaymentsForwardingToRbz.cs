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
    /// sends the bulk payments to rbz
    /// </summary>
    public class sTimerBulkPaymentsForwardingToRbz : ITimerTimerBulkPaymentsForwardingToRbz
    {

        private Timer timer;
        private bool busy;
        private string source = "PayGuardBankInterface.Services.sTimerBulkPaymentsForwardingToRbz";
        //constructor
        public sTimerBulkPaymentsForwardingToRbz()
        {
            var autoEvent = new AutoResetEvent(false);
            timer = new Timer(RunTask, autoEvent, 0, 5000);//5 sec timer
        }

        /// <summary>
        /// task will forward bulk payment to rbz
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
                    //grab a bulk payment from the db
                    var bulk_payment = db.MBulkPaymentsIncoming
                        .Include(i => i.MBulkPaymentsIncomingRecipients)//include recipients
                        .FirstOrDefault();
                    //
                    if (bulk_payment == null) return;
                    //get access token
                    var http_client = new HttpClient();
                    var request_token = http_client.GetAsync($"{Globals.rbz_end_point}/PayGuard/v1/RequestToken?clientID={Globals.client_id}&clientSecret={Globals.client_secret}")
                        .Result
                        .Content
                        .ReadAsStringAsync()
                        .Result;
                    if (string.IsNullOrEmpty(request_token))
                    {
                        var error = new MErrors() { Date = DateTime.Now, Data1 = source + ".RunTask", Data2 = "failed to fetch access token" };
                        db.MErrors.Add(error);
                        db.SaveChanges();
                        db.Dispose();
                        return;//finally block is executed 
                    }
                    //
                    dynamic token = JsonConvert.DeserializeObject(request_token);
                    string access_token = token.access_token;
                    //add token
                    http_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");
                    //upload bulkpayment to rbz        
                    var json_string = JsonConvert.SerializeObject(bulk_payment, new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                    var http_content = new StringContent(json_string, Encoding.UTF8, "application/json");
                    var post_response = http_client.PostAsync($"{Globals.rbz_end_point}/PayGuard/v1/UploadBulkPayment", http_content)
                        .Result
                        .Content
                        .ReadAsStringAsync()
                        .Result;
                    //
                    dynamic response = JsonConvert.DeserializeObject(post_response);
                    if ((string)response.res == "ok")
                    {
                        //move to processed table and clear this bulkpayment
                        var processed = new MBulkPaymentsIncomingProcessed();
                        processed.IdAtClient = bulk_payment.IdAtClient;
                        processed.DatePosted = bulk_payment.DatePosted;
                        processed.DateCreatedAtClient = bulk_payment.DateCreatedAtClient;
                        processed.Reference = bulk_payment.Reference;
                        processed.CompanyId = bulk_payment.CompanyId;
                        processed.AspNetUserId = bulk_payment.AspNetUserId;
                        processed.DateProcessed = DateTime.Now;
                        processed.AccountNumber = bulk_payment.AccountNumber;
                        processed.BankCode = bulk_payment.BankCode;
                        //
                        db.MBulkPaymentsIncomingProcessed.Add(processed);
                        db.SaveChanges();
                        //save recipients
                        foreach(var item in bulk_payment.MBulkPaymentsIncomingRecipients)
                        {
                            var recipient = new MBulkPaymentsIncomingRecipientsProcessed();
                            recipient.MBulkPaymentsIncomingId = processed.Id;
                            recipient.IdAtClient = item.IdAtClient;
                            recipient.RecipientName = item.RecipientName;
                            recipient.RecipientBankSwiftCode = item.RecipientBankSwiftCode;
                            recipient.RecipientAccountNumber = item.RecipientAccountNumber;
                            recipient.RecipientAmount = item.RecipientAmount;
                            recipient.BulkPaymentId = item.BulkPaymentId;
                            db.MBulkPaymentsIncomingRecipientsProcessed.Add(recipient);
                        }
                        //
                        db.MBulkPaymentsIncoming.Remove(bulk_payment);
                        db.SaveChanges();
                    }
                    else
                    {
                        //if failed the bulkpayment says inside the inbox, the service will try again 
                        var error = new MErrors() { Date = DateTime.Now, Data1 = source + ".RunTask   failed to upload bulk payment to rbz", Data2 = (string)response.msg };
                        db.MErrors.Add(error);
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
