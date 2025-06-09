using AT.Framework.Enums;
using OpenQA.Selenium;
using System.Diagnostics;

namespace AT.Selenium.Drivers
{
    public static class Driver
    {
        [ThreadStatic] private static IWebDriver? _driver;

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
    }
}
