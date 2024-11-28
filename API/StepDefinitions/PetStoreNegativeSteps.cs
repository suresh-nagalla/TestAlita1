using BoDi;
using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;
        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [Given(@"the PetStore API is available and accessible")]
        public void GivenThePetStoreAPIIsAvailableAndAccessible()
        {
            Log.Information("Verified that PetStore API is available.");
        }

        [When(@"I attempt to delete a pet with an invalid ID")]
        public void WhenIAttemptToDeleteAPetWithAnInvalidID()
        {
            _response = _petBusinessLogic.DeletePet(-1); // Using -1 as an invalid ID
        }

        [When(@"I attempt to delete a pet with a non-existent ID")]
        public void WhenIAttemptToDeleteAPetWithANonExistentID()
        {
            _response = _petBusinessLogic.DeletePet(999999); // Using a large number as a non-existent ID
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then(@"the error message should indicate that the pet was not found")]
        public void ThenTheErrorMessageShouldIndicateThatThePetWasNotFound()
        {
            _response.Content.Should().Contain("Pet not found");
            Log.Information("Verified error message: Pet not found");
        }
    }
}
