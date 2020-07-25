using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PayGuardClient.Models;

namespace PayGuardClient.Controllers
{
    [Route("DebitOrders")]
    [Authorize(Roles = "default_user,debit_orders")]
    public class DebitOrdersController : Controller
    {

        private dbContext db = new dbContext();
        private HostingEnvironment host;

        public DebitOrdersController(HostingEnvironment host)
        {
            this.host = host;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        [HttpGet("AllDebitOrders")]
        [HttpGet("")]
        public IActionResult AllDebitOrders()
        {
            ViewBag.title = "All DebitOrders";
            return View();
        }

        [HttpGet("ajaxAllDebitOrders")]
        public IActionResult ajaxAllDebitOrders()
        {
            var user = db.AspNetUsers
                .Where(i => i.Email == User.Identity.Name)
                .Include(i => i.MUsers)
                .FirstOrDefault();

            ViewBag.title = "All DebitOrders";
            var debit_orders = db.MDebitOrders
                .Where(i => i.CompanyId == user.MUsers.CompanyId)//for this company
                .Include(i => i.MDebitOrdersClients)//include clients
                .ToList();
            ViewBag.debit_orders = debit_orders;
            return View();
        }

        [HttpGet("CreateDebitOrders")]
        public IActionResult CreateDebitOrders()
        {
            ViewBag.title = "Create DebitOrder";
            return View();
        }

        /// <summary>
        /// fetch all banks async and display to the client
        /// </summary>
        /// <returns></returns>

        [HttpGet("ajaxAllBanks")]
        public IActionResult ajaxAllBanks()
        {
            //only banks online
            var banks = db.MBank.Where(i => i.Online).ToList();
            ViewBag.banks = banks;
            return View();
        }

        /// <summary>
        /// fetch all ajaxAllDebitOrderClients
        /// </summary>
        /// <returns></returns>
        [HttpGet("ajaxAllDebitOrderClients/{debit_order_id}")]
        public IActionResult ajaxAllDebitOrderClients(int debit_order_id)
        {
            var clients = db.MDebitOrdersClients
                .Where(i => i.DebitOrderId == debit_order_id)
                .Include(i => i.EClientBank)
                .ToList();
            ViewBag.clients = clients;
            return View();
        }


        [HttpPost("CreateDebitOrders")]
        public async Task<IActionResult> CreateDebitOrders(string reference, IFormFile file)
        {
            try
            {
                ViewBag.title = "Create DebitOrder";
                //temp file
                var file_name = Guid.NewGuid().ToString();
                var file_path = host.WebRootPath + "/Uploads/" + file_name + ".csv";
                using (var stream = new FileStream(file_path, FileMode.CreateNew))
                {
                    await file.CopyToAsync(stream);
                    stream.Dispose();
                }
                //read uploaded data
                var debit_order_data = System.IO.File.ReadAllLines(file_path);
                //delete the file
                System.IO.File.Delete(file_path);
                //
                var asp_net_user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                var system_user = db.MUsers.Where(i => i.AspNetUserId == asp_net_user.Id).FirstOrDefault();
                var company = db.MCompany
                    .Where(i => i.Id == system_user.CompanyId)//this company
                    .Include(i => i.EBankCodeNavigation)//include bank
                    .FirstOrDefault();
                //get session user
                var user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                //create bulk payment header
                var debit_order = new MDebitOrders();
                debit_order.Date = DateTime.Now;
                debit_order.Reference = reference;
                debit_order.CompanyId = company.Id;
                debit_order.AspNetUserId = asp_net_user.Id;
                debit_order.BankCode = company.EBankCodeNavigation.SwiftCode;
                debit_order.AccountNumber = company.BankAccountNumber;
                db.MDebitOrders.Add(debit_order);
                await db.SaveChangesAsync();
                //create debit_order Clients
                var debit_order_clients = new List<MDebitOrdersClients>();
                int num_errors = 0;
                int row_index = 0;
                foreach (var line in debit_order_data)
                {
                    if (row_index == 0)
                    {
                        row_index++;
                        continue;//skip the first row it contains header information
                    }
                    try
                    {
                        var debit_order_client = new MDebitOrdersClients();
                        //
                        debit_order_client.ClientName = line.Split(',')[0];
                        if (string.IsNullOrEmpty(debit_order_client.ClientName))
                        {
                            num_errors++;
                            continue;
                        }
                        //
                        int EClientBankId = 0;
                        int.TryParse(line.Split(',')[1], out EClientBankId);
                        //ensure bank is online
                        var is_bank_online = db.MBank.Where(i => i.Online && i.Id == EClientBankId).Any();
                        debit_order_client.EClientBankId = EClientBankId;
                        if (EClientBankId == 0 || !is_bank_online)
                        {
                            num_errors++;
                            continue;
                        }
                        //
                        debit_order_client.ClientAccountNumber = line.Split(',')[2];
                        if (string.IsNullOrEmpty(debit_order_client.ClientAccountNumber))
                        {
                            num_errors++;
                            continue;
                        }
                        //
                        decimal ClientAmount = 0;
                        decimal.TryParse(line.Split(',')[3], out ClientAmount);
                        debit_order_client.ClientAmount = ClientAmount;
                        if (debit_order_client.ClientAmount == 0)
                        {
                            num_errors++;
                            continue;
                        }
                        //
                        debit_order_client.DebitOrderId = debit_order.Id;
                        debit_order_clients.Add(debit_order_client);
                    }
                    catch (Exception ex)
                    {
                        num_errors++;
                    }
                }
                //
                db.MDebitOrdersClients.AddRange(debit_order_clients);
                await db.SaveChangesAsync();
                TempData["msg"] = $"You have {num_errors} errors and {debit_order_clients.Count()} records";
                TempData["type"] = "warning";
                return RedirectToAction("EditDebitOrders", "DebitOrders", new { id = debit_order.Id });

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



        [HttpGet("EditDebitOrders/{id}")]
        public IActionResult EditDebitOrders(int id)
        {
            try
            {
                ViewBag.title = "Edit DebitOrder";
                var debit_order = db.MDebitOrders.Find(id);
                ViewBag.debit_order = debit_order;
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                ViewBag.debit_order = new MDebitOrders();
                return RedirectToAction("AllDebitOrders");
            }
            return View();
        }


        [HttpPost("EditDebitOrders")]
        public async Task<IActionResult> EditDebitOrders(int Id, string reference, IFormFile file)
        {
            try
            {
                ViewBag.title = "Edit DebitOrders";
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
                    var debit_order_data = System.IO.File.ReadAllLines(file_path);
                    //delete the file
                    System.IO.File.Delete(file_path);

                    //remove all previous Clients
                    var old_Clients = db.MDebitOrdersClients.Where(i => i.DebitOrderId == Id).ToList();
                    if (old_Clients.Count > 0)
                    {
                        db.MDebitOrdersClients.RemoveRange(old_Clients);
                        await db.SaveChangesAsync();
                    }
                    //add newly uploaded Clients
                    int num_errors = 0;
                    int valid_records = 0;
                    bool invalid_bank_codes_exist = false;
                    bool invalid_amounts_exist = false;
                    //
                    var valid_bank_ids = db.MBank.Select(i => i.Id).ToList();
                    //
                    int row_number = 0;
                    foreach (var line in debit_order_data)
                    {
                        try
                        {
                            if (row_number == 0)
                            {
                                row_number++;
                                continue;//skip first row because it is the headings
                            }

                            var RecipientName = line.Split(',')[0];
                            var RecipientAccountNumber = line.Split(',')[2];
                            //
                            int ERecipientBankId = 0;
                            int.TryParse(line.Split(',')[1], out ERecipientBankId);
                            if (!valid_bank_ids.Contains(ERecipientBankId))
                            {
                                num_errors++;
                                invalid_bank_codes_exist = true;
                                continue;//invalid bank id continue, skip record
                            }
                            //
                            decimal RecipientAmount = decimal.Zero;
                            decimal.TryParse(line.Split(',')[3], out RecipientAmount);
                            if (RecipientAmount <= decimal.Zero)
                            {
                                num_errors++;
                                invalid_amounts_exist = true;
                                continue;//skip this record invalid amount
                            }

                            var debit_order_client = new MDebitOrdersClients();
                            debit_order_client.ClientName = RecipientName;
                            debit_order_client.EClientBankId = ERecipientBankId;
                            debit_order_client.ClientAccountNumber = RecipientAccountNumber;
                            debit_order_client.ClientAmount = RecipientAmount;
                            debit_order_client.DebitOrderId = Id;
                            db.MDebitOrdersClients.Add(debit_order_client);
                            valid_records++;
                        }
                        catch (Exception ex)
                        {
                            num_errors++;
                        }
                    }
                    ViewBag.errors = string.Empty;
                    if (invalid_amounts_exist) ViewBag.errors += "Records with invalid amounts are skipped<br/>";
                    if (invalid_bank_codes_exist) ViewBag.errors += "Records with invalid bank codes are skipped<br/>";


                    TempData["msg"] = $"You have {num_errors} errors and {valid_records} records";
                    TempData["type"] = "warning";
                }

                //
                var asp_net_user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                var system_user = db.MUsers.Where(i => i.AspNetUserId == asp_net_user.Id).FirstOrDefault();
                var company = db.MCompany.Where(i => i.Id == system_user.CompanyId).FirstOrDefault();
                //get session user
                var user = db.AspNetUsers.Where(i => i.Email == User.Identity.Name).FirstOrDefault();
                //update reference
                var debit_order = db.MDebitOrders.Find(Id);
                debit_order.Reference = reference;
                db.Entry(debit_order).State = EntityState.Modified;
                await db.SaveChangesAsync();
                //
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.StackTrace;
                TempData["type"] = "error";
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
            }
            return RedirectToAction("EditDebitOrders", "DebitOrders", new { id = Id });

        }


        [HttpPost("DeleteDebitOrders")]
        public async Task<IActionResult> DeleteDebitOrders(int id)
        {
            try
            {
                var DebitOrder = db.MDebitOrders.Find(id);
                db.MDebitOrders.Remove(DebitOrder);
                await db.SaveChangesAsync();
                TempData["msg"] = "Saved";
                TempData["type"] = "success";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
            }
            return RedirectToAction("AllDebitOrders");
        }


        /// <summary>
        /// debit orders are submitted to rbz
        /// convert a Debit order to a PayGuard.Models.Debit order model to send to rbz
        /// </summary>
        /// <param name="debit_order_id"></param>
        /// <returns></returns>
        [HttpPost("SubmitDebitOrder")]
        public async Task<IActionResult> SubmitDebitOrder(int debit_order_id)
        {
            try
            {
                //bulk payment and Clients
                var debit_order = db.MDebitOrders
                    .Where(i => i.Id == debit_order_id)//this debit order
                    .Include(i => i.MDebitOrdersClients)//fetch Clients
                    .Include(i => i.Company)//fetch company
                    .FirstOrDefault();
                //
                var senders_company = db.MCompany.Find(debit_order.CompanyId);
                var senders_bank = db.MBank.Find(senders_company.EBankCode);
                //
                var http_client = new HttpClient();
                var token = Globals.GetAccessToken(Globals.rbz_end_point);
                if (string.IsNullOrEmpty(token))
                {
                    TempData["msg"] = "Error fetching token";
                    TempData["type"] = "error";
                    return RedirectToAction("AllDebitOrders");
                }
                //add token
                http_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                //convert model to PayGuard.Models.MdebitOrder to send to rbz
                var debit_order_ = new PayGuard.Models.MDebitOrders();
                debit_order_.Date = debit_order.Date;
                debit_order_.Reference = debit_order.Reference;
                debit_order_.CompanyId = debit_order.CompanyId;
                debit_order_.AspNetUserId = debit_order.AspNetUserId;
                debit_order_.DateLastSubmitted = DateTime.Now;
                debit_order_.AccountNumber = debit_order.AccountNumber;
                debit_order_.BankCode = debit_order.BankCode;
                //add the clients
                foreach(var item in debit_order.MDebitOrdersClients)
                {
                    var client = new PayGuard.Models.MDebitOrdersClients();
                    client.ClientName = item.ClientName;
                    client.ClientBankSwiftCode = db.MBank.Find(item.EClientBankId).SwiftCode;
                    client.ClientAccountNumber = item.ClientAccountNumber;
                    client.ClientAmount = item.ClientAmount;
                    client.DebitOrderId = item.DebitOrderId;
                    debit_order_.MDebitOrdersClients.Add(client);
                }
                //
                var debit_order_json = JsonConvert.SerializeObject(debit_order_, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                var http_content = new StringContent(debit_order_json, Encoding.UTF8, "application/json");
                //upload DebitOrder to clients bank                
                var post_response = await http_client.PostAsync($"{Globals.rbz_end_point}/PayGuard/v1/UploadDebitOrder", http_content)
                    .Result
                    .Content
                    .ReadAsStringAsync();
                //
                dynamic response = JsonConvert.DeserializeObject(post_response);
                if ((string)response.res == "ok")
                {
                    debit_order.DateLastSubmitted = DateTime.Now;
                    await db.SaveChangesAsync();
                    TempData["msg"] = (string)response.data;
                    TempData["type"] = "success";
                }
                else
                {
                    TempData["msg"] = (string)response.msg;
                    TempData["type"] = "error";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                TempData["type"] = "error";
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
            }
            return RedirectToAction("AllDebitOrders");
        }

        /// <summary>
        /// view the errors of the bulk payments
        /// </summary>
        /// <param name="bank_swift_code"></param>
        /// <returns></returns>
        [HttpGet("ViewErrors/{bank_swift_code}")]
        public IActionResult ViewErrors(string bank_swift_code)
        {
            ViewBag.title = "View Errors";
            ViewBag.bank_swift_code = bank_swift_code;
            return View();
        }

        [HttpGet("ajaxViewErrors/{bank_swift_code}")]
        public async Task<IActionResult> ajaxViewErrors(string bank_swift_code)
        {
            try
            {
                //
                var asp_net_user = db.AspNetUsers
                    .Include(i => i.MUsers)
                    .Where(i => i.Email == User.Identity.Name)
                    .FirstOrDefault()
                    ;
                //
                var company = db.MCompany.Find(asp_net_user.MUsers.CompanyId);
                var http_client = new HttpClient(Globals.GetHttpHandler());
                var access_token = Globals.GetAccessToken(Globals.rbz_end_point);
                //
                if (string.IsNullOrEmpty(access_token))
                {
                    TempData["msg"] = "Failed to fetch access token";
                    TempData["type"] = "error";
                    return View();
                }
                //
                http_client.DefaultRequestHeaders.Add("Authorization", $"Bearer {access_token}");
                var request_errors = await http_client.GetAsync($"{Globals.rbz_end_point}/PayGuard/v1/ViewDebitOrderErrors?bank_swift_code={bank_swift_code}&sender_account={company.BankAccountNumber}")
                    .Result
                    .Content
                    .ReadAsStringAsync();
                //
                dynamic request_errors_json = JsonConvert.DeserializeObject(request_errors);
                var errors = new List<PayGuard.Models.MAccountCreditInstructionsFailed>();
                if (request_errors_json.res == "ok")
                {
                    foreach (var item in request_errors_json.data)
                    {
                        var error = new PayGuard.Models.MAccountCreditInstructionsFailed();
                        error.Date = item.date;
                        error.RecipientBankCode = item.recipientBankCode;
                        error.RecipientAccountNumber = item.recipientAccountNumber;
                        error.SenderBankCode = item.senderBankCode;
                        error.SenderAccountNumber = item.senderAccountNumber;
                        error.Amount = item.amount;
                        error.Reference = item.reference;
                        errors.Add(error);
                    }
                    ViewBag.errors = errors;
                }
                else
                {
                    TempData["msg"] = "Failed to fetch access token";
                    TempData["type"] = "error";
                    ViewBag.errors = request_errors;
                }
                //MAccountCreditInstructionsFailed
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }

            return View();
        }

    }
}
