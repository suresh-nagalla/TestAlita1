using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
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

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _scenarioContext["PetID"] = -1; // Invalid ID
        }

        [Given(@"I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            _scenarioContext["PetID"] = null; // No ID
        }

        [When(@"I attempt to delete the pet")]
        public void WhenIAttemptToDeleteThePet()
        {
            var petId = _scenarioContext.ContainsKey("PetID") ? _scenarioContext["PetID"] : null;
            _response = _petBusinessLogic.DeletePet(petId);
        }

        [Then(@"I should receive a 404 Not Found error")]
        public void ThenIShouldReceiveA404NotFoundError()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Received 404 Not Found error as expected.");
        }

        [Then(@"I should receive a 400 Bad Request error")]
        public void ThenIShouldReceiveA400BadRequestError()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            Log.Information("Received 400 Bad Request error as expected.");
        }
    }
}
