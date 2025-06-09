using Microsoft.Extensions.Configuration;

namespace AT.Framework.Helpers
{
    public static class ConfigurationHelper
    {
        private const string DefaultConfigName = "appsettings.json";

        public static IConfigurationRoot GetConfiguration(string configName = DefaultConfigName)
        {
            var basePath = Directory.GetCurrentDirectory();

            return new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile(configName, optional: true, reloadOnChange: true)
                .Build();
        }

        public static T GetBindConfiguration<T>(string section, string configName = DefaultConfigName)
        {
            var config = GetConfiguration(configName)
                .GetSection(section)
                .Get<T>(options => options.BindNonPublicProperties = true);

            if (config == null)
                throw new NullReferenceException($"Section '{section}' could not be bound from {configName}");

            return config;
        }
    }
}
