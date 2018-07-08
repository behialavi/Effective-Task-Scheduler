using AZW.Lottery.Business;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskScheduler
{
    public class UserNotifyDispatchAffair : TaskAffairBase
    {
        static UserNotifyDispatchAffair()
        {
            log = log4net.LogManager.GetLogger(typeof(UserNotifyDispatchAffair));
        }
        protected override void DoTask()
        {
            log.Info("User has been notified...");

        }
    }
}
