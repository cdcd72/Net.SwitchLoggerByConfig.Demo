using LoggingLibrary.Loggers;

try
{
    // For Serilog write to file used.
    Environment.SetEnvironmentVariable("BASEDIR", AppDomain.CurrentDomain.BaseDirectory);
    
    var builder = WebApplication.CreateBuilder(args);
    
    var config = new ConfigurationBuilder()
        .AddJsonFile("config/appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"config/appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
        .AddJsonFile("config/logsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"config/logsettings.{builder.Environment.EnvironmentName}.json", optional: true)
        .Build();

    // Initial core logger
    CoreLogger.Init(config);

    // Use core logger
    builder.Host.UseCoreLog();
    
    builder.Configuration.AddConfiguration(config);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    if (app.Environment.IsProduction())
    {
        app.UseHttpsRedirection();
    }

    app.MapControllers();

    app.Run();
    
    return 0;
}
catch (Exception)
{
    CoreLogger.GetLogger().LogError("Api terminated unexpectedly.");
    
    return 1;
}
finally
{
    // Close core logger
    CoreLogger.Close();
}


