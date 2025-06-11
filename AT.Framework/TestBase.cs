using AT.Framework.Logger;
using NUnit.Framework;

namespace AT.Framework
{
    public abstract class TestBase
    {
        protected virtual string? BaseUrl { get; set; }
        protected virtual string ProjectName => "E-commerce Order Creation Tests";

        [SetUp]
        public virtual void SetUp()
        {
            SerilogBase.InitNewLogger("Default");
            SerilogBase.Info($"[SetUp] Starting test: {TestContext.CurrentContext.Test.Name}");
        }

        [TearDown]
        public virtual void TearDown()
        {
            SerilogBase.Info($"[TearDown] Finished test: {TestContext.CurrentContext.Test.Name} - Result: {TestContext.CurrentContext.Result.Outcome.Status}");
        }
    }
}
