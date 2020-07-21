using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayGuardAdmin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SpeedLinkAdminPortal.Controllers
{
    [Route("Home")]
    [Route("")]
    [Authorize(Roles="admin")]
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
                ViewBag.num_clients = db.MCompany.Count();
                ViewBag.num_banks_online = db.MBank.Where(i => i.Online).Count();
                ViewBag.num_banks_offline = db.MBank.Where(i => !i.Online).Count();
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
