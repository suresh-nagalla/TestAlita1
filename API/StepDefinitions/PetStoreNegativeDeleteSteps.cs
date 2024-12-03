using TechTalk.SpecFlow;
using FluentAssertions;
using RestSharp;
using Core.Utilities;

namespace API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeDeleteSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly RestClient _client;
        private RestResponse _response;

        public PetStoreNegativeDeleteSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _client = new RestClient(ConfigManager.BaseUrl);
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _scenarioContext["petId"] = "invalid_id";
        }

        [Given("I have a non-existent pet ID")]
        public void GivenIHaveANonExistentPetID()
        {
            _scenarioContext["petId"] = 999999;
            var x =;
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            var petId = _scenarioContext["petId"].ToString();
            var request = new RestRequest($"/pet/{petId}", Method.Delete);
            _response = _client.Execute(request);
        }

        [Then("the response status code should be 404")]
        public void ThenTheResponseStatusCodeShouldBe404()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }
    }
}
