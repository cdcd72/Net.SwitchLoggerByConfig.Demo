namespace LoggingLibrary.Loggers.Options
{
    /// <summary>
    /// CoreLogger options
    /// </summary>
    public class CoreLoggerOptions
    {
        public const string SectionName = nameof(CoreLoggerOptions);
        
        /// <summary>
        /// Logger type
        /// </summary>
        public string LoggerType { get; set; }
        
        /// <summary>
        /// NLog options
        /// </summary>
        public NLoggerOptions NLogOptions { get; set; }

        /// <summary>
        /// Serilog options
        /// </summary>
        public SerilogLoggerOptions SerilogOptions { get; set; }

        /// <summary>
        /// Log4Net options
        /// </summary>
        public Log4NetLoggerOptions Log4NetOptions { get; set; }
    }
}