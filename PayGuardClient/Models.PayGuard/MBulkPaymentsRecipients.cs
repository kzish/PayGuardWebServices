using System;
using System.Collections.Generic;

namespace PayGuard.Models
{
    public class MBulkPaymentsRecipients
    {
        public int Id { get; set; }
        public string RecipientName { get; set; }
        public string RecipientBankSwiftCode { get; set; }
        public string RecipientAccountNumber { get; set; }
        public decimal RecipientAmount { get; set; }
        public int BulkPaymentId { get; set; }
    }
}
