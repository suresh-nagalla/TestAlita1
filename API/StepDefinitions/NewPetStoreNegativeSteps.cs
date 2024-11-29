using TechTalk.SpecFlow;
using NUnit.Framework;
using API.Clients;

namespace API.StepDefinitions
{
    [Binding]
    public class NewPetStoreNegativeSteps
    {
        private readonly PetStoreApiClient _client;
        private int _responseStatusCode;

        public NewPetStoreNegativeSteps()
        {
            _client = new PetStoreApiClient();
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            // Set invalid pet ID
        }

        [Given("I have a missing pet ID")]
        public void GivenIHaveAMissingPetID()
        {
            // Set missing pet ID
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            // Send DELETE request and capture response status code
        }

        [Then("I should receive a 404 Not Found response")]
        public void ThenIShouldReceiveA404NotFoundResponse()
        {
            Assert.AreEqual(404, _responseStatusCode);
        }

        [Then("I should receive a 400 Bad Request response")]
        public void ThenIShouldReceiveA400BadRequestResponse()
        {
            Assert.AreEqual(400, _responseStatusCode);
        }
    }
}