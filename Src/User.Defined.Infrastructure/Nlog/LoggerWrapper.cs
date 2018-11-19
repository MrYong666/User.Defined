using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Defined.Infrastructure.Nlog
{

    /// <summary>
    /// 项目日志封装
    /// </summary>
    public class LoggerWrapper
    {
        public static NLog.Logger logger;


        public static Logger Default { get; private set; }
        static LoggerWrapper()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Debug(string msg, params object[] args)
        {
            logger.Debug(msg, args);
        }
        public static void Debug(string msg)
        {
            logger.Debug(msg);
        }
        public void Info(string msg, params object[] args)
        {
            logger.Info(msg, args);
        }

        public void Trace(string msg, params object[] args)
        {
            logger.Trace(msg, args);
        }
        public static void Error(string msg)
        {
            logger.Error(msg);
        }
        public static void Error(string msg, params object[] args)
        {
            logger.Error(msg, args);
        }
        public void Fatal(string msg, params object[] args)
        {
            logger.Fatal(msg, args);
        }
    }
}
