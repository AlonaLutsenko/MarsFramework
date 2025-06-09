using Microsoft.Extensions.Configuration;

namespace AT.Framework.Helpers
{
    public static class ConfigurationHelper
    {
        private const string configName = "appsettings.json";

        public static IConfigurationRoot GetConfiguration(string configName = configName)
        {
            var basePath = Directory.GetCurrentDirectory();

            return new ConfigurationBuilder().SetBasePath(basePath)
                .AddJsonFile(configName, optional: true, reloadOnChange: true).Build();
        }

        public static T GetBindConfiguration<T>(string section, string configName = configName)
        {
            var config = GetConfiguration(configName)
                .GetSection(section)
                .Get<T>(x => x.BindNonPublicProperties = true);

            if (config == null)
                throw new NullReferenceException("Config was not read corectly.");

            return config;
        }
    }
}
