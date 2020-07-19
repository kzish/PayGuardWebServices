using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeedLinkApi.Models;
using System.ServiceModel;
using System.Net;
using WS;

namespace SpeedLinkApi.Controllers
{
    [Route("speedlink/v1")]
    //[Authorize]
    [Authorize(AuthenticationSchemes = "Bearer")]//allow only authorized by Bearer
    public class ProcessController : Controller
    {

        private dbContext db = new dbContext();

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        public ProcessController()
        {

        }
     

        /// <summary>
        /// return the soap client
        /// </summary>
        /// <returns></returns>
        [ApiExplorerSettings(IgnoreApi = true)]
        public static WS.AppIntegrationMgt_PortClient GetClient()
        {
            //configure binding
            var myBinding = new BasicHttpBinding(BasicHttpSecurityMode.TransportCredentialOnly);
            myBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            //configure end point
            var endPoint = new EndpointAddress("http://196.44.191.67:7047/AppIntegration/WS/Speedlink%20Cargo%20Pvt%20Ltd/Codeunit/AppIntegrationMgt");
            //declare client
            WS.AppIntegrationMgt_PortClient sc_client = new WS.AppIntegrationMgt_PortClient(myBinding, endPoint);
            //sc_client.ClientCredentials.Windows.ClientCredential = new NetworkCredential("Webuser", "XYlPy4s+XubkkZXeL+6OtMmEDSw2GdiBSEXthCjB0v8=");
            sc_client.ClientCredentials.UserName.UserName = "Webuser";
            sc_client.ClientCredentials.UserName.Password = "XYlPy4s+XubkkZXeL+6OtMmEDSw2GdiBSEXthCjB0v8=";
            return sc_client;
        }


        /// <summary>
        /// status of a specific job
        /// </summary>
        /// <param name="customerNo"></param>
        /// <param name="jobNo"></param>
        /// <returns></returns>
        [HttpPost("JobStatusRequest")]
        public async Task<JsonResult> ManageJobStatusUpdateRequest(string customerNo, string jobNo)
        {
            if (jobNo.Length >= 11) jobNo = jobNo.Substring(0, 10);//take only the first ten chars
            try
            {
                var client = GetClient();
                Response jobUpdates = new Response();
                ManageJobStatusUpdateRequest request = new ManageJobStatusUpdateRequest(jobUpdates, customerNo, jobNo);
                var response = await client.ManageJobStatusUpdateRequestAsync(request);
                if (response.return_value)
                {
                    //save stats
                    var mclient = db.MClient.Where(i => i.CustomerNumber == customerNo).FirstOrDefault();
                    var usage = new MJobStatusRequestsStats();
                    usage.AspNetUserId = mclient.Id;
                    usage.Date = DateTime.Now;
                    db.MJobStatusRequestsStats.Add(usage);
                    await db.SaveChangesAsync();

                    return Json(new
                    {
                        res = "ok",
                        data = response.jobUpdates.JobItems[0],
                    });
                }
                else
                {
                    return Json(new
                    {
                        res = "err",
                        msg = response.jobUpdates.ResponseMessage[0],
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }


        /// <summary>
        /// All open jobs
        /// </summary>
        /// <param name="customerNo"></param>
        /// <returns></returns>
        [HttpPost("JobsRequest")]
        public async Task<JsonResult> ManageCustJobsUpdateRequest(string customerNo)
        {
            try
            {
                var client = GetClient();
                Response1 customerJobsUpdates = new Response1();
                ManageCustJobsUpdatesRequest request = new ManageCustJobsUpdatesRequest(customerJobsUpdates, customerNo);
                var response = await client.ManageCustJobsUpdatesRequestAsync(request);
                if (response.return_value)
                {
                    return Json(new
                    {
                        res = "ok",
                        data = response.customerJobsUpdates.UpdateList,
                    });
                }
                else
                {
                    return Json(new
                    {
                        res = "err",
                        msg = response.customerJobsUpdates.ResponseMessage[0],
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }

        /// <summary>
        /// All open jobs which are still in progress or pending
        /// </summary>
        /// <param name="customerNo"></param>
        /// <returns></returns>
        [HttpPost("OpenJobsRequest")]
        public async Task<JsonResult> ManageCustOpenJobsRequest(string customerNo)
        {
            try
            {
                var client = GetClient();
                Response2 customerOpenJobs = new Response2();
                ManageCustOpenJobsRequest request = new ManageCustOpenJobsRequest(customerOpenJobs, customerNo);
                var response = await client.ManageCustOpenJobsRequestAsync(request);
                if (response.return_value)
                {
                    return Json(new
                    {
                        res = "ok",
                        data = response.customerOpenJobs.JobList,
                    });
                }
                else
                {
                    return Json(new
                    {
                        res = "err",
                        msg = response.customerOpenJobs.ResponseMessage[0],
                    });
                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }


        [HttpPost("GetCustomerName")]
        public async Task<JsonResult> GetCustomerName(string customerNo)
        {
            try
            {
                var client = GetClient();
                GetCustomerName request = new GetCustomerName();
                request.customerNo = customerNo;
                request.result = "";
                var response = await client.GetCustomerNameAsync(request);
                if (response.return_value)
                {
                    return Json(new
                    {
                        res = "ok",
                        data = response.result,
                    });
                }
                else
                {
                    return Json(new
                    {
                        res = "err",
                        msg = response.result,
                    });
                }

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }


        

    }
}
