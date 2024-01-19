using Api.Boundaries;
using Microsoft.AspNetCore.Mvc;
using LogLevel = LoggingLibrary.Enum.LogLevel;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController(ILogger<LogController> logger) : ControllerBase
{
    [HttpPost]
    [Route(nameof(Write))]
    public async Task Write([FromBody] WriteLogInput input)
    {
        var logLevel = input.LogLevel;
        var message = input.Message;
        
        switch (logLevel)
        {
            case LogLevel.Trace:
                logger.LogTrace(message);
                break;
            case LogLevel.Debug:
                logger.LogDebug(message);
                break;
            case LogLevel.Information:
                logger.LogInformation(message);
                break;
            case LogLevel.Warning:
                logger.LogWarning(message);
                break;
            case LogLevel.Error:
                logger.LogError(message);
                break;
            case LogLevel.Critical:
                logger.LogCritical(message);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logLevel));
        }

        await Task.CompletedTask;
    }
}
