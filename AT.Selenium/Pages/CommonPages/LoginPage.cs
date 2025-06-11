using OpenQA.Selenium;

namespace AT.Selenium.Pages.CommonPages
{
    public class LoginPage : BasePage
    {
        private readonly By userNameInput = By.Id("user-name");
        private readonly By passwordInput = By.Id("password");
        private readonly By loginButtonElement = By.Id("login-button");

        public LoginPage()
        {
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        public void EnterUsername(string username) =>
            WaitForElementIsVisible(userNameInput).SendKeys(username);

        public void EnterPassword(string password) =>
            WaitForElementIsVisible(passwordInput).SendKeys(password);

        public void ClickLoginButton() =>
            WaitForElementToBeClickable(loginButtonElement).Click();
    }
}