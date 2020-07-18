using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayGuardClient.Models;

namespace PayGuardClient.Controllers
{
    [Route("BulkPayments")]
    [Authorize]
    public class BulkPaymentsController : Controller
    {

        private dbContext db = new dbContext();
        private HostingEnvironment host;

        public BulkPaymentsController(HostingEnvironment host)
        {
            this.host = host;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        [HttpGet("AllBulkPayments")]
        [HttpGet("")]
        public IActionResult AllBulkPayments()
        {
            ViewBag.title = "All BulkPayments";
            return View();
        }

        [HttpGet("ajaxAllBulkPayments")]
        public IActionResult ajaxAllBulkPayments()
        {
            ViewBag.title = "All BulkPayments";
            var bulk_payments = db.MBulkPayments.ToList();
            ViewBag.bulk_payments = bulk_payments;
            return View();
        }

        [HttpGet("CreateBulkPayments")]
        public IActionResult CreateBulkPayments()
        {
            ViewBag.title = "Create BulkPayment";
            return View();
        }

        /// <summary>
        /// fetch all banks async and display to the client
        /// </summary>
        /// <returns></returns>

        [HttpGet("ajaxAllBanks")]
        public IActionResult ajaxAllBanks()
        {
            var banks = db.MBank.ToList();
            ViewBag.banks = banks;
            return View();
        }

        /// <summary>
        /// fetch all ajaxAllBulkPaymentRecipients
        /// </summary>
        /// <returns></returns>
        [HttpGet("ajaxAllBulkPaymentRecipients/{bulk_payment_id}")]
        public IActionResult ajaxAllBulkPaymentRecipients(int bulk_payment_id)
        {
            var recipients = db.MBulkPaymentsRecipients
                .Where(i => i.BulkPaymentId == bulk_payment_id)
                .Include(i => i.ERecipientBank)
                .ToList();
            ViewBag.recipients = recipients;
            return View();
        }


        [HttpPost("CreateBulkPayments")]
        public async Task<IActionResult> CreateBulkPayments(string reference, IFormFile file)
        {
            try
            {
                ViewBag.title = "Create BulkPayment";
                //temp file
                var file_name = Guid.NewGuid().ToString();
                var file_path = host.WebRootPath + "/Uploads/" + file_name + ".csv";
                using (var stream = new FileStream(file_path, FileMode.CreateNew))
                {
                    await file.CopyToAsync(stream);
                    stream.Dispose();
                }
                //read uploaded data
                var bulk_payment_data = System.IO.File.ReadAllLines(file_path);
                //delete the file
                System.IO.File.Delete(file_path);
                //
                var asp_net_user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                var system_user = db.MUsers.Where(i => i.AspNetUserId == asp_net_user.Id).FirstOrDefault();
                var company = db.MCompany.Where(i => i.Id == system_user.CompanyId).FirstOrDefault();
                //get session user
                var user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                //create bulk payment header
                var bulk_payment = new MBulkPayments();
                bulk_payment.Date = DateTime.Now;
                bulk_payment.Reference = reference;
                bulk_payment.CompanyId = company.Id;
                bulk_payment.AspNetUserId = asp_net_user.Id;
                db.MBulkPayments.Add(bulk_payment);
                await db.SaveChangesAsync();
                //create bulk_payment recipients
                var bulk_payment_recipients = new List<MBulkPaymentsRecipients>();
                int num_errors = 0;
                foreach (var line in bulk_payment_data)
                {
                    try
                    {
                        var bulk_payment_recipient = new MBulkPaymentsRecipients();
                        bulk_payment_recipient.RecipientName = line.Split(',')[0];
                        //
                        int ERecipientBankId = 0;
                        int.TryParse(line.Split(',')[1], out ERecipientBankId);
                        bulk_payment_recipient.ERecipientBankId = ERecipientBankId;
                        //
                        bulk_payment_recipient.RecipientAccountNumber = line.Split(',')[2];
                        //
                        decimal RecipientAmount = decimal.Zero;
                        decimal.TryParse(line.Split(',')[3], out RecipientAmount);
                        bulk_payment_recipient.RecipientAmount = RecipientAmount;
                        //
                        bulk_payment_recipient.BulkPaymentId = bulk_payment.Id;
                        bulk_payment_recipients.Add(bulk_payment_recipient);
                    }
                    catch (Exception ex)
                    {
                        num_errors++;
                    }
                }
                //
                db.MBulkPaymentsRecipients.AddRange(bulk_payment_recipients);
                await db.SaveChangesAsync();
                TempData["msg"] = $"You have {num_errors} errors and {bulk_payment_data.Count()} records";
                TempData["type"] = "warning";
                return RedirectToAction("EditBulkPayment", "BulkPayments", new { id = bulk_payment.Id });

            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
                return View();
            }
        }



        [HttpGet("EditBulkPayments/{id}")]
        public IActionResult EditBulkPayments(int id)
        {
            try
            {
                ViewBag.title = "Edit BulkPayment";
                var bulk_payment = db.MBulkPayments.Find(id);
                ViewBag.bulk_payment = bulk_payment;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.bulk_payment = new MBulkPayments();
                return RedirectToAction("AllBulkPayments");
            }
            return View();
        }


        [HttpPost("EditBulkPayments")]
        public async Task<IActionResult> EditBulkPayments(int Id, string reference, IFormFile file)
        {
            try
            {
                ViewBag.title = "Edit BulkPayments";
                //
                if (file != null)
                {
                    //temp file
                    var file_name = Guid.NewGuid().ToString();
                    var file_path = host.WebRootPath + "/Uploads/" + file_name + ".csv";
                    using (var stream = new FileStream(file_path, FileMode.CreateNew))
                    {
                        await file.CopyToAsync(stream);
                        stream.Dispose();
                    }
                    //read uploaded data
                    var bulk_payment_data = System.IO.File.ReadAllLines(file_path);
                    //delete the file
                    System.IO.File.Delete(file_path);

                    //remove all previous recipients
                    var old_recipients = db.MBulkPaymentsRecipients.Where(i => i.BulkPaymentId == Id).ToList();
                    if (old_recipients.Count > 0)
                    {
                        db.MBulkPaymentsRecipients.RemoveRange(old_recipients);
                        await db.SaveChangesAsync();
                    }
                    //
                    string msg = "nothing";
                    //add newly uploaded recipients
                    var bulk_payment_recipients = new List<MBulkPaymentsRecipients>();
                    int num_errors = 0;
                    foreach (var line in bulk_payment_data)
                    {
                        try
                        {
                            var bulk_payment_recipient = new MBulkPaymentsRecipients();
                            bulk_payment_recipient.RecipientName = line.Split(',')[0];
                            //
                            int ERecipientBankId = 0;
                            int.TryParse(line.Split(',')[1], out ERecipientBankId);
                            bulk_payment_recipient.ERecipientBankId = ERecipientBankId;
                            //
                            bulk_payment_recipient.RecipientAccountNumber = line.Split(',')[2];
                            //
                            decimal RecipientAmount = decimal.Zero;
                            decimal.TryParse(line.Split(',')[3], out RecipientAmount);
                            bulk_payment_recipient.RecipientAmount = RecipientAmount;
                            //
                            bulk_payment_recipient.BulkPaymentId = Id;
                            bulk_payment_recipients.Add(bulk_payment_recipient);
                            db.MBulkPaymentsRecipients.Add(bulk_payment_recipient);
                            msg = "pasted";
                        }
                        catch (Exception ex)
                        {
                            num_errors++;
                        }
                    }


                    TempData["msg"] = msg;
                    TempData["type"] = "warning";
                    //TempData["msg"] = bulk_payment_data[0];
                    //TempData["type"] = "warning";
                    //TempData["msg"] = $"You have {num_errors} errors and {bulk_payment_data.Count()} records";
                    //TempData["type"] = "warning";
                }


                //
                var asp_net_user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                var system_user = db.MUsers.Where(i => i.AspNetUserId == asp_net_user.Id).FirstOrDefault();
                var company = db.MCompany.Where(i => i.Id == system_user.CompanyId).FirstOrDefault();
                //get session user
                var user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                //update reference
                var bulk_payment = db.MBulkPayments.Find(Id);
                bulk_payment.Reference = reference;
                db.Entry(bulk_payment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                //
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.StackTrace;
                TempData["type"] = "error";
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                //db.SaveChanges();
            }
            return RedirectToAction("EditBulkPayments", "BulkPayments", new { id = Id });

        }


        [HttpPost("DeleteBulkPayments")]
        public async Task<IActionResult> DeleteBulkPayments(int id)
        {
            try
            {
                var BulkPayment = db.MBulkPayments.Find(id);
                db.MBulkPayments.Remove(BulkPayment);
                await db.SaveChangesAsync();
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
            }
            return RedirectToAction("AllBulkPayments");
        }



    }
}
