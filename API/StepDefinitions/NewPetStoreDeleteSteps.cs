using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;

namespace API.StepDefinitions
{
    [Binding]
    public class NewPetStoreDeleteSteps
    {
        private RestClient client;
        private RestRequest request;
        private IRestResponse response;
        private string invalidPetId = "invalid-id";

        public NewPetStoreDeleteSteps()
        {
            client = new RestClient("https://petstore.swagger.io/v2");
        }

        [Given(@"I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            request = new RestRequest($"/pet/{invalidPetId}", Method.DELETE);
        }

        [Given(@"I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            request = new RestRequest("/pet/", Method.DELETE);
        }

        [When(@"I send a delete request to the PetStore API")]
        public void WhenISendADeleteRequestToThePetStoreAPI()
        {
            response = client.Execute(request);
        }

        [Then(@"I should receive a 404 Not Found response")]
        public void ThenIShouldReceiveA404NotFoundResponse()
        {
            Assert.AreEqual(404, (int)response.StatusCode);
        }

        [Then(@"I should receive a 400 Bad Request response")]
        public void ThenIShouldReceiveA400BadRequestResponse()
        {
            Assert.AreEqual(400, (int)response.StatusCode);
        }
    }
}