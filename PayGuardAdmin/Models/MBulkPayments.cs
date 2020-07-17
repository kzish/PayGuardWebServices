using System;
using System.Collections.Generic;

namespace PayGuardAdmin.Models
{
    public partial class MBulkPayments
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public int CompanyId { get; set; }
        public string AspNetUserId { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
        public virtual MCompany Company { get; set; }
    }
}
