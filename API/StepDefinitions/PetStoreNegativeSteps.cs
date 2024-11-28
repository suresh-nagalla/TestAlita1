using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private IRestResponse _response;

        public PetStoreNegativeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _scenarioContext["petId"] = "invalid-id";
        }

        [Given("I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            _scenarioContext["petId"] = null;
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            var client = new RestClient("https://petstore.swagger.io/v2");
            var request = new RestRequest($"/pet/{_scenarioContext["petId"]}", Method.DELETE);
            _response = client.Execute(request);
        }

        [Then("I should receive a 404 Not Found response")]
        public void ThenIShouldReceiveA404NotFoundResponse()
        {
            Assert.AreEqual(404, (int)_response.StatusCode);
        }

        [Then("I should receive a 400 Bad Request response")]
        public void ThenIShouldReceiveA400BadRequestResponse()
        {
            Assert.AreEqual(400, (int)_response.StatusCode);
        }
    }
}