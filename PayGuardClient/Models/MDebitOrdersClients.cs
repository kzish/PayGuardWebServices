using System;
using System.Collections.Generic;

namespace PayGuardClient.Models
{
    public partial class MDebitOrdersClients
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int EClientBankId { get; set; }
        public string ClientAccountNumber { get; set; }
        public decimal ClientAmount { get; set; }
        public int DebitOrderId { get; set; }

        public virtual MDebitOrders DebitOrder { get; set; }
        public virtual MBank EClientBank { get; set; }
    }
}
