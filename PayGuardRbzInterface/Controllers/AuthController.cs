using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PayGuardRbzInterface.Controllers
{
    [Route("PayGuard/v1")]
    [Authorize]
    public class AuthController : Controller
    {
        /// <summary>
        /// requerst access token before accessing any method
        /// Add { Bearer <access_token> } in header request of each subsequent request
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="clientSecret"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("RequestToken")]
        public async Task<IActionResult> RequestToken(string clientID = "test_user", string clientSecret = "12345")
        {
            try
            {
                string identity_server_end_point = Globals.auth_end_point;

                DiscoveryClient discoveryClient = new DiscoveryClient(identity_server_end_point);

                // Accept the configuration even if the issuer and endpoints don't match
                discoveryClient.Policy.ValidateIssuerName = false;
                discoveryClient.Policy.ValidateEndpoints = false;

                var disco = await discoveryClient.GetAsync();
                var tokenClient = new TokenClient(
                    address: disco.TokenEndpoint,
                    clientId: clientID,
                    clientSecret: clientSecret);
                var tokenResponse = await tokenClient.RequestClientCredentialsAsync("api");
                if (tokenResponse.IsError)
                {
                    return Json(tokenResponse.Exception);
                }
                else
                {
                    return Json(tokenResponse.Json);
                }
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }


      



    }
}
