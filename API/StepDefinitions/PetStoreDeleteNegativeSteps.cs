using TechTalk.SpecFlow;
using RestSharp;
using FluentAssertions;

[Binding]
public class PetStoreDeleteNegativeSteps
{
    private readonly ScenarioContext _scenarioContext;
    private RestClient _client;
    private RestRequest _request;
    private IRestResponse _response;

    public PetStoreDeleteNegativeSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _client = new RestClient("https://petstore.swagger.io/v2");
    }

    [Given("I have an invalid pet ID")]
    public void GivenIHaveAnInvalidPetID()
    {
        _scenarioContext["petId"] = "invalid-id";
    }

    [Given("I have a missing pet ID")]
    public void GivenIHaveAMissingPetID()
    {
        _scenarioContext["petId"] = "";
    }

    [When("I send a DELETE request to the PetStore API")]
    public void WhenISendADELETERequestToThePetStoreAPI()
    {
        var petId = _scenarioContext["petId"].ToString();
        _request = new RestRequest($"/pet/{petId}", Method.DELETE);
        _response = _client.Execute(_request);
        _scenarioContext["response"] = _response;
    }

    [Then("I should receive a 404 Not Found response")]
    public void ThenIShouldReceiveA404NotFoundResponse()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
    }

    [Then("I should receive a 400 Bad Request response")]
    public void ThenIShouldReceiveA400BadRequestResponse()
    {
        _response.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);
    }
}