using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayGuardAdmin.Models;

namespace PayGuardAdmin.Controllers
{
    [Route("Companies")]
    [Authorize(Roles = "admin")]
    public class CompaniesController : Controller
    {

        private dbContext db = new dbContext();


        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public CompaniesController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        [HttpGet("AllCompanies")]
        [HttpGet("")]
        public IActionResult AllCompanies()
        {
            ViewBag.title = "All Companies";
            return View();
        }

        [HttpGet("ajaxAllCompanies")]
        public IActionResult ajaxAllCompanies()
        {
            ViewBag.title = "All Companies";
            var companies = db.MCompany.Include(i=>i.EBankCodeNavigation).ToList();
            ViewBag.companies = companies;
            return View();
        }

        [HttpGet("CreateCompany")]
        public IActionResult CreateCompany()
        {
            ViewBag.title = "Create Company";
            var banks = db.MBank.ToList();
            ViewBag.banks = banks;
            return View();
        }


        [HttpPost("CreateCompany")]
        public async Task<IActionResult> CreateCompany(MCompany company)
        {
            try
            {
                //create company
                db.MCompany.Add(company);
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
            return RedirectToAction("AllCompanies");
        }



        [HttpGet("EditCompany/{id}")]
        public IActionResult EditCompany(int id)
        {
            try
            {
                ViewBag.title = "Edit Company";

                var company = db.MCompany.Find(id);
                var banks = db.MBank.ToList();
                ViewBag.company = company;
                ViewBag.banks = banks;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.company = new MCompany();
                return RedirectToAction("AllCompanies");
            }
            return View();
        }

        [HttpPost("EditCompany")]
        public async Task<IActionResult> Editcompany(MCompany company)
        {
            try
            {
                ViewBag.title = "Edit Company";
                db.Entry(company).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
                ViewBag.company = company;
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.company = new MCompany();
                return RedirectToAction("EditCompany", "Companies", new { id = company.Id });
            }

            return RedirectToAction("AllCompanies");
        }


        [HttpPost("Deletecompany")]
        public async Task<IActionResult> Deletecompany(string id)
        {
            try
            {
                var company = db.MCompany.Find(id);
                db.MCompany.Remove(company);
                await db.SaveChangesAsync();
                ViewBag.company = company;
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
            }
            return RedirectToAction("AllCompanies");
        }



    }
}
