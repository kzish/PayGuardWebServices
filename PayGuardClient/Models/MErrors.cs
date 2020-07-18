using System;
using System.Collections.Generic;

namespace PayGuardClient.Models
{
    public partial class MErrors
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
    }
}
