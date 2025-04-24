using System;
using TechTalk.SpecFlow;
using FluentAssertions;
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
        private string _missingPetId;

        public PetStoreNegativeDeleteSteps(PetStoreApiClient client)
        {
            _client = client;
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _invalidPetId = "invalid-id";
        }

        [Given("I have a missing pet ID")]
        public void GivenIHaveAMissingPetID()
        {
            _missingPetId = string.Empty;
        }

        [When("I send a delete request to the PetStore API")]
        public void WhenISendADeleteRequestToThePetStoreAPI()
        {
            if (!string.IsNullOrEmpty(_invalidPetId))
            {
                _response = _client.DeletePet(_invalidPetId);
            }
            else if (string.IsNullOrEmpty(_missingPetId))
            {
                _response = _client.DeletePet(_missingPetId);
            }
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
}