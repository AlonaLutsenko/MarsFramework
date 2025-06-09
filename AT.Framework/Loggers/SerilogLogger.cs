using Serilog;

namespace AT.Framework.Loggers
{
    public class SerilogLogger : ILogger
    {
        private readonly Serilog.ILogger _logger;

        public SerilogLogger(string name)
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File($"logs/{name}.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void Info(string message) => _logger.Information(message);
        public void Debug(string message) => _logger.Debug(message);
        public void Warn(string message) => _logger.Warning(message);
        public void Error(string message, Exception ex) => _logger.Error(ex, message);
        public void Fatal(string message) => _logger.Fatal(message);
    }
}
