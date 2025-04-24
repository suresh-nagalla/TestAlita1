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
        public PetStoreNegativeSteps()
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [When(@"I delete the pet with ID (.*)")]
        public void WhenIDeleteThePetWithID(string petId)
        {
            _response = _petBusinessLogic.DeletePet(petId);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then(@"the response should contain "(.*)")]
        public void ThenTheResponseShouldContain(string expectedMessage)
        {
            _response.Content.Should().Contain(expectedMessage);
            Log.Information($"Verified response content contains: {expectedMessage}");
        }
    }
}
