using System;
using System.Collections.Generic;

namespace PayGuard.Models
{
    /// <summary>
    /// model for debit order clients,
    /// this model is sent to rbz
    /// bank id is converted to bank code
    /// </summary>
    public partial class MDebitOrdersClients
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ClientBankSwiftCode { get; set; }
        public string ClientAccountNumber { get; set; }
        public decimal ClientAmount { get; set; }
        public int DebitOrderId { get; set; }

    }
}
