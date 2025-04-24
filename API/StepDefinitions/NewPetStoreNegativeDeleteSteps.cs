using TechTalk.SpecFlow;
using FluentAssertions;
using API.Clients;
using API.BusinessLogic;

namespace API.StepDefinitions
{
    [Binding]
    public class NewPetStoreNegativeDeleteSteps
    {
        private readonly PetStoreApiClient _client;
        private readonly PetBusinessLogic _businessLogic;
        private string _invalidPetId;
        private string _nonExistentPetId;
        private IRestResponse _response;

        public NewPetStoreNegativeDeleteSteps(PetStoreApiClient client, PetBusinessLogic businessLogic)
        {
            _client = client;
            _businessLogic = businessLogic;
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
            _response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}