using Api.Boundaries;
using Microsoft.AspNetCore.Mvc;
using LogLevel = LoggingLibrary.Enum.LogLevel;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost]
    [Route(nameof(Write))]
    public async Task Write([FromBody] WriteLogInput input)
    {
        var logLevel = input.LogLevel;
        var message = input.Message;
        
        switch (logLevel)
        {
            case LogLevel.Trace:
                _logger.LogTrace(message);
                break;
            case LogLevel.Debug:
                _logger.LogDebug(message);
                break;
            case LogLevel.Information:
                _logger.LogInformation(message);
                break;
            case LogLevel.Warning:
                _logger.LogWarning(message);
                break;
            case LogLevel.Error:
                _logger.LogError(message);
                break;
            case LogLevel.Critical:
                _logger.LogCritical(message);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logLevel));
        }

        await Task.CompletedTask;
    }
}
