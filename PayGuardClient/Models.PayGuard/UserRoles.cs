using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayGuard.Models
{
    /// <summary>
    /// the roles for a user
    /// </summary>
    public class UserRoles
    {
        public bool bulk_payments { get; set; }
        public bool debit_orders { get; set; }
        public bool manage_users { get; set; }
    }
}
