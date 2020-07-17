using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        [HttpPost("CreateBulkPayments")]
        public async Task<IActionResult> CreateBulkPayments(string reference, IFormFile file)
        {
            try
            {
                ViewBag.title = "Create BulkPayment";
                //temp file
                string bulk_payment_data = string.Empty;
                var file_name = Guid.NewGuid().ToString();
                var file_path = host.WebRootPath + "/Uploads/" + file_name + ".csv";
                using (var stream = new FileStream(file_path, FileMode.CreateNew))
                {
                    await file.CopyToAsync(stream);
                    stream.Dispose();
                }
                //read uploaded data
                bulk_payment_data = System.IO.File.ReadAllText(file_path);
                //delete the file
                System.IO.File.Delete(file_path);

                TempData["msg"] = bulk_payment_data;
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                return View();
            }
            return RedirectToAction("AllBulkPayments");
        }



        [HttpGet("EditBulkPayment/{id}")]
        public IActionResult EditBulkPayment(int id)
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

        [HttpPost("EditBulkPayment")]
        public async Task<IActionResult> EditBulkPayment(MBulkPayments BulkPayment)
        {
            try
            {
                ViewBag.title = "Edit BulkPayment";
                db.Entry(BulkPayment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.bulk_payment = new MBulkPayments();
                return RedirectToAction("EditBulkPayment", "BulkPayments", new { id = BulkPayment.Id });
            }

            return RedirectToAction("AllBulkPayments");
        }


        [HttpPost("DeleteBulkPayment")]
        public async Task<IActionResult> DeleteBulkPayment(int id)
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
