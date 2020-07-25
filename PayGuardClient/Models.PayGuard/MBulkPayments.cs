using System;
using System.Collections.Generic;

namespace PayGuard.Models
{
    /// <summary>
    /// model of the bulk payment to be sent to the bank
    /// this model contains the AccountNumber and BankCode
    /// </summary>
    public class MBulkPayments
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
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }
        public virtual ICollection<MBulkPaymentsRecipients> MBulkPaymentsRecipients { get; set; }
    }
}
