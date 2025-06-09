namespace AT.Framework.Loggers
{
    public class Log4NetLogger : ILogger
    {
        private readonly log4net.ILog _log;

        public Log4NetLogger(string name)
        {
            _log = log4net.LogManager.GetLogger(name);
        }

        public void Info(string message) => _log.Info(message);
        public void Debug(string message) => _log.Debug(message);
        public void Warn(string message) => _log.Warn(message);
        public void Error(string message, Exception ex) => _log.Error(message, ex);
        public void Fatal(string message) => _log.Fatal(message);
    }
}
