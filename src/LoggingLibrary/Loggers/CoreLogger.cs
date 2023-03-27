using LoggingLibrary.Enum;
using LoggingLibrary.Implements;
using LoggingLibrary.Interfaces;
using LoggingLibrary.Loggers.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LoggingLibrary.Loggers
{
    public static class CoreLogger
    {
        private static LoggerType _loggerType;
        private static ICoreLoggerBuilder _builder;

        /// <summary>
        /// Initial
        /// </summary>
        /// <param name="config">configuration</param>
        /// <returns></returns>
        public static ICoreLoggerBuilder Init(IConfiguration config)
        {
            var options = config.GetSection(CoreLoggerOptions.SectionName).Get<CoreLoggerOptions>();

            _loggerType = System.Enum.Parse<LoggerType>(options.LoggerType);

            #region Fool-proof and deal some params can't from config

            switch (_loggerType)
            {
                case LoggerType.NLog:
                    options.NLogOptions ??= new NLoggerOptions();
                    break;
                case LoggerType.Serilog:
                    options.SerilogOptions ??= new SerilogLoggerOptions();
                    options.SerilogOptions.Config = config;
                    break;
                case LoggerType.Log4Net:
                    options.Log4NetOptions ??= new Log4NetLoggerOptions();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_loggerType));
            }

            #endregion

            _builder = new CoreLoggerBuilder(options);

            return _builder.Setup();
        }

        /// <summary>
        /// Get logger
        /// </summary>
        /// <returns></returns>
        public static ILogger GetLogger() => _builder.CreateLogger();

        /// <summary>
        /// Use log
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHostBuilder UseCoreLog(this IHostBuilder builder)
        {
            return _loggerType switch
            {
                LoggerType.NLog => builder.UseNLogFromCore(),
                LoggerType.Serilog => builder.UseSerilogFromCore(),
                LoggerType.Log4Net => builder.UseLog4NetFromCore(),
                _ => throw new ArgumentOutOfRangeException(nameof(_loggerType))
            };
        }
        
        /// <summary>
        /// Add Log (UseCoreLog() can't used situation, try this...)
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCoreLogging(this IServiceCollection services)
        {
            return _loggerType switch
            {
                LoggerType.NLog => services.AddNLogFromCore(),
                LoggerType.Serilog => services.AddSerilogFromCore(),
                LoggerType.Log4Net => services.AddLog4NetFromCore(),
                _ => throw new ArgumentOutOfRangeException(nameof(_loggerType))
            };
        }

        /// <summary>
        /// Close
        /// </summary>
        public static void Close()
        {
            switch (_loggerType)
            {
                case LoggerType.NLog:
                    NLogger.Close();
                    break;
                case LoggerType.Serilog:
                    SerilogLogger.Close();
                    break;
                case LoggerType.Log4Net:
                    Log4NetLogger.Close();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_loggerType));
            }
        }
    }
}