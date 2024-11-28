using TechTalk.SpecFlow;
using RestSharp;
using FluentAssertions;

[Binding]
public class PetStoreDeleteSteps
{
    private readonly ScenarioContext _scenarioContext;
    private IRestResponse _response;

    public PetStoreDeleteSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When("I send a DELETE request to '(.*)'")]
    public void WhenISendADELETERequestTo(string resource)
    {
        var client = new RestClient("https://petstore.swagger.io/v2");
        var request = new RestRequest(resource, Method.DELETE);
        _response = client.Execute(request);
    }

    [Then("I should receive a '(.*)' response")]
    public void ThenIShouldReceiveAResponse(string expectedResponse)
    {
        _response.StatusCode.ToString().Should().Be(expectedResponse);
    }
}