using AT.Framework.Enums;

namespace AT.Framework.Models.Appsettings
{
    public class EnvConfiguration
    {
        public EnvironmentType EnvironmentType { get; set; } = EnvironmentType.Qa;
        public required string URI { get; set; }
        public required string APIVersion { get; set; }
    }
}
