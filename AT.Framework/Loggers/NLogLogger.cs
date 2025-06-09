namespace AT.Framework.Loggers
{
    public class NLogLogger : ILogger
    {
        private readonly NLog.Logger _logger;

        public NLogLogger(string name)
        {
            _logger = NLog.LogManager.GetLogger(name);
        }

        public void Info(string message) => _logger.Info(message);
        public void Debug(string message) => _logger.Debug(message);
        public void Warn(string message) => _logger.Warn(message);
        public void Error(string message, Exception ex) => _logger.Error(ex, message);
        public void Fatal(string message) => _logger.Fatal(message);
    }
}
