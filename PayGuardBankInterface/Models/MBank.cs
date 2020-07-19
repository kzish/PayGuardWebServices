using System;
using System.Collections.Generic;

namespace PayGuardBankInterface.Models
{
    public partial class MBank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string EndPoint { get; set; }
        public bool Online { get; set; }
    }
}
