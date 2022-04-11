using Microsoft.Extensions.Logging;

namespace Kernel.LoggingEngine;

public class LoggerProvider : ILoggerProvider
{
    private readonly IServiceProvider _provider;

    public LoggerProvider(IServiceProvider provider)
    {
        _provider = provider;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new Logger(_provider);
    }

    public void Dispose() { }
}