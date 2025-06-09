namespace AT.Framework.Models.Appsettings
{
    public class LoggerConfiguration
    {
        public required string LogLevel { get; set; }
        public bool TestStepLog { get; set; } = true;
        public bool ApiTrafficLog { get; set; } = true;
        public bool ElementDiagnostic { get; set; } = true;
        public bool JavascriptDiagnostics { get; set; } = true;
    }
}
