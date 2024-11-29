using System;
using TechTalk.SpecFlow;
using RestSharp;
using FluentAssertions;
using API.Clients;
using Core.Utilities;

namespace API.StepDefinitions
{
    [Binding]
    public class PetStoreDeleteNegativeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PetStoreApiClient _petStoreApiClient;
        private IRestResponse _response;

        public PetStoreDeleteNegativeSteps(ScenarioContext scenarioContext, PetStoreApiClient petStoreApiClient)
        {
            _scenarioContext = scenarioContext;
            _petStoreApiClient = petStoreApiClient;
        }

        [Given("I have an invalid pet ID")]
        public void GivenIHaveAnInvalidPetID()
        {
            _scenarioContext["petId"] = "invalid-id";
        }

        [Given("I do not provide a pet ID")]
        public void GivenIDoNotProvideAPetID()
        {
            _scenarioContext["petId"] = null;
        }

        [When("I send a DELETE request to the PetStore API")]
        public void WhenISendADELETERequestToThePetStoreAPI()
        {
            var petId = _scenarioContext["petId"]?.ToString();
            _response = _petStoreApiClient.DeletePet(petId);
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)statusCode);
        }

        [Then("the response message should indicate that the pet was not found")]
        public void ThenTheResponseMessageShouldIndicateThatThePetWasNotFound()
        {
            _response.Content.Should().Contain("Pet not found");
        }

        [Then("the response message should indicate that the pet ID is required")]
        public void ThenTheResponseMessageShouldIndicateThatThePetIDIsRequired()
        {
            _response.Content.Should().Contain("Pet ID is required");
        }
    }
}