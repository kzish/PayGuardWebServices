using System;
using System.Collections.Generic;

namespace PayGuard.Models
{
    /// <summary>
    /// model of a debit order recieved from rbz
    /// </summary>
    public partial class MDebitOrders
    {
        public MDebitOrders()
        {
            MDebitOrdersClients = new HashSet<MDebitOrdersClients>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public int CompanyId { get; set; }
        public string AspNetUserId { get; set; }
        public DateTime? DateLastSubmitted { get; set; }
        public string AccountNumber { get; set; }
        public string BankCode { get; set; }

        public virtual ICollection<MDebitOrdersClients> MDebitOrdersClients { get; set; }
    }
}
