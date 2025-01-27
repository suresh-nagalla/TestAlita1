using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class NewPetStoreDeleteNegativeSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private ScenarioContext _scenarioContext;
        public NewPetStoreDeleteNegativeSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [Given(@"I have a non-existent pet ID")]
        public void GivenIHaveANonExistentPetID()
        {
            _scenarioContext["PetID"] = 999999;
            Log.Information("Using a non-existent pet ID: 999999");
        }

        [Given(@"I have an invalid pet ID format")]
        public void GivenIHaveAnInvalidPetIDFormat()
        {
            _scenarioContext["PetID"] = "invalid-id";
            Log.Information("Using an invalid pet ID format: invalid-id");
        }

        [When(@"I send a DELETE request to delete the pet")]
        public void WhenISendADELETERequestToDeleteThePet()
        {
            var petId = _scenarioContext["PetID"].ToString();
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

        [Then(@"the response message should indicate a bad request due to invalid ID format")]
        public void ThenTheResponseMessageShouldIndicateABadRequestDueToInvalidIDFormat()
        {
            _response.Content.Should().Contain("Invalid ID format");
            Log.Information("Verified response message: Invalid ID format");
        }
    }
}
