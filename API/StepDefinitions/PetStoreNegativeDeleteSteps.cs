using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharp;
using API.Clients;

namespace API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeDeleteSteps
    {
        private readonly PetStoreApiClient _client;
        private IRestResponse _response;
        private string _invalidPetId;
        private string _nonExistentPetId;

        public PetStoreNegativeDeleteSteps(PetStoreApiClient client)
        {
            _client = client;
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _invalidPetId = "invalid-id";
        }

        [Given("I have a non-existent pet ID")]
        public void GivenIHaveANonExistentPetID()
        {
            _nonExistentPetId = "999999";
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            _response = _client.DeletePet(_invalidPetId ?? _nonExistentPetId);
        }

        [Then("I should receive a 404 Not Found response")]
        public void ThenIShouldReceiveA404NotFoundResponse()
        {
            Assert.AreEqual(404, (int)_response.StatusCode);
        }
    }
}