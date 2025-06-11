using AT.Selenium.Pages.CommonPages;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Tests.WebUI.LoginTests
{
    [TestFixture]
    public class LoginTests : WebUITestBase
    {
        private readonly IConfiguration _configuration;

        public LoginTests()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }

        [Test]
        public void TestLogin()
        {
            string username = _configuration["EnvConfiguration:Users:Visual_user:Username"]!;
            string password = _configuration["EnvConfiguration:Users:Visual_user:Password"]!;

            LoginPage loginPage = new LoginPage();
            loginPage.Login(username, password);
        }
    }
}
