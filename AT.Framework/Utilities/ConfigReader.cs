using Microsoft.Extensions.Configuration;

namespace AT.Framework.Utilities
{
    public static class ConfigReader
    {
        private static readonly IConfiguration _config;

        static ConfigReader()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static string Browser => _config["BrowserCapabilities:Browser"] ?? "Chrome";

        public static bool Headless => bool.Parse(_config["BrowserCapabilities:Headless"] ?? "true");

        public static int ImplicitWait => int.Parse(_config["BrowserCapabilities:Timeouts:ImplicitWait"] ?? "10");

        //public static int BaseURL => _config["BrowserCapabilities:Timeouts:ImplicitWait"] ?? "10";
    }
}
