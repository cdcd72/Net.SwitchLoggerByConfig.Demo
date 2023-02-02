using Microsoft.Extensions.Configuration;

namespace LoggingLibrary.Loggers.Options
{
    /// <summary>
    /// SerilogLogger options
    /// </summary>
    public class SerilogLoggerOptions
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Config { get; set; }
    }
}