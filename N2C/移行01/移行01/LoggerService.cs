using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace 移行01
{
    public class LoggerService
    {
        private static ILogger logger;
        
        static LoggerService()
        {
            var config = new LoggingConfiguration();

            if(!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\LOG"))
            {
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\LOG", null);
            }

            var logFile = new FileTarget("logfile")
            {
                FileName = System.AppDomain.CurrentDomain.BaseDirectory + "/LOG/logfile.log",
                ArchiveFileName = System.AppDomain.CurrentDomain.BaseDirectory + "/LOG/archives/logfile_{#}.log",
                ArchiveNumbering = ArchiveNumberingMode.Date,
                ArchiveEvery = FileArchivePeriod.Day,
                MaxArchiveFiles = 30,
                Layout = "${longdate} | ${uppercase:${level}} | ${message} |  ${callsite:skipFrames=1} | ${callsite-method:skipFrames=1} | Line:${callsite-linenumber:skipFrames=1}",
                KeepFileOpen = false,
                ConcurrentWrites = true,
            };
#if DEBUG
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);
#else
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logFile);
#endif
            LogManager.Configuration = config;
            logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// インフォメーションログ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogInfo(string message, Dictionary<string, object> args = null)
        {
            if (args != null)
            {
                foreach (var kv in args)
                {
                    string placeholder = $"{{{kv.Key}}}";
                    message = message.Replace(placeholder, kv.Value?.ToString() ?? "null");
                }
            }
            logger.Info(message);
        }

        /// <summary>
        /// エラーログ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogError(string message, Dictionary<string, object> args= null)
        {
            if (args != null)
            {
                foreach (var kv in args)
                {
                    string placeholder = $"{{{kv.Key}}}";
                    message = message.Replace(placeholder, kv.Value?.ToString() ?? "null");
                }
            }
            logger.Error(message);
        }

        /// <summary>
        /// ワーニングログ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogWarning(string message, Dictionary<string, object> args= null)
        {
            if (args != null)
            {
                foreach (var kv in args)
                {
                    string placeholder = $"{{{kv.Key}}}";
                    message = message.Replace(placeholder, kv.Value?.ToString() ?? "null");
                }
            }
            logger.Warn(message);
        }


        /// <summary>
        /// デバッグログ
        /// </summary>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public void LogDebug(string message, Dictionary<string, object> args = null)
        {
            if (args != null)
            {
                foreach (var kv in args)
                {
                    string placeholder = $"{{{kv.Key}}}";
                    message = message.Replace(placeholder, kv.Value?.ToString() ?? "null");
                }
            }
            logger.Debug(message);
        }
    }
}
