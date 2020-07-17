using System;
using System.Collections.Generic;

namespace PayGuardClient.Models
{
    public partial class MUsers
    {
        public string AspNetUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CompanyId { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
        public virtual MCompany Company { get; set; }
    }
}
