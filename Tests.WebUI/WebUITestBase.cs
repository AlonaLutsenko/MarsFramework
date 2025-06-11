using AT.Framework;
using AT.Framework.Logger;
using AT.Framework.Utilities;
using AT.Selenium.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Tests.WebUI
{
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

        protected override void HandleException()
        {
            try
            {
                TestDetails.AttachmentPaths.Add(Driver.MakeScreenShot());
                TestDetails.AttachmentPaths.Add(SerilogBase.GetLogFilePath(TestContext.CurrentContext.Test.FullName));
                TestDetails.AttachmentPaths.Add(Driver.SaveBrowserLog(LogType.Browser));
            }
            catch (Exception ex)
            {
                SerilogBase.Error($"Take ScreenShot or Browser Logs failed!, {ex}");
            }
        }
    }
}
