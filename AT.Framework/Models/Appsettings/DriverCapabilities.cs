using AT.Framework.Enums;

namespace AT.Framework.Models.Appsettings
{
    public class DriverCapabilities
    {
        public required WebBrowser WebBrowser { get; set; }
        public required Device Device { get; set; }
        public required TimeoutsInfo TimeoutsInfo { get; set; }
    }

    public class WebBrowser
    {
        public DriverType BrowserName { get; set; }
        public required string BrowserVersion { get; set; }
        public required string SeleniumVersion { get; set; }
        public required Uri TestExecutionBaseUrl { get; set; }
        public TargetPlatformType PlatformType { get; set; }
        public required string OSVersion { get; set; }
        public bool RunOnBrowserStack { get; set; }
        public bool Maximize { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class Device
    {
        public required string DeviceName { get; set; }
        public required string Application { get; set; }
        public required string BuildNumber { get; set; }
        public string? BuildSourceBranch { get; set; }
        public required Uri TestExecutionBaseUrl { get; set; }
        public TargetPlatformType PlatformType { get; set; }
        public required string OSVersion { get; set; }
        public bool RunOnBrowserStack { get; set; }
        public bool RealMobile { get; set; }
        public bool AutoGrantPermissions { get; set; }
        public bool AutoAcceptAlerts { get; set; }
        public bool PrintPageSourceOnFindFailure { get; set; }
    }

    public class TimeoutsInfo
    {
        public TimeSpan ElementTimeout { get; set; }
        public TimeSpan ImplicitWait { get; set; }
        public TimeSpan PageLoadTimeout { get; set; }
        public int AppiumNewCommandTimeout { get; set; }
        public int AppiumIdleTimeout { get; set; }
        public int WdaLaunchTimeout { get; set; }
    }
}
