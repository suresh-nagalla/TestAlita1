using System;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Utilities;
using Serilog;
using Newtonsoft.Json;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly PetApiHelper _petApiHelper;
        private RestResponse _response;

        public PetStoreSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _petApiHelper = new PetApiHelper();
        }

        [Given("the API endpoint is \"(.*)\"")]
        public void GivenTheApiEndpointIs(string endpoint)
        {
            _scenarioContext["Endpoint"] = endpoint;
            Log.Information("Endpoint set to: {Endpoint}", endpoint);
        }

        [When("I send a POST request to create a pet with name \"(.*)\" and status \"(.*)\"")]
        public void WhenISendAPostRequestToCreateAPetWithNameAndStatus(string name, string status)
        {
            var pet = new { id = 0, name = name, status = status };
            _response = _petApiHelper.SendPostRequest(_scenarioContext["Endpoint"].ToString(), pet);
            _scenarioContext["PetId"] = JsonConvert.DeserializeObject<dynamic>(_response.Content).id;
            Log.Information("Response: {ResponseContent}", _response.Content);
        }

        [Then("the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int statusCode)
        {
            Assert.AreEqual(statusCode, (int)_response.StatusCode);
            Log.Information("Response status code: {StatusCode}", _response.StatusCode);
        }

        [Then("the response should contain the pet name \"(.*)\"")]
        public void ThenTheResponseShouldContainThePetName(string name)
        {
            var responseContent = JsonConvert.DeserializeObject<dynamic>(_response.Content);
            Assert.AreEqual(name, (string)responseContent.name);
            Log.Information("Pet name in response: {PetName}", responseContent.name);
        }

        [Given("the pet ID is stored")]
        public void GivenThePetIdIsStored()
        {
            Assert.IsNotNull(_scenarioContext["PetId"]);
            Log.Information("Pet ID stored: {PetId}", _scenarioContext["PetId"]);
        }

        [When("I send a GET request to retrieve the pet")]
        public void WhenISendAGetRequestToRetrieveThePet()
        {
            var endpoint = _scenarioContext["Endpoint"].ToString().Replace("{petId}", _scenarioContext["PetId"].ToString());
            _response = _petApiHelper.SendGetRequest(endpoint);
            Log.Information("Response: {ResponseContent}", _response.Content);
        }

        [When("I send a PUT request to update the pet status to \"(.*)\"")]
        public void WhenISendAPutRequestToUpdateThePetStatusTo(string status)
        {
            var pet = new { id = _scenarioContext["PetId"], name = "Doggie", status = status };
            _response = _petApiHelper.SendPutRequest(_scenarioContext["Endpoint"].ToString(), pet);
            Log.Information("Response: {ResponseContent}", _response.Content);
        }

        [Then("the response should contain the pet status \"(.*)\"")]
        public void ThenTheResponseShouldContainThePetStatus(string status)
        {
            var responseContent = JsonConvert.DeserializeObject<dynamic>(_response.Content);
            Assert.AreEqual(status, (string)responseContent.status);
            Log.Information("Pet status in response: {PetStatus}", responseContent.status);
        }

        [When("I send a DELETE request to remove the pet")]
        public void WhenISendADeleteRequestToRemoveThePet()
        {
            var endpoint = _scenarioContext["Endpoint"].ToString().Replace("{petId}", _scenarioContext["PetId"].ToString());
            _response = _petApiHelper.SendDeleteRequest(endpoint