using OpenQA.Selenium;
using AutomationFramework.Core.Singleton;
using AutomationFramework.Core.Utilities;
using TechTalk.SpecFlow;
using Serilog;
using AutomationFramework.Core.Config;

namespace AutomationFramework.TestRunner.Hooks
{
    [Binding]
    public class UIHooks
    {
        private IWebDriver _driver;

        [BeforeScenario("@UI")]
        public void BeforeUIScenario(ScenarioContext scenarioContext)
        {
            var browserType = ConfigManager.GetConfigValue<string>("Browser");
            _driver = BrowserFactory.CreateBrowser(browserType);
            scenarioContext["WebDriver"] = _driver;

            // Initialize the logger for this specific scenario (UI)
            var scenarioName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
            Logger.Initialize(scenarioName, "UI");

            Log.Information($"Browser {browserType} initialized for scenario: {scenarioContext.ScenarioInfo.Title}");
        }

        [AfterScenario("@UI")]
        public void AfterUIScenario(ScenarioContext scenarioContext)
        {
            if (scenarioContext.TestError != null)
            {
                // Capture screenshot if there is an error
                var scenarioName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
                ScreenshotHelper.CaptureScreenshot(_driver, scenarioName);
            }

            if (_driver != null)
            {
                Log.Information("Closing browser.");
                _driver.Quit();
            }

            Logger.CloseLogger(); // Ensure the logger is flushed and closed after each scenario
        }
    }
}
