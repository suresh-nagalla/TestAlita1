using TechTalk.SpecFlow;
using FluentAssertions;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class NewPetStoreNegativeSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;

        public NewPetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _scenarioContext["PetId"] = -1;
        }

        [Given("I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            _scenarioContext["PetId"] = null;
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            var petId = _scenarioContext.ContainsKey("PetId") ? _scenarioContext["PetId"] : null;
            _response = _petBusinessLogic.DeletePet(petId);
        }

        [Then("I should receive a 404 Not Found response")]
        public void ThenIShouldReceiveA404NotFoundResponse()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            Log.Information("Received 404 Not Found response.");
        }

        [Then("I should receive a 400 Bad Request response")]
        public void ThenIShouldReceiveA400BadRequestResponse()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
            Log.Information("Received 400 Bad Request response.");
        }
    }
}
