using AT.Framework;
using AT.Framework.Utilities;
using AT.Selenium.Drivers;
using NUnit.Framework;

namespace Tests.WebUI
{
    [TestFixture]
    [Parallelizable(scope: ParallelScope.Fixtures)]
    public class WebUITestBase : TestBase
    {
        protected override string BaseUrl => $"{AppSettings.EnvConfiguration.BaseURL}";

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            Driver.GetInstance().Navigate().GoToUrl(BaseUrl!);
            WaitHelper.WaitForPageToLoad(Driver.GetInstance());
        }

        [TearDown]
        public override void TearDown()
        {
            base.TearDown();
            Driver.QuitDriver();
        }
    }
}
