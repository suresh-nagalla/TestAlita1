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

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _scenarioContext["PetID"] = -1;
        }

        [Given(@"I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            _scenarioContext["PetID"] = null;
        }

        [When(@"I send a DELETE request to delete the pet")]
        public void WhenISendADELETERequestToDeleteThePet()
        {
            var petId = _scenarioContext.ContainsKey("PetID") ? _scenarioContext["PetID"] : null;
            _response = _petBusinessLogic.DeletePet(petId);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then(@"the response message should indicate that the pet was not found")]
        public void ThenTheResponseMessageShouldIndicateThatThePetWasNotFound()
        {
            _response.Content.Should().Contain("Pet not found");
            Log.Information("Verified response message: Pet not found");
        }

        [Then(@"the response message should indicate that the pet ID is required")]
        public void ThenTheResponseMessageShouldIndicateThatThePetIDIsRequired()
        {
            _response.Content.Should().Contain("Pet ID is required");
            Log.Information("Verified response message: Pet ID is required");
        }
    }
}
