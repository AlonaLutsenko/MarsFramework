using AT.Framework.Utilities;
using AT.Selenium.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests.WebUI
{
    public class TestBase
    {
        protected IWebDriver? Driver;

        [SetUp]
        public void Setup()
        {
            Driver = WebDriverFactory.CreateDriver();
            Driver.Navigate().GoToUrl(ConfigReader.Browser);
        }

        [TearDown]
        public void TearDown() => Driver!.Quit();
    }
}
