using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayGuardAdmin.Models;

namespace PayGuardAdmin.Controllers
{
    [Route("Banks")]
    [Authorize(Roles ="admin")]
    public class BanksController : Controller
    {

        private dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        [HttpGet("AllBanks")]
        [HttpGet("")]
        public IActionResult AllBanks()
        {
            ViewBag.title = "All Banks";
            return View();
        }

        [HttpGet("ajaxAllBanks")]
        public IActionResult ajaxAllBanks()
        {
            ViewBag.title = "All Banks";
            var banks = db.MBank.ToList();
            ViewBag.banks = banks;
            return View();
        }

        [HttpGet("CreateBank")]
        public IActionResult CreateBank()
        {
            ViewBag.title = "Create Bank";
            return View();
        }


        [HttpPost("CreateBank")]
        public async Task<IActionResult> CreateBank(MBank bank)
        {
            try
            {
                ViewBag.title = "Create Bank";
                db.MBank.Add(bank);
                await db.SaveChangesAsync();
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                return View();
            }
            return RedirectToAction("AllBanks");
        }



        [HttpGet("EditBank/{id}")]
        public IActionResult EditBank(int id)
        {
            try
            {
                ViewBag.title = "Edit Bank";
                var bank = db.MBank.Find(id);
                ViewBag.bank = bank;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.bank = new MBank();
                return RedirectToAction("AllBanks");
            }
            return View();
        }

        [HttpPost("EditBank")]
        public async Task<IActionResult> EditBank(MBank bank)
        {
            try
            {
                ViewBag.title = "Edit Bank";
                db.Entry(bank).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
                ViewBag.bank = bank;
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.bank = new MBank();
                return RedirectToAction("EditBank", "Banks", new { id = bank.Id });
            }

            return RedirectToAction("Allbanks");
        }


        [HttpPost("DeleteBank")]
        public async Task<IActionResult> DeleteBank(int id)
        {
            try
            {
                var bank = db.MBank.Find(id);
                db.MBank.Remove(bank);
                await db.SaveChangesAsync();
                ViewBag.bank = bank;
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
            }
            return RedirectToAction("Allbanks");
        }



    }
}
