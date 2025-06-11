using AT.Framework.Enums;
using AT.Framework.Logger;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;

namespace AT.Selenium.Drivers
{
    public static class Driver
    {
        [ThreadStatic] private static IWebDriver? _driver;

        public static object ScreenshotImageFormat { get; private set; }

        public static IWebDriver GetInstance()
        {
            if (_driver != null) return _driver;
            _driver = new WebDriverFactory().CreateDriver();
            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Close();
                _driver.Quit();
                _driver.Dispose();

                _driver = null;
            }
        }

        public static void KillAllDriverProcess(DriverType type = DriverType.Chrome)
        {
            string driverName = type switch
            {
                DriverType.Chrome or DriverType.ChromeHeadless => "chromedriver",
                DriverType.Firefox or DriverType.FirefoxHeadless => "geckodriver",
                DriverType.Edge or DriverType.EdgeHeadless => "msedgewebview2",
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null),
            };

            foreach (var proc in Process.GetProcessesByName(driverName))
            {
                try { proc.Kill(); }
                catch (Exception ex) { Debug.WriteLine($"Failed to kill {proc.ProcessName}: {ex.Message}"); }
            }
        }

        public static string MakeScreenShot(string? name = null)
        {
            string imagePath = string.Empty;

            try
            {
                imagePath = $"{SerilogBase.GetTestDirectoryPath().FullName}/{name ?? TestContext.CurrentContext.Test.Name}_{DateTime.Now.Ticks}.png";

                var image = ((ITakesScreenshot)GetInstance()).GetScreenshot();
                image.SaveAsFile(imagePath);
                TestContext.AddTestAttachment(imagePath);
            }
            catch (Exception ex)
            {
                SerilogBase.Error($"Can't make a screenshot, becauses Error happen: {ex.Message}");
            }

            return imagePath;
        }

        public static string SaveBrowserLog(string type, string fileType = "txt")
        {
            var browserLogPath =
                $"{SerilogBase.GetTestDirectoryPath().FullName}/SELENIUM_LOG_{type.ToUpperInvariant()}_{DateTime.Now.Ticks}.{fileType}";

            var logs = GetInstance().Manage().Logs.GetLog(type);
            using var file = new StreamWriter(browserLogPath);

            foreach (var log in logs)
            {
                var message = log.Message;
                file.WriteLine(message);
            }

            return browserLogPath;
        }
    }
}
