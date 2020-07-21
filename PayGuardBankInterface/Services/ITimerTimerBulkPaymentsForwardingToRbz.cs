using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayGuardBankInterface.Services
{
    /// <summary>
    /// timer interface
    /// </summary>
    public interface ITimerTimerBulkPaymentsForwardingToRbz
    {
        void RunTask(object state);
    }
}
