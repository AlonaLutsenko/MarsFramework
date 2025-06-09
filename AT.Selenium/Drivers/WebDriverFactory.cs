using AT.Framework;
using AT.Framework.Enums;
using AT.Framework.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AT.Selenium.Drivers
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            return AppSettings.DriverCapabilities.WebBrowser.BrowserName switch
            {
                DriverType.Chrome => CreateChromeDriver(headless: false),
                DriverType.ChromeHeadless => CreateChromeDriver(headless: true),
                DriverType.Firefox => CreateFirefoxDriver(headless: false),
                DriverType.FirefoxHeadless => CreateFirefoxDriver(headless: true),
                DriverType.Edge => CreateEdgeDriver(headless: false),
                DriverType.EdgeHeadless => CreateEdgeDriver(headless: true),
                _ => throw new NotSupportedException($"Browser type '{AppSettings.DriverCapabilities.WebBrowser.BrowserName}' is not supported.")
            };
        }

        private static IWebDriver CreateChromeDriver(bool headless)
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            if (headless) options.AddArgument("--headless=new");
            return InitDriver(new ChromeDriver(options));
        }

        private static IWebDriver CreateFirefoxDriver(bool headless)
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            var options = new FirefoxOptions();
            if (headless) options.AddArgument("--headless");
            return InitDriver(new FirefoxDriver(options));
        }

        private static IWebDriver CreateEdgeDriver(bool headless)
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            var options = new EdgeOptions();
            if (headless) options.AddArgument("headless");
            return InitDriver(new EdgeDriver(options));
        }

        private static IWebDriver InitDriver(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ConfigReader.ImplicitWait);
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
