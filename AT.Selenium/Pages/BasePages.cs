using AT.Selenium.Drivers;

namespace AT.Selenium.Pages
{
    public abstract class BasePages
    {
        public void OpenPageByUrlNav()
        {
            var pageUrl = "{AppSettings.EnvConfiguration.BaseURL}";

            Driver.GetInstance().Navigate().GoToUrl(pageUrl);
        }
    }
}
