using AT.Framework.Logger;
using AT.Selenium.Drivers;
using OpenQA.Selenium;

namespace AT.Selenium.Pages
{
    public class LoginPage : BasePages
    {
        private readonly By usernameField = By.Id("user-name");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("login-button");

        public void Login(string username, string password)
        {
            var driver = Driver.GetInstance(); 
            SerilogBase.Info("Navigated to Login Page"); 
            SerilogBase.TestStepLog("User enters credentials");
            driver.FindElement(usernameField).SendKeys(username);
            driver.FindElement(passwordField).SendKeys(password);
            driver.FindElement(loginButton).Click();
        }
    }
}
