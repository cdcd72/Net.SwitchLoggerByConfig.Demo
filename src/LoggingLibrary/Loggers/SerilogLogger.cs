using LoggingLibrary.Loggers.Options;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace LoggingLibrary.Loggers
{
    public static class SerilogLogger
    {
        private static LoggerConfiguration _builder;
        
        /// <summary>
        /// Initial
        /// </summary>
        /// <param name="options">options</param>
        /// <returns></returns>
        public static LoggerConfiguration Init(SerilogLoggerOptions options)
        {
            _builder = new LoggerConfiguration()
                .ReadFrom.Configuration(options.Config);

            Log.Logger = _builder.CreateLogger();
            
            return _builder;
        }
        
        /// <summary>
        /// Get logger
        /// </summary>
        /// <returns></returns>
        public static Serilog.ILogger GetLogger() => Log.Logger;

        /// <summary>
        /// Use Serilog
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IHostBuilder UseSerilogFromCore(this IHostBuilder builder) => builder.UseSerilog();

        /// <summary>
        /// Close
        /// </summary>
        public static void Close() => Log.CloseAndFlush();
    }
}