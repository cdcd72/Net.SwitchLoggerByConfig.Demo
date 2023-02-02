using LogLevel = LoggingLibrary.Enum.LogLevel;

namespace Api.Boundaries;

public class WriteLogInput
{
    /// <summary>
    /// Log level
    /// </summary>
    public LogLevel LogLevel { get; set; }

    /// <summary>
    /// message
    /// </summary>
    public string Message { get; set; }
}