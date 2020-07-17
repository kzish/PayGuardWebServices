using System;
using System.Collections.Generic;

namespace PayGuardAdmin.Models
{
    public partial class MBank
    {
        public MBank()
        {
            MBulkPaymentsRecipients = new HashSet<MBulkPaymentsRecipients>();
            MCompany = new HashSet<MCompany>();
        }

        public int Id { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string EndPoint { get; set; }
        public bool Online { get; set; }

        public virtual ICollection<MBulkPaymentsRecipients> MBulkPaymentsRecipients { get; set; }
        public virtual ICollection<MCompany> MCompany { get; set; }
    }
}
