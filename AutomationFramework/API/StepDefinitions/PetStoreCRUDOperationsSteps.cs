using TechTalk.SpecFlow;
using RestSharp;
using FluentAssertions;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreCRUDOperationsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private RestClient _client;
        private RestResponse _response;

        public PetStoreCRUDOperationsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _client = new RestClient("https://petstore.swagger.io/v2");
        }

        [Given(@"the PetStore API is available")]
        public void GivenThePetStoreAPIIsAvailable()
        {
            // Initialization or health check can be done here
        }

        [When(@"I perform a GET request to retrieve a pet with ID "(.*)"")]
        public void WhenIPerformAGETRequestToRetrieveAPetWithID(string petId)
        {
            var request = new RestRequest($"/pet/{petId}", Method.GET);
            _response = _client.Execute(request);
        }

        [When(@"I perform a POST request to add a new pet with the following details:")]
        public void WhenIPerformAPOSTRequestToAddANewPetWithTheFollowingDetails(Table table)
        {
            var petDetails = table.Rows[0];
            var request = new RestRequest("/pet", Method.POST);
            request.AddJsonBody(new {
                id = 123,
                name = petDetails["name"],
                category = new { name = petDetails["category"] },
                status = petDetails["status"]
            });
            _response = _client.Execute(request);
        }

        [When(@"I perform a PUT request to update the pet with ID "(.*)" with the following details:")]
        public void WhenIPerformAPUTRequestToUpdateThePetWithIDWithTheFollowingDetails(string petId, Table table)
        {
            var petDetails = table.Rows[0];
            var request = new RestRequest("/pet", Method.PUT);
            request.AddJsonBody(new {
                id = petId,
                name = petDetails["name"],
                category = new { name = petDetails["category"] },
                status = petDetails["status"]
            });
            _response = _client.Execute(request);
        }

        [When(@"I perform a DELETE request to remove the pet with ID "(.*)"")]
        public void WhenIPerformADELETERequestToRemoveThePetWithID(string petId)
        {
            var request = new RestRequest($"/pet/{petId}", Method.DELETE);
            _response = _client.Execute(request);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be(expectedStatusCode);
        }
    }
}
