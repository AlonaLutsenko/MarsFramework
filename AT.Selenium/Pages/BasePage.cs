using OpenQA.Selenium;

namespace AT.Selenium.Pages
{
    public abstract class BasePage(IWebDriver driver)
    {
        protected IWebDriver Driver { get; } = driver;
    }
}
