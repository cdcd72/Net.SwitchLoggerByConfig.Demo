using LoggingLibrary.Enum;
using LoggingLibrary.Interfaces;
using LoggingLibrary.Loggers;
using LoggingLibrary.Loggers.Options;

namespace LoggingLibrary.Implements
{
    public class CoreLoggerBuilder : ICoreLoggerBuilder
    {
        private readonly CoreLoggerOptions _options;
        private readonly LoggerType _loggerType;

        #region Constructor

        public CoreLoggerBuilder(CoreLoggerOptions options)
        {
            _options = options;
            _loggerType = System.Enum.Parse<LoggerType>(_options.LoggerType);
        }

        #endregion

        public ICoreLoggerBuilder Setup()
        {
            switch (_loggerType)
            {
                case LoggerType.NLog:
                    NLogger.Init(_options.NLogOptions);
                    break;
                case LoggerType.Serilog:
                    SerilogLogger.Init(_options.SerilogOptions);
                    break;
                case LoggerType.Log4Net:
                    Log4NetLogger.Init(_options.Log4NetOptions);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_loggerType));
            }
            
            return this;
        }

        public ILogger CreateLogger() => new Logger(_loggerType);
    }
}