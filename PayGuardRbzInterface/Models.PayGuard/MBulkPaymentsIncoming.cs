using System;
using System.Collections.Generic;

namespace PayGuard.Models
{

    /// <summary>
    /// model of bulk payment sent from bulkpayer bank
    /// roshandiswa paku gamuchira bulkpayment from bulkpayers bank
    /// </summary>
    public partial class MBulkPaymentsIncoming
    {
        public MBulkPaymentsIncoming()
        {
            MBulkPaymentsIncomingRecipients = new HashSet<MBulkPaymentsIncomingRecipients>();
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

        public virtual ICollection<MBulkPaymentsIncomingRecipients> MBulkPaymentsIncomingRecipients { get; set; }
    }
}
