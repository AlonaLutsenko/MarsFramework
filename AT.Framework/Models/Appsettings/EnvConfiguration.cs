using AT.Framework.Enums;

namespace AT.Framework.Models.Appsettings
{
    public class EnvConfiguration
    {
        public EnvironmentType EnvironmentType { get; set; } = EnvironmentType.Qa;
        public required string BaseURL { get; set; }
        public required Dictionary<string, UserCredentials> Users { get; set; }
    }
}
