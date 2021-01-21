using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rs.Common
{
    public static partial class Log
    {
        public static object LogLock = new object();

        public static ILog WebLogger => GetLogger("WebLogger");
        public static ILog Cache => GetLogger("Cache");
        public static ILog OperationQueue => GetLogger("OperationQueue");
        public static ILog EmailLogger => GetLogger("EmailLogger");
        public static ILog SystemLogger => GetLogger("SystemLogger");
        public static ILog AccountPayLog => GetLogger("AccountPayLog");
        public static ILog SmsLogger => GetLogger("SmsLogger");
        public static ILog Account => GetLogger("Account");
        /// <summary>
        /// 异常日志
        /// </summary>
        public static ILog Exceptions => GetLogger("Exception");


        public static int Int { get; set; }
        public static ILog GetLogger(string name)
        {
            lock (LogLock)
            {
                return LogManager.GetLogger("Logs", name);
            }
        }
    }
}
