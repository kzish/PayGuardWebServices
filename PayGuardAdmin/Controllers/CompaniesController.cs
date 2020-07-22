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
            var companies = db.MCompany.Include(i => i.EBankCodeNavigation).ToList();
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
        public async Task<IActionResult> CreateCompany(MCompany company, string LoginEmail, string LoginPassword, string Name, string Surname)
        {
            try
            {
                //check company name exists already
                var company_name_exists = db.MCompany.Where(i => i.CompanyName == company.CompanyName).Any();
                if (company_name_exists)
                {
                    TempData["msg"] = $"{company.CompanyName} exists already";
                    TempData["type"] = "error";
                    return View();
                }
                //create identity user
                var new_identity_user = new IdentityUser();
                new_identity_user.Email = LoginEmail;
                new_identity_user.UserName = new_identity_user.Email;
                await userManager.CreateAsync(new_identity_user, LoginPassword);//create user
                //create company role
                if (!await roleManager.RoleExistsAsync("company"))//company role
                {
                    var role = new IdentityRole("company");
                    await roleManager.CreateAsync(role);
                }
                if (!await roleManager.RoleExistsAsync("default_user"))//default user role
                {
                    var role = new IdentityRole("default_user");
                    await roleManager.CreateAsync(role);
                }
                //add user to company role
                await userManager.AddToRoleAsync(new_identity_user, "company");
                await userManager.AddToRoleAsync(new_identity_user, "default_user");
                //create company
                db.MCompany.Add(company);
                await db.SaveChangesAsync();
                //create system user and link to identity user
                var new_system_user = new MUsers();
                new_system_user.AspNetUserId = new_identity_user.Id;
                new_system_user.Name = Name;
                new_system_user.Surname = Surname;
                new_system_user.CompanyId = company.Id;
                new_system_user.DefaultUser = true;//set this to be the default user
                //save new system user
                db.MUsers.Add(new_system_user);
                await db.SaveChangesAsync();
                //
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


                var system_user = db.MUsers.Where(i => i.CompanyId == id).FirstOrDefault();
                var asp_net_user = db.AspNetUsers.Find(system_user.AspNetUserId);


                ViewBag.asp_net_user = asp_net_user;
                ViewBag.system_user = system_user;

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

        /// <summary>
        /// resets the password for the default user
        /// </summary>
        /// <param name="company_id"></param>
        /// <returns></returns>
        [HttpPost("ResetCompanyPasswordDefaultUser")]
        public async Task<IActionResult> ResetCompanyPasswordDefaultUser(int company_id)
        {
            ViewBag.title = "Change Password";

            try
            {
                var new_password = "Softrite#99";
                var company_user = db.MUsers
                    .Where(i=>i.CompanyId==company_id&&i.DefaultUser)
                    .Include(i=>i.AspNetUser)
                    .FirstOrDefault();
                var id_user = await userManager.FindByEmailAsync(company_user.AspNetUser.Email);
                var token = await userManager.GeneratePasswordResetTokenAsync(id_user);
                var result = await userManager.ResetPasswordAsync(id_user, token, new_password);
                if (result.Succeeded)
                {
                    var user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                    ViewBag.user = user;
                    TempData["msg"] = "Password changed";
                    TempData["type"] = "success";
                }
                else
                {
                    TempData["msg"] = String.Join(" ", result.Errors.Select(i => i.Description).ToList());
                    TempData["type"] = "error";
                }
                return RedirectToAction("AllCompanies");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                return RedirectToAction("EditCompany", "Companies", new { id = company_id });
            }
        }

    }
}
