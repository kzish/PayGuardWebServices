using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PayGuard.Models;
using PayGuardClient.Models;

namespace PayGuardClient.Controllers
{
    [Route("Users")]
    [Authorize(Roles = "default_user,manage_users")]
    public class UsersController : Controller
    {

        private dbContext db = new dbContext();
        private HostingEnvironment host;


        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(HostingEnvironment host, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.host = host;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        [HttpGet("AllUsers")]
        [HttpGet("")]
        public IActionResult AllUsers()
        {
            ViewBag.title = "All Users";
            return View();
        }

        [HttpGet("ajaxAllUsers")]
        public IActionResult ajaxAllUsers()
        {
            ViewBag.title = "All Users";

            var current_user = db.AspNetUsers
                   .Where(i => i.Email == User.Identity.Name)
                   .Include(i => i.MUsers)
                   .FirstOrDefault();
            //
            var users = db.MUsers
                .Where(i => i.CompanyId == current_user.MUsers.CompanyId)//this company
                .ToList();
            //
            ViewBag.users = users;
            return View();
        }

        [HttpGet("CreateUser")]
        public IActionResult CreateUser()
        {
            ViewBag.title = "Create User";
            return View();
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(string Name, String Surname, string LoginEmail, String LoginPassword)
        {
            try
            {

                ViewBag.title = "Create User";

                ViewBag.name = Name;
                ViewBag.surname = Surname;
                ViewBag.login_email = LoginEmail;
                ViewBag.login_password = LoginPassword;

                var current_user = db.AspNetUsers
                    .Where(i => i.Email == User.Identity.Name)
                    .Include(i => i.MUsers)
                    .FirstOrDefault();

                var company = db.MCompany.Find(current_user.MUsers.CompanyId);

                var new_id_user = new IdentityUser() { Email = LoginEmail, PasswordHash = LoginPassword, UserName = LoginEmail };
                await userManager.CreateAsync(new_id_user, LoginPassword);
                var user = new MUsers();
                user.Name = Name;
                user.Surname = Surname;
                user.AspNetUserId = new_id_user.Id;
                user.CompanyId = company.Id;
                user.DefaultUser = false;
                db.MUsers.Add(user);
                await db.SaveChangesAsync();
                TempData["msg"] = $"Saved";
                TempData["type"] = "success";
                return RedirectToAction("AllUsers");
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



        [HttpGet("EditUser/{asp_net_user_id}")]
        public async Task<IActionResult> EditUser(string asp_net_user_id)
        {
            try
            {
                ViewBag.title = "Edit User";
                //
                var user = db.AspNetUsers
                    .Include(i => i.MUsers)
                    .Where(i => i.Id == asp_net_user_id)
                    .FirstOrDefault();
                //
                var identity_user = await userManager.FindByIdAsync(asp_net_user_id);
                var roles = new UserRoles();
                roles.bulk_payments = await userManager.IsInRoleAsync(identity_user, "bulk_payments");
                roles.debit_orders = await userManager.IsInRoleAsync(identity_user, "debit_orders");
                roles.manage_users = await userManager.IsInRoleAsync(identity_user, "manage_users");

                ViewBag.user = user;
                ViewBag.roles = roles;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.bulk_payment = new MUsers();
                return RedirectToAction("AllUsers");
            }
            return View();
        }


        [HttpPost("EditUser")]
        public async Task<IActionResult> EditUser(string asp_net_user_id, string name, string surname, UserRoles roles)
        {
            try
            {
                ViewBag.title = "Edit User";
                //
                //var asp_net_user = db.AspNetUsers.Find(asp_net_user_id);
                var identity_user = await userManager.FindByIdAsync(asp_net_user_id);
                var existing_user = db.MUsers.Find(asp_net_user_id);
                existing_user.Name = name;
                existing_user.Surname = surname;
                //
                if (!await roleManager.RoleExistsAsync("bulk_payments")) await roleManager.CreateAsync(new IdentityRole("bulk_payments"));
                if (!await roleManager.RoleExistsAsync("debit_orders")) await roleManager.CreateAsync(new IdentityRole("debit_orders"));
                if (!await roleManager.RoleExistsAsync("manage_users")) await roleManager.CreateAsync(new IdentityRole("manage_users"));
                //
                if (roles.bulk_payments) await userManager.AddToRoleAsync(identity_user, "bulk_payments");
                if (roles.debit_orders) await userManager.AddToRoleAsync(identity_user, "debit_orders");
                if (roles.manage_users) await userManager.AddToRoleAsync(identity_user, "manage_users");
                //
                if (!roles.bulk_payments) await userManager.RemoveFromRoleAsync(identity_user, "bulk_payments");
                if (!roles.debit_orders) await userManager.RemoveFromRoleAsync(identity_user, "debit_orders");
                if (!roles.manage_users) await userManager.RemoveFromRoleAsync(identity_user, "manage_users");


                await db.SaveChangesAsync();
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
                return RedirectToAction("AllUsers");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.StackTrace;
                TempData["type"] = "error";
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
                return RedirectToAction("EditUser", "Users", new { asp_net_user_id = asp_net_user_id });
            }


        }


        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(string asp_net_user_id)
        {
            try
            {
                var id_user = await userManager.FindByIdAsync(asp_net_user_id);
                await userManager.DeleteAsync(id_user);
                TempData["msg"] = "Deleted";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
            }
            return RedirectToAction("AllUsers");
        }

        /// <summary>
        /// reset the password for the user
        /// </summary>
        /// <param name="asp_net_user_id"></param>
        /// <returns></returns>

        [HttpPost("ResetPasswordForUser")]
        public async Task<IActionResult> ResetPasswordForUser(string asp_net_user_id)
        {
            try
            {
                var id_user = await userManager.FindByIdAsync(asp_net_user_id);
                var token=await userManager.GeneratePasswordResetTokenAsync(id_user);
                var result = await userManager.ResetPasswordAsync(id_user, token, "Softrite#99");
                if(result.Succeeded)
                {
                    TempData["msg"] = "Password Reset Success";
                    TempData["type"] = "success";
                    return RedirectToAction("AllUsers");
                }
                else
                {
                    TempData["msg"] = string.Join(" ", result.Errors.Select(i=>i.Description).ToList());
                    TempData["type"] = "error";
                    return RedirectToAction("EditUser", "Users", new { asp_net_user_id });
                }
               
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                return RedirectToAction("EditUser", "Users", new { asp_net_user_id });
            }
        }


    }
}
