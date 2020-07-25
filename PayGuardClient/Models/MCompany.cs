﻿using System;
using System.Collections.Generic;

namespace PayGuardClient.Models
{
    public partial class MCompany
    {
        public MCompany()
        {
            MBulkPayments = new HashSet<MBulkPayments>();
            MDebitOrders = new HashSet<MDebitOrders>();
            MUsers = new HashSet<MUsers>();
        }

        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEmail { get; set; }
        public int EBankCode { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccountNumber { get; set; }
        public string BankBranchCode { get; set; }

        public virtual MBank EBankCodeNavigation { get; set; }
        public virtual ICollection<MBulkPayments> MBulkPayments { get; set; }
        public virtual ICollection<MDebitOrders> MDebitOrders { get; set; }
        public virtual ICollection<MUsers> MUsers { get; set; }
    }
}
