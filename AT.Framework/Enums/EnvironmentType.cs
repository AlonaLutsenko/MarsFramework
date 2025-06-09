using System.ComponentModel;

namespace AT.Framework.Enums
{
    public enum EnvironmentType
    {
        [Description("DEV Environment")]
        Qa,
        [Description("Staging Environment")]
        Integ,
        [Description("Uat Environment")]
        Uat
    }
}
