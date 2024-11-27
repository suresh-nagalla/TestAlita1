using TechTalk.SpecFlow;
using AutomationFramework.Core.Utilities;
using Serilog;

namespace AutomationFramework.API.Hooks
{
    [Binding]
    public class APIHooks
    {
        [BeforeScenario("@PetStoreAPI")]
        public void BeforeApiScenario(ScenarioContext scenarioContext)
        {
            // Initialize the logger for this specific scenario (API)
            var scenarioName = scenarioContext.ScenarioInfo.Title.Replace(" ", "_");
            Logger.Initialize(scenarioName, "API");
        }

        [AfterScenario("@PetStoreAPI")]
        public void AfterApiScenario()
        {
            Log.Information("Completed API Scenario for PetStore.");
            Logger.CloseLogger(); // Ensure the logger is flushed and closed after each scenario
        }
    }
}
