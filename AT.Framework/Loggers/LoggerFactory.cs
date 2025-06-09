using AT.Framework.Constants;

namespace AT.Framework.Loggers
{
    public static class LoggerFactory
    {
        public static ILogger GetLogger(string type, string name)
        {
            return type.ToLower() switch
            {
                LoggerTypes.Log4Net => new Log4NetLogger(name),
                LoggerTypes.NLog => new NLogLogger(name),
                LoggerTypes.Serilog => new SerilogLogger(name),
                _ => throw new ArgumentException($"Unsupported logger type: {type}")
            };
        }
    }
}
