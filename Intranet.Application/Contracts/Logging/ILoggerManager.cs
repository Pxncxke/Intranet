namespace Intranet.Application.Contracts.Logging;

public interface ILoggerManager<T> 
{
    void LogInfo(string message, params object[] args);
    void LogWarn(string message, params object[] args);
    void LogDebug(string message, params object[] args);
    void LogError(string message, params object[] args);
}
