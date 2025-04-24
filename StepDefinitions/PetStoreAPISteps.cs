using System;
using TechTalk.SpecFlow;
using RestSharp;
using NUnit.Framework;

namespace StepDefinitions
{
    [Binding]
    public class PetStoreAPISteps
    {
        private RestClient client;
        private RestRequest request;
        private IRestResponse response;

        [Given(@"the PetStore API is available")]
        public void GivenThePetStoreAPIIsAvailable()
        {
            client = new RestClient("https://petstore.swagger.io/v2");
        }

        [When(@"I send a GET request to "(.*)"")]
        public void WhenISendAGETRequestTo(string endpoint)
        {
            request = new RestRequest(endpoint, Method.GET);
            response = client.Execute(request);
        }

        [When(@"I send a POST request to "(.*)" with body "(.*)"")]
        public void WhenISendAPOSTRequestToWithBody(string endpoint, string body)
        {
            request = new RestRequest(endpoint, Method.POST);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [When(@"I send a PUT request to "(.*)" with body "(.*)"")]
        public void WhenISendAPUTRequestToWithBody(string endpoint, string body)
        {
            request = new RestRequest(endpoint, Method.PUT);
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            response = client.Execute(request);
        }

        [When(@"I send a DELETE request to "(.*)"")]
        public void WhenISendADELETERequestTo(string endpoint)
        {
            request = new RestRequest(endpoint, Method.DELETE);
            response = client.Execute(request);
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)response.StatusCode);
        }
    }
}
