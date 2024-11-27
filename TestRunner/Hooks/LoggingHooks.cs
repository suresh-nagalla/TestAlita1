using TechTalk.SpecFlow;
using AutomationFramework.Core.Utilities;

namespace AutomationFramework.TestRunner.Hooks
{
    [Binding]
    public class LoggingHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Initialize the logger for the entire test run
            Logger.Initialize("TestRun", "General");
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            // Close and flush the logger after the entire test run
            Logger.CloseLogger();
        }
    }
}
