using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayGuardAdmin.Models;

namespace PayGuardAdmin.Controllers
{
    [Route("Clients")]
    [Authorize(Roles = "admin")]
    public class ClientsController : Controller
    {

        private dbContext db = new dbContext();


        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public ClientsController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
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

        [HttpGet("AllClients")]
        [HttpGet("")]
        public IActionResult AllClients()
        {
            ViewBag.title = "All Clients";
            return View();
        }

        [HttpGet("ajaxAllClients")]
        public IActionResult ajaxAllClients()
        {
            ViewBag.title = "All Clients";
            var clients = db.MClient.ToList();
            ViewBag.clients = clients;
            return View();
        }

        [HttpGet("CreateClient")]
        public IActionResult CreateClient()
        {
            ViewBag.title = "Create Client";
            var banks = db.MBank.ToList();
            ViewBag.banks = banks;
            return View();
        }


        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient(MClient Client, string LoginEmail, string LoginPassword)
        {
            try
            {

                //check unique organization name
                var organization_name_exists = db.MClient.Where(i => i.ClientOrganizationName == Client.ClientOrganizationName).Any();
                if (organization_name_exists)
                {
                    TempData["msg"] = "This organition name exists already";
                    TempData["type"] = "error";
                    return View();
                }

                //first create a user
                var new_user = new IdentityUser();
                new_user.Email = LoginEmail;
                new_user.UserName = new_user.Email;
                await userManager.CreateAsync(new_user, LoginPassword);//create user
                //create client role
                bool x = await roleManager.RoleExistsAsync("client");
                if (!x)
                {
                    var role = new IdentityRole("client");
                    await roleManager.CreateAsync(role);
                }
                await userManager.AddToRoleAsync(new_user, "client");//add user to client role
                //create client
                Client.AspNetUserId = new_user.Id;//link client account to the aspnet user
                db.MClient.Add(Client);
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
            return RedirectToAction("AllClients");
        }



        [HttpGet("EditClient/{id}")]
        public IActionResult EditClient(string id)
        {
            try
            {
                ViewBag.title = "Edit Client";

                var user = db.AspNetUsers.Find(id);
                var client = db.MClient.Find(id);

                var banks = db.MBank.ToList();
                ViewBag.client = client;
                ViewBag.user = user;
                ViewBag.banks = banks;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.client = new MClient();
                return RedirectToAction("AllClients");
            }
            return View();
        }

        [HttpPost("EditClient")]
        public async Task<IActionResult> EditClient(MClient Client)
        {
            try
            {
                ViewBag.title = "Edit Client";
                db.Entry(Client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await db.SaveChangesAsync();
                ViewBag.Client = Client;
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.Client = new MClient();
                return RedirectToAction("EditClient", "Clients", new { id = Client.AspNetUserId });
            }

            return RedirectToAction("AllClients");
        }


        [HttpPost("DeleteClient")]
        public async Task<IActionResult> DeleteClient(string id)
        {
            try
            {
                var Client = db.MClient.Find(id);
                db.MClient.Remove(Client);
                await db.SaveChangesAsync();
                ViewBag.Client = Client;
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
            }
            return RedirectToAction("AllClients");
        }



    }
}
