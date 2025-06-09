namespace AT.Framework.Loggers
{
    public interface ILogger
    {
        void Info(string message);
        void Debug(string message);
        void Warn(string message);
        void Error(string message, Exception ex);
        void Fatal(string message);
    }
}
