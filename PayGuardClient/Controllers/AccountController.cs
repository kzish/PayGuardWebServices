using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayGuardClient.Models;

namespace PayGuardClient.Controllers
{
    [Route("Account")]
    [Authorize]
    public class AccountController : Controller
    {

        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        dbContext db = new dbContext();
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
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

        [HttpGet("ChangePassword")]
        public IActionResult ChangePassword()
        {
            ViewBag.title = "Change Password";
            var user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
            ViewBag.user = user;
            return View();
        }

        /// <summary>
        /// change my own password
        /// </summary>
        /// <param name="old_password"></param>
        /// <param name="new_password"></param>
        /// <param name="confirm_password"></param>
        /// <returns></returns>
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(string old_password, string new_password, string confirm_password)
        {
            try
            {
                ViewBag.title = "Change Password";
                var id_user = await userManager.GetUserAsync(HttpContext.User);
                var result = await userManager.ChangePasswordAsync(id_user, old_password, new_password);
                if (result.Succeeded)
                {
                    var user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                    ViewBag.user = user;
                    TempData["msg"] = "Password changed. Login to continue"; ;
                    TempData["type"] = "success";
                    await signInManager.SignOutAsync();
                    return RedirectToAction("Login", "Auth");
                }
                else
                {
                    TempData["msg"] = String.Join(" ",result.Errors.Select(i=>i.Description).ToList());
                    TempData["type"] = "error";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
            }
            return View();
        }



        [HttpGet("BankingDetails")]
        public IActionResult BankingDetails()
        {
            ViewBag.title= "Banking Details";
            var user = db.AspNetUsers
                .Where(i => i.Email == User.Identity.Name)
                .Include(i=>i.MUsers)
                .FirstOrDefault();
            var company = db.MCompany.Find(user.MUsers.CompanyId);
            var bank = db.MBank.Where(i => i.Id == company.EBankCode).FirstOrDefault();

            ViewBag.bank = bank;
            ViewBag.company = company;

            return View();
        }



    }
}
