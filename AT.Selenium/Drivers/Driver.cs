using OpenQA.Selenium;

namespace AT.Selenium.Drivers
{
    public static class Driver
    {
        private static IWebDriver? _instance;

        public static IWebDriver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = WebDriverFactory.CreateDriver();

                return _instance;
            }
        }

        public static void Quit()
        {
            if (_instance == null)
                return;

            _instance.Quit();
            _instance.Dispose();
            _instance = null;
        }

        public static void Close()
        {
            _instance?.Close();
        }
    }
}
