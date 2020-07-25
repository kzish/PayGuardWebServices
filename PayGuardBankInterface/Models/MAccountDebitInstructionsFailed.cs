using System;
using System.Collections.Generic;

namespace PayGuardBankInterface.Models
{
    public partial class MAccountDebitInstructionsFailed
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ClientBankCode { get; set; }
        public string ClientAccountNumber { get; set; }
        public string SenderBankCode { get; set; }
        public string SenderAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
    }
}
