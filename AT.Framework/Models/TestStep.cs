using NUnit.Framework.Interfaces;

namespace AT.Framework.Models
{
    public class TestStep
    {
        public int StepNumber { get; set; }
        public string Name { get; set; }
        public int DurationTime { get; set; }
        public bool TestStepWasSkipped { get; set; }
        public bool TestStepWasRetried { get; set; }
        public ResultState ResultState { get; set; }
        public string StepName { get; set; }
        public string StepStatus { get; set; }
    }
}
