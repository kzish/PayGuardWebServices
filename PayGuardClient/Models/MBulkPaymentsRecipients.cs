using System;
using System.Collections.Generic;

namespace PayGuardClient.Models
{
    public partial class MBulkPaymentsRecipients
    {
        public int Id { get; set; }
        public string RecipientName { get; set; }
        public int ERecipientBankId { get; set; }
        public string RecipientAccountNumber { get; set; }
        public decimal RecipientAmount { get; set; }
        public int BulkPaymentId { get; set; }

        public virtual MBulkPayments BulkPayment { get; set; }
        public virtual MBank ERecipientBank { get; set; }
    }
}
