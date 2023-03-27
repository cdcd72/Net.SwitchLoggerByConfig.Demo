using LoggingLibrary.Loggers.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Web;

namespace LoggingLibrary.Loggers
{
    public static class NLogger
    {
        private static ISetupBuilder _builder;
        
        /// <summary>
        /// Initial
        /// </summary>
        /// <param name="options">options</param>
        /// <returns></returns>
        public static ISetupBuilder Init(NLoggerOptions options)
        {
            _builder = LogManager
                .Setup()
                .LoadConfigurationFromAppSettings()
                .LoadConfigurationFromFile(options.ConfigFilePath);

            return _builder;
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <returns></returns>
        public static NLog.ILogger GetLogger() => _builder.GetCurrentClassLogger();

        /// <summary>
        /// Use Nlog
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHostBuilder UseNLogFromCore(this IHostBuilder builder) => builder.UseNLog();

        /// <summary>
        /// Add Nlog
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddNLogFromCore(this IServiceCollection services) => services.AddLogging(builder => builder.AddNLog());
        
        /// <summary>
        /// Close
        /// </summary>
        public static void Close() => LogManager.Shutdown();
    }
}