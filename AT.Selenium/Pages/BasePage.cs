using AT.Framework;
using AT.Selenium.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AT.Selenium.Pages
{
    public abstract class BasePage
    {
        protected WebDriverWait Wait { get; private set; }

        public void OpenPageByUrlNav()
        {
            var pageUrl = $"{AppSettings.EnvConfiguration.BaseURL}";
            Driver.GetInstance().Navigate().GoToUrl(pageUrl);
        }

        protected IWebElement WaitForElementToBeClickable(By locator) =>
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));

        protected IWebElement WaitForElementIsVisible(By locator) =>
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));

        protected IWebElement WaitForElementToExist(By locator) =>
            Wait.Until(ExpectedConditions.ElementExists(locator));
    }
}