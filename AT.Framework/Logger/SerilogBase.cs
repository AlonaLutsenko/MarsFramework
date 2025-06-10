using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using AppConfig = AT.Framework.Models.Appsettings.LoggerConfiguration;

namespace AT.Framework.Logger
{
    public static class SerilogBase
    {
        [ThreadStatic]
        private static ILogger? _logger;

        [ThreadStatic]
        private static DirectoryInfo? _testDirectory;

        public static ILogger Logger
        {
            get
            {
                if (_logger == null)
                    _logger = InitNewLogger(TestContext.CurrentContext.Test.Name);
                return _logger;
            }
            private set => _logger = value;
        }

        public static DirectoryInfo GetTestDirectory() => _testDirectory!;

        public static void Debug(string message) => Logger.Debug($"[{DateTime.Now:HH:mm:ss}] [DEBUG] {message}");

        public static void Info(string message) => Logger.Information($"[{DateTime.Now:HH:mm:ss}] [INFO] {message}");

        public static void Warn(string message) => Logger.Warning($"[{DateTime.Now:HH:mm:ss}] [WARN] {message}");

        public static void Error(string message, Exception? ex = null)
        {
            if (ex is not null)
                Logger.Error(ex, $"[{DateTime.Now:HH:mm:ss}] [ERROR] {message}");
            else
                Logger.Error($"[{DateTime.Now:HH:mm:ss}] [ERROR] {message}");
        }

        public static void ElementDiagnostic(string message)
        {
            if (AppSettings.LoggerConfiguration.ElementDiagnostic)
                Logger.Debug($"[{DateTime.Now:HH:mm:ss}] [EL_DEBUG] {message}");
        }

        public static void JavascriptDiagnostics(string message)
        {
            if (AppSettings.LoggerConfiguration.JavascriptDiagnostics)
                Logger.Debug($"[{DateTime.Now:HH:mm:ss}] [JS_DEBUG] {message}");
        }

        public static void TestStepLog(string message)
        {
            if (AppSettings.LoggerConfiguration.TestStepLog)
                Logger.Information($"\n  {message}\n\n");
        }

        public static void ApiTrafficLog(string message)
        {
            if (AppSettings.LoggerConfiguration.ApiTrafficLog)
                Logger.Information($"\n  {message}\n\n");
        }

        public static ILogger InitNewLogger(string loggerName)
        {
            var timestamp = NowStamp();
            _testDirectory = CreateLogDirectory(loggerName, timestamp);

            var settings = LoadSettings() ?? DefaultSettings();
            var builder = ConfigureLogger(loggerName, timestamp, settings);

            return builder.CreateLogger();
        }

        private static string NowStamp() =>
            DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

        private static DirectoryInfo CreateLogDirectory(string loggerName, string stamp) =>
            Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Logs", loggerName, stamp));

        private static AppConfig? LoadSettings()
        {
            var cfg = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            return cfg
                .GetSection("LoggerConfiguration")
                .Get<AppConfig>();
        }

        private static AppConfig DefaultSettings()
        {
            Console.WriteLine("[WARN] ...; using defaults.");
            return new AppConfig
            {
                LogLevel = "Information",
                ConsoleConversionPattern = "[{Timestamp:HH:mm:ss} {Level}] {Message}{NewLine}{Exception}",
                FileConversionPattern = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}",
                TestStepLog = false,
                ElementDiagnostic = false,
                JavascriptDiagnostics = false,
                ApiTrafficLog = false
            };
        }

        private static LoggerConfiguration ConfigureLogger(string name, string stamp, AppConfig s)
        {
            var baseCfg = new LoggerConfiguration()
                .Enrich.WithProperty("LoggerName", name)
                .MinimumLevel.Is(Enum.Parse<LogEventLevel>(s.LogLevel, true))
                .WriteTo.Console(outputTemplate: s.ConsoleConversionPattern)
                .WriteTo.File(Path.Combine(_testDirectory!.FullName, $"{name}_{stamp}.log"),
                              outputTemplate: s.FileConversionPattern);

            if (s.TestStepLog)
            {
                baseCfg = baseCfg.WriteTo.File(
                    Path.Combine(_testDirectory.FullName, $"{name}_steps_{stamp}.log"),
                    outputTemplate: s.FileConversionPattern,
                    restrictedToMinimumLevel: LogEventLevel.Information);
            }

            return baseCfg;
        }
    }
}