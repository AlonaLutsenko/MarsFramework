using OpenQA.Selenium;

namespace AT.Selenium.Pages
{
    public class LoginPage(IWebDriver driver) : BasePage(driver)
    {
        private readonly By usernameField = By.Id("user-name");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("login-button");

        public void Login(string username, string password)
        {
            Driver.FindElement(usernameField).SendKeys(username);
            Driver.FindElement(passwordField).SendKeys(password);
            Driver.FindElement(loginButton).Click();
        }
    }
}
