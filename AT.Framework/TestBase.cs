using AT.Framework.Enums;
using AT.Framework.Logger;
using AT.Framework.Models;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AT.Framework
{
    public abstract class TestBase
    {
        protected DriverType DriverType = AppSettings.DriverCapabilities.Browser;
        protected TestDetails TestDetails;

        protected virtual string? BaseUrl { get; set; }
        protected virtual string ProjectName => "E-commerce Order Creation Tests";

        [SetUp]
        public virtual void SetUp()
        {
            var testName = TestExecutionContext.CurrentContext.CurrentTest.Name;
            
            SerilogBase.InitNewLogger(testName);
            SerilogBase.Info($"Test '{testName}' execution has started.");
            
            TestDetails = new();
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set("ProjectName", ProjectName);
        }

        [TearDown]
        public virtual void TearDown()
        {
            SerilogBase.Info($"[TearDown] Finished test: {TestContext.CurrentContext.Test.Name} - Result: {TestContext.CurrentContext.Result.Outcome.Status}");
        }

        public void TestStep(string message)
        {
            SerilogBase.TestStepLog(message);
            TestDetails.TestSteps.Add(new TestStep
            {
                StepName = message,
                StepStatus = TestContext.CurrentContext.Result.Outcome.Status.ToString()
            });
        }
        protected virtual void HandleException()
        {
        }
    }
}
