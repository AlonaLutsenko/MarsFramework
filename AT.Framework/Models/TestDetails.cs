using NUnit.Framework.Interfaces;

namespace AT.Framework.Models
{
    public class TestDetails
    {
        public TestDetails()
        {
            TestSteps = new List<TestStep>();
            AttachmentPaths = new List<string>();
            ErrorMessage = null;
        }

        public string TestName { get; set; }
        public List<TestStep> TestSteps { get; set; }
        public List<string> AttachmentPaths { get; set; }
        public string? ErrorMessage { get; set; }
        public ResultState Outcome { get; set; }
    }
}
