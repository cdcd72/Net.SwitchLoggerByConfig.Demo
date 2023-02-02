namespace LoggingLibrary.Interfaces
{
    public interface ILogger
    {
        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="message">message</param>
        void LogTrace(string message);
        
        /// <summary>
        /// Debug
        /// </summary>
        /// <param name="message">message</param>
        void LogDebug(string message);
        
        /// <summary>
        /// Information
        /// </summary>
        /// <param name="message">message</param>
        void LogInformation(string message);
        
        /// <summary>
        /// Warning
        /// </summary>
        /// <param name="message">message</param>
        void LogWarning(string message);
        
        /// <summary>
        /// Error
        /// </summary>
        /// <param name="message">message</param>
        void LogError(string message);

        /// <summary>
        /// Critical
        /// </summary>
        /// <param name="message">message</param>
        void LogCritical(string message);
    }
}