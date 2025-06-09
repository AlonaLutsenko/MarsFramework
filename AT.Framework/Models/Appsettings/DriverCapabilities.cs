using AT.Framework.Enums;

namespace AT.Framework.Models.Appsettings
{
    public class DriverCapabilities
    {
        public DriverType Browser { get; set; } = DriverType.Chrome;
        public bool Headless { get; set; } = false;
        public int ImplicitWait { get; set; } = 10;
    }
}
