namespace LoggingLibrary.Interfaces
{
    public interface ICoreLoggerBuilder
    {
        /// <summary>
        /// Setup
        /// </summary>
        ICoreLoggerBuilder Setup();

        /// <summary>
        /// Create logger
        /// </summary>
        /// <returns></returns>
        ILogger CreateLogger();
    }
}