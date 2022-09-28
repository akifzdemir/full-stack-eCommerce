namespace Core.Utilities.Logger
{
    public interface ILoggerService
    {
        void LogError(string message);
        void LogWarning(string message);
        void LogDebug(string message);
        void LogInfo(string message);
    }
}
