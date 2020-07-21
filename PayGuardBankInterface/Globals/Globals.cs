using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using PayGuardBankInterface.Models;

public class Globals
{
    public static string client_id = "test_user";
    public static string client_secret = "12345";
    public static string rbz_end_point = "https://localhost:44315";
    public static string auth_end_point = "http://localhost/Auth";



    /// <summary>
    /// debit the payers account
    /// </summary>
    /// <param name="account_number"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    //[HttpPost("DebitAccount")]
    public static bool DebitAccount(string account_number, decimal amount)
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
    /// credit the recipient account
    /// </summary>
    /// <param name="account_number"></param>
    /// <param name="amount"></param>
    /// <returns></returns>
    public static bool CreditAccount(string account_number, decimal amount)
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
