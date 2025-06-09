namespace AT.Framework.Loggers
{
    public class ConsoleLogger : ILogger
    {
        public void Info(string message) => Console.WriteLine($"INFO: {message}");
        public void Debug(string message) => Console.WriteLine($"DEBUG: {message}");
        public void Warn(string message) => Console.WriteLine($"WARN: {message}");
        public void Error(string message, Exception ex) => Console.WriteLine($"ERROR: {message} - {ex}");
        public void Fatal(string message) => Console.WriteLine($"FATAL: {message}");
    }
}
