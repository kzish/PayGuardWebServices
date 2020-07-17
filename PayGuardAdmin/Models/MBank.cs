using System;
using System.Collections.Generic;

namespace PayGuardAdmin.Models
{
    public partial class MBank
    {
        public MBank()
        {
            MClient = new HashSet<MClient>();
        }

        public int Id { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public string EndPoint { get; set; }

        public virtual ICollection<MClient> MClient { get; set; }
    }
}
