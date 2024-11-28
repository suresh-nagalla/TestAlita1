using TechTalk.SpecFlow;
using FluentAssertions;
using API.Clients;

namespace API.StepDefinitions
{
    [Binding]
    public class PetStoreNegativeSteps
    {
        private readonly PetStoreApiClient _client;
        private string _invalidPetId;
        private string _response;

        public PetStoreNegativeSteps(PetStoreApiClient client)
        {
            _client = client;
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _invalidPetId = "invalid-id";
        }

        [Given("I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            _invalidPetId = string.Empty;
        }

        [When("I send a DELETE request to the PetStore API")]
        public async Task WhenISendADELETERequestToThePetStoreAPI()
        {
            _response = await _client.DeletePetAsync(_invalidPetId);
        }

        [Then("I should receive a 404 Not Found response")]
        public void ThenIShouldReceiveA404NotFoundResponse()
        {
            _response.Should().Be("404 Not Found");
        }

        [Then("I should receive a 400 Bad Request response")]
        public void ThenIShouldReceiveA400BadRequestResponse()
        {
            _response.Should().Be("400 Bad Request");
        }
    }
}