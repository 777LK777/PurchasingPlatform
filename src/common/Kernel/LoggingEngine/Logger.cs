using Microsoft.Extensions.Logging;

namespace Kernel.LoggingEngine;

public class Logger : ILogger
{
    private readonly IServiceProvider _provider;

    public Logger(IServiceProvider provider)
    {
        _provider = provider;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    // TODO: write logging mechanism
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        if (formatter == null) return;
        var message = new LogMessage();        
    }
}