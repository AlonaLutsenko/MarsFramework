using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Serilog;
using Serilog.Events;
using AppConfig = AT.Framework.Models.Appsettings.LoggerConfiguration;
using SerilogConf = Serilog.LoggerConfiguration;

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
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            _testDirectory = Directory.CreateDirectory(
                Path.Combine(Directory.GetCurrentDirectory(), "Logs", loggerName, timestamp));

            var configRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var settings = configRoot
                .GetSection(nameof(Models.Appsettings.LoggerConfiguration))
                .Get<AppConfig>();

            if (settings == null)
            {
                settings = new AppConfig
                {
                    LogLevel = "Information",
                    ConsoleConversionPattern = "[{Timestamp:HH:mm:ss} {Level}] {Message}{NewLine}{Exception}",
                    FileConversionPattern = "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}",
                    TestStepLog = false,
                    ElementDiagnostic = false,
                    JavascriptDiagnostics = false,
                    ApiTrafficLog = false
                };
                Console.WriteLine("[WARN] appsettings.json LoggerConfiguration section not found; using defaults.");            
            }

            var builder = new SerilogConf()
                .Enrich.WithProperty("LoggerName", loggerName)
                .MinimumLevel.Is(Enum.Parse<LogEventLevel>(settings.LogLevel, true));

            builder = builder.WriteTo.Console(outputTemplate: settings.ConsoleConversionPattern);

            var generalLogPath = Path.Combine(_testDirectory.FullName, $"{loggerName}_{timestamp}.log");
            builder = builder.WriteTo.File(
                generalLogPath,
                outputTemplate: settings.FileConversionPattern,
                rollingInterval: RollingInterval.Infinite);

            if (settings.TestStepLog)
            {
                var stepsLogPath = Path.Combine(_testDirectory.FullName, $"{loggerName}_steps_{timestamp}.log");
                builder = builder.WriteTo.File(
                    stepsLogPath,
                    outputTemplate: settings.FileConversionPattern,
                    restrictedToMinimumLevel: LogEventLevel.Information,
                    rollingInterval: RollingInterval.Infinite);
            }

            return builder.CreateLogger();
        }
    }
}