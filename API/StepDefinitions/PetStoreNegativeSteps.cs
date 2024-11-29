using TechTalk.SpecFlow;
using NUnit.Framework;
using API.Clients;

namespace API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly PetStoreApiClient _client;
        private int _responseStatusCode;

        public PetStoreNegativeSteps(PetStoreApiClient client)
        {
            _client = client;
        }

        [Given("I have a pet ID that does not exist")]
        public void GivenIHaveAPetIDThatDoesNotExist()
        {
            // Set a non-existing pet ID
            _client.SetPetId(-1);
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            // Set an invalid pet ID
            _client.SetPetId(0);
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            _responseStatusCode = _client.DeletePet();
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