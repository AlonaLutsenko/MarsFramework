namespace AT.Framework.Loggers
{
    public static class LoggerFactory
    {
        public static ILogger GetLogger(string type, string name)
        {
            return type.ToLower() switch
            {
                LoggerTypes.Log4Net => new Log4NetLogger(name),
                LoggerTypes.Console => new ConsoleLogger(),
                LoggerTypes.NLog => new NLogLogger(name),
                _ => throw new ArgumentException($"Unsupported logger type: {type}")
            };
        }
    }
}
