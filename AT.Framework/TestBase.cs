using AT.Framework.Constants;
using AT.Framework.Loggers;
using NUnit.Framework;

namespace AT.Framework
{
    public abstract class TestBase
    {
        protected ILogger? Logger { get; private set; }
        protected virtual string? BaseUrl { get; set; }

        [SetUp]
        public virtual void SetUp()
        {
            Logger = LoggerFactory.GetLogger(LoggerTypes.Log4Net, GetType().Name);
            Logger.Info($"[SetUp] Test started: {TestContext.CurrentContext.Test.Name}");
        }

        [TearDown]
        public virtual void TearDown()
        {
            Logger?.Info($"[TearDown] Finished test: {TestContext.CurrentContext.Test.Name}");
        }

        protected void SetLogger(ILogger logger)
        {
            Logger = logger;
        }
    }
}
