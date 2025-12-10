namespace Telhai.CS.Csharp.Services.Logging;

public interface ILogger
{
    void Log(string msg);
    void Log(string msg, LogLevel level);
}