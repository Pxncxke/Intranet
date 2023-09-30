using Intranet.Application.Contracts.Logging;

namespace Intranet.Infrastructure.Infrastructure.Logging;

public class LoggerManager<T> : ILoggerManager<T>
{
    private readonly NLog.ILogger logger;

    public LoggerManager(NLog.ILogger logger)
    {
        this.logger = logger;
    }

    public void LogDebug(string message, params object[] args)
    {
       logger.Debug(message, args);
    }

    public void LogError(string message, params object[] args)
    {
       logger?.Error(message, args);
    }

    public void LogInfo(string message, params object[] args)
    {
       logger.Info(message, args);
    }

    public void LogWarn(string message, params object[] args)
    {
        logger.Warn(message, args);
    }
}
