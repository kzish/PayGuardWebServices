using System;
using System.Collections.Generic;

namespace PayGuardBankInterface.Models
{
    public partial class MBulkPaymentsIncomingRecipients
    {
        public int Id { get; set; }
        public int MBulkPaymentsIncomingId { get; set; }
        public int IdAtClient { get; set; }
        public string RecipientName { get; set; }
        public string RecipientBankSwiftCode { get; set; }
        public string RecipientAccountNumber { get; set; }
        public decimal RecipientAmount { get; set; }
        public int BulkPaymentId { get; set; }

        public virtual MBulkPaymentsIncoming MBulkPaymentsIncoming { get; set; }
    }
}
