using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AT.Framework.Utilities
{
    public class WaitHelper
    {
        public static void WaitForElementToBeVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitForPageToLoad(IWebDriver driver, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(drv => ((IJavaScriptExecutor)drv).ExecuteScript("return document.readyState")!.Equals("complete"));
        }

        public static void WaitForAlert(IWebDriver driver, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        public static void WaitForCondition(IWebDriver driver, Func<IWebDriver, bool> condition, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(condition);
        }

        public static void WaitForElementToDisappear(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void WaitForTextToBePresentInElement(IWebDriver driver, By locator, string text, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(locator, text));
        }
    }
}
