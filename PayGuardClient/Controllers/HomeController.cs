using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayGuardClient.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SpeedLinkAdminPortal.Controllers
{
    [Route("Home")]
    [Route("")]
    [Authorize]
    public class HomeController : Controller
    {
        dbContext db = new dbContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        RoleManager<IdentityRole> roleManager;
        public HomeController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [Route("Dashboard")]
        [Route("")]
        public async Task<IActionResult> Dashboard(string date_from, string date_to)
        {
            ViewBag.title = "Dashboard";

            try
            {
                var banks = db.MBank.ToList();
                ViewBag.banks = banks;
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Error fetching data from server";
                TempData["type"] = "error";
                TempData["ex"] = ex.Message;
            }

            return View();
        }


        [HttpGet("ajaxAllBanks")]
        public IActionResult ajaxAllBanks()
        {
            var banks = db.MBank.ToList();
            ViewBag.banks = banks;
            return View();
        }


    }
}
