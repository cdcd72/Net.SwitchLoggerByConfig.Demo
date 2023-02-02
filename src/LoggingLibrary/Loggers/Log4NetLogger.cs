using System.Reflection;
using log4net;
using LoggingLibrary.Loggers.Options;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LoggingLibrary.Loggers
{
    public static class Log4NetLogger
    {
        private static Log4NetLoggerOptions _options;
        
        /// <summary>
        /// Initial
        /// </summary>
        /// <param name="options">options</param>
        /// <returns></returns>
        public static void Init(Log4NetLoggerOptions options)
        {
            _options = options;

            SetLog4NetProperties();
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <returns></returns>
        public static ILog GetLogger() => LogManager.GetLogger(MethodBase.GetCurrentMethod()?.DeclaringType);

        /// <summary>
        /// Use log4net
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHostBuilder UseLog4NetFromCore(this IHostBuilder builder) => builder.ConfigureLogging(o => o.AddLog4Net(_options.ConfigFilePath));

        /// <summary>
        /// Close
        /// </summary>
        public static void Close() => LogManager.Shutdown();

        #region Private Method

        /// <summary>
        /// Set log4net properties
        /// </summary>
        private static void SetLog4NetProperties()
        {
            var now = DateTime.Now;
            
            // 設定 Log 路徑多增加年月
            GlobalContext.Properties["LogPath"] =
                $"{now.Year}/{now.Month.ToString().PadLeft(2, '0')}/{now.Day.ToString().PadLeft(2, '0')}";
        }

        #endregion
    }
}