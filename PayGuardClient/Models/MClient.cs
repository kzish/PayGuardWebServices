using System;
using System.Collections.Generic;

namespace PayGuardClient.Models
{
    public partial class MClient
    {
        public string AspNetUserId { get; set; }
        public string ClientOrganizationName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public int? EBankCode { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankBranchCode { get; set; }

        public virtual MBank EBankCodeNavigation { get; set; }
    }
}
