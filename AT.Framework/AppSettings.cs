using AT.Framework.Helpers;
using AT.Framework.Models.Appsettings;

namespace AT.Framework
{
    public static class AppSettings
    {
        private static EnvConfiguration? _envConfiguration;
        private static DriverCapabilities? _driver;
        private static LoggerConfiguration? _loggerConfig;

        public static EnvConfiguration EnvConfiguration
        {
            get
            {
                if (_envConfiguration == null)
                    _envConfiguration = ConfigurationHelper.GetBindConfiguration<EnvConfiguration>(section: "EnvConfiguration")
                        ?? throw new Exception("Can't retrieve EnvConfiguration section from appsettings.json!");
                return _envConfiguration;
            }
        }

        public static DriverCapabilities DriverCapabilities
        {
            get
            {
                if (_driver == null)
                    _driver = ConfigurationHelper.GetBindConfiguration<DriverCapabilities>(section: "DriverCapabilities")
                        ?? throw new Exception("Can't retrieve DriverCapabilities section from appsettings.json!");
                return _driver;
            }
        }

        public static LoggerConfiguration LoggerConfiguration
        {
            get
            {
                if (_loggerConfig == null)
                    _loggerConfig = ConfigurationHelper.GetBindConfiguration<LoggerConfiguration>(section: "LoggerConfiguration")
                        ?? throw new Exception("Can't retrieve LoggerConfiguration section from appsettings.json!");
                return _loggerConfig;
            }
        }
    }
}
