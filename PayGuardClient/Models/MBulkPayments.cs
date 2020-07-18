using System;
using System.Collections.Generic;

namespace PayGuardClient.Models
{
    public partial class MBulkPayments
    {
        public MBulkPayments()
        {
            MBulkPaymentsRecipients = new HashSet<MBulkPaymentsRecipients>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public int CompanyId { get; set; }
        public string AspNetUserId { get; set; }
        public DateTime? DateLastSubmitted { get; set; }

        public virtual AspNetUsers AspNetUser { get; set; }
        public virtual MCompany Company { get; set; }
        public virtual ICollection<MBulkPaymentsRecipients> MBulkPaymentsRecipients { get; set; }
    }
}
