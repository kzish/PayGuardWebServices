using Newtonsoft.Json;
using PayGuardRbzInterface.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

public class Globals
{
    public static string client_id = "test_user";
    public static string client_secret = "12345";
    public static string auth_end_point = "http://localhost/Auth";



    /// <summary>
    /// create and return an http handler to bypass certificate checks
    /// </summary>
    /// <returns></returns>
    public static HttpClientHandler GetHttpHandler()
    {
        var handler = new HttpClientHandler();
        handler.ClientCertificateOptions = ClientCertificateOption.Manual;
        handler.ServerCertificateCustomValidationCallback =
            (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            };
        return handler;
    }


    /// <summary>
    /// fetch the access token 
    /// </summary>
    /// <param name="bank_end_point"></param>
    /// <returns></returns>
    public static string GetAccessToken(string bank_end_point)
    {
        try
        {
            //get access token
            var http_client = new HttpClient();
            var request_token = http_client.GetAsync($"{bank_end_point}/PayGuard/v1/RequestToken?clientID={Globals.client_id}&clientSecret={Globals.client_secret}")
                .Result
                .Content
                .ReadAsStringAsync()
                .Result;
            if (string.IsNullOrEmpty(request_token))
            {
                var error = new MErrors() { Date = DateTime.Now, Data1 = "GetAccessToken", Data2 = "failed to fetch access token" };
                using (var db = new dbContext())
                {
                    db.MErrors.Add(error);
                    db.SaveChanges();
                    db.Dispose();
                }
                return "";
            }
            //
            dynamic token = JsonConvert.DeserializeObject(request_token);
            string access_token = token.access_token;
            return access_token;
        }catch(Exception ex)
        {
            return "";
        }
    }


    //clearing account
    /// <summary>
    /// debit the banks suspense account
    /// </summary>
    /// <param name="account_number"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static bool DebitSuspenseAccount(string suspense_account_number, decimal amount)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            using (var db = new dbContext())
            {
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
                db.Dispose();
            }
            return false;
        }
    }



    /// <summary>
    /// credit the banks suspense account
    /// </summary>
    /// <param name="account_number"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static bool CreditSuspenseAccount(string suspense_account_number, decimal amount)
    {
        try
        {
            return true;
        }
        catch (Exception ex)
        {
            using (var db = new dbContext())
            {
                var error = new MErrors() { Date = DateTime.Now, Data1 = ex.Message, Data2 = ex.StackTrace };
                db.MErrors.Add(error);
                db.SaveChanges();
                db.Dispose();
            }
            return false;
        }
    }


}
