using LoggingLibrary.Enum;
using LoggingLibrary.Interfaces;
using LoggingLibrary.Loggers;
using Microsoft.Extensions.Logging.Log4Net.AspNetCore.Extensions;

namespace LoggingLibrary.Implements
{
    public class Logger(LoggerType loggerType) : ILogger
    {
        public void LogTrace(string message)
        {
            switch (loggerType)
            {
                case LoggerType.NLog:
                    NLogger.GetLogger().Trace(message);
                    break;
                case LoggerType.Serilog:
                    SerilogLogger.GetLogger().Verbose(message);
                    break;
                case LoggerType.Log4Net:
                    Log4NetLogger.GetLogger().Trace(message, null);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggerType));
            }
        }

        public void LogDebug(string message)
        {
            switch (loggerType)
            {
                case LoggerType.NLog:
                    NLogger.GetLogger().Debug(message);
                    break;
                case LoggerType.Serilog:
                    SerilogLogger.GetLogger().Debug(message);
                    break;
                case LoggerType.Log4Net:
                    Log4NetLogger.GetLogger().Debug(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggerType));
            }
        }

        public void LogInformation(string message)
        {
            switch (loggerType)
            {
                case LoggerType.NLog:
                    NLogger.GetLogger().Info(message);
                    break;
                case LoggerType.Serilog:
                    SerilogLogger.GetLogger().Information(message);
                    break;
                case LoggerType.Log4Net:
                    Log4NetLogger.GetLogger().Info(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggerType));
            }
        }

        public void LogWarning(string message)
        {
            switch (loggerType)
            {
                case LoggerType.NLog:
                    NLogger.GetLogger().Warn(message);
                    break;
                case LoggerType.Serilog:
                    SerilogLogger.GetLogger().Warning(message);
                    break;
                case LoggerType.Log4Net:
                    Log4NetLogger.GetLogger().Warn(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggerType));
            }
        }

        public void LogError(string message)
        {
            switch (loggerType)
            {
                case LoggerType.NLog:
                    NLogger.GetLogger().Error(message);
                    break;
                case LoggerType.Serilog:
                    SerilogLogger.GetLogger().Error(message);
                    break;
                case LoggerType.Log4Net:
                    Log4NetLogger.GetLogger().Error(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggerType));
            }
        }

        public void LogCritical(string message)
        {
            switch (loggerType)
            {
                case LoggerType.NLog:
                    NLogger.GetLogger().Fatal(message);
                    break;
                case LoggerType.Serilog:
                    SerilogLogger.GetLogger().Fatal(message);
                    break;
                case LoggerType.Log4Net:
                    Log4NetLogger.GetLogger().Fatal(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(loggerType));
            }
        }
    }
}