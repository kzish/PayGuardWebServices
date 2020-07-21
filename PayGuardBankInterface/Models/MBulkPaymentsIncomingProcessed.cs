using System;
using System.Collections.Generic;

namespace PayGuardBankInterface.Models
{
    public partial class MBulkPaymentsIncomingProcessed
    {
        public MBulkPaymentsIncomingProcessed()
        {
            MBulkPaymentsIncomingRecipientsProcessed = new HashSet<MBulkPaymentsIncomingRecipientsProcessed>();
        }

        public int Id { get; set; }
        public int IdAtClient { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime DateCreatedAtClient { get; set; }
        public string Reference { get; set; }
        public int CompanyId { get; set; }
        public string AspNetUserId { get; set; }
        public DateTime? DateProcessed { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }

        public virtual ICollection<MBulkPaymentsIncomingRecipientsProcessed> MBulkPaymentsIncomingRecipientsProcessed { get; set; }
    }
}
