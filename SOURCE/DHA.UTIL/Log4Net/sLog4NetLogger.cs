using log4net;
using log4net.Config;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DHA.UTIL.Log4Net
{
    public static class sLog4NetLogger
    {

        // Mandatory for Logger to Work
        public static void sInitConfig(FileInfo pFileInfoConfigFile)
        {
            XmlConfigurator.Configure(pFileInfoConfigFile);
        }

        // get logger
        private static readonly Lazy<LogSingletonWrapper> _logger = new Lazy<LogSingletonWrapper>();
        private class LogSingletonWrapper
        {
            public ILog Log { get; set; }
            public LogSingletonWrapper()
            {
                Log = LogManager.GetLogger(GetType());
            }
        }
        private static ILog GetLogger(string memberName, string sourceFilePath)
        {
            var classname = sourceFilePath.Split('\\').Last().Split('.').First();
            log4net.ThreadContext.Properties["Source"] = $"{classname}.{memberName.Replace(".", "")}";
            return _logger.Value.Log;
        }

        // Log debug
        public static void Debug(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            GetLogger(memberName, sourceFilePath).Debug(message);
        }
        public static LogData Debug_Start(string pStrMessage = "", [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {

            string __strMessage = defaultmsg(pStrMessage);
            Debug(__strMessage, memberName, sourceFilePath);
            return new LogData(__strMessage);
        }
        public static void Debug_End(LogData pLogData, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            Debug(pLogData.ToString(), memberName, sourceFilePath);
        }

        // Log info
        public static void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            GetLogger(memberName, sourceFilePath).Info(message);            
        }
        public static LogData Info_Start(string pStrMessage = "", bool pShowMessage=true, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            string __strMessage = defaultmsg(pStrMessage);
            if (pShowMessage)
                Info(__strMessage, memberName, sourceFilePath);
            return new LogData(__strMessage);
        }
        public static void Info_End(LogData pLogData, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {
            Info(pLogData.ToString(), memberName, sourceFilePath);
        }

        // Log Error
        public static void Error(string message, Exception pException=null, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "")
        {            
            if (pException==null)
            {
                GetLogger(memberName, sourceFilePath).Error(message);
            }
            else
            {
                GetLogger(memberName, sourceFilePath).Error(message, pException);
            }
        }

        // default message if not provided
        private static string defaultmsg(string pStrMessage)
        {
            if (pStrMessage == string.Empty)
            {
                return "Method";
            }
            return pStrMessage;
        }


        
    }
}

