using System;
using System.Collections.Generic;

namespace PayGuardClient.Models
{
    public partial class MBank
    {
        public MBank()
        {
            MBulkPaymentsRecipients = new HashSet<MBulkPaymentsRecipients>();
            MCompany = new HashSet<MCompany>();
            MDebitOrdersClients = new HashSet<MDebitOrdersClients>();
        }

        public int Id { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string EndPoint { get; set; }
        public bool Online { get; set; }

        public virtual ICollection<MBulkPaymentsRecipients> MBulkPaymentsRecipients { get; set; }
        public virtual ICollection<MCompany> MCompany { get; set; }
        public virtual ICollection<MDebitOrdersClients> MDebitOrdersClients { get; set; }
    }
}
