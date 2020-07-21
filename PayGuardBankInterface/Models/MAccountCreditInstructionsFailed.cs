using System;
using System.Collections.Generic;

namespace PayGuardBankInterface.Models
{
    public partial class MAccountCreditInstructionsFailed
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string RecipientBankCode { get; set; }
        public string RecipientAccountNumber { get; set; }
        public string SenderBankCode { get; set; }
        public string SenderAccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Reference { get; set; }
    }
}
