using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayGuardRbzInterface.Services
{
    /// <summary>
    /// timer interface
    /// </summary>
    public interface ITimerBulkPaymentsForwardingToRecipientBanks
    {
        void RunTask(object state);
    }
}
