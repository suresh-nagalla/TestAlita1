using BoDi;
using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using AutomationFramework.Core.Config;
using RestSharp;
using FluentAssertions;
using Serilog;

namespace AutomationFramework.API.StepDefinitions
{
    [Binding]
    public class PetStoreSteps
    {
        private readonly PetBusinessLogic _petBusinessLogic;
        private RestResponse _response;
        private long _petId;
        private ScenarioContext _scenarioContext;
        private string PetId = "PetID";
        public PetStoreSteps(ScenarioContext scenarioContext)
        {
            var baseUrl = ConfigManager.GetConfigValue<string>("ApiBaseUrl");
            _scenarioContext = scenarioContext;
            _petBusinessLogic = new PetBusinessLogic(baseUrl);
        }

        [Given(@"the PetStore API is available and accessible")]
        public void GivenThePetStoreAPIIsAvailableAndAccessible()
        {
            Log.Information("Verified that PetStore API is available.");
        }

        [Given(@"I have a pet creation payload with following details")]
        public void GivenIHaveAPetCreationPayloadWithFollowingDetails(Table table)
        {
            var row = table.Rows[0];
            var name = row["Name"];
            var status = row["Status"];
            var category = row["Category"];
            var tags = row["Tags"];

            _response = _petBusinessLogic.CreatePet(name, status, category, tags);
            _petId = ExtractPetIdFromResponse(_response);
            ScenarioContextHelper.SetOrReplace(_scenarioContext, PetId, _petId);
        }

        [When(@"I send a POST request to create the pet")]
        public void WhenISendAPostRequestToCreateThePet()
        {
            _response.Should().NotBeNull("Response from Create Pet API should not be null");
            Log.Information("POST request sent to create a pet with provided payload.");
        }

        [Then(@"the response status code should be (.*)")]
        public void ThenTheResponseStatusCodeShouldBe(int expectedStatusCode)
        {
            _response.StatusCode.Should().Be((System.Net.HttpStatusCode)expectedStatusCode);
            Log.Information($"Verified response status code: {_response.StatusCode}");
        }

        [Then(@"the pet should be created successfully")]
        public void ThenThePetShouldBeCreatedSuccessfully()
        {
            _response.Content.Should().NotBeNullOrEmpty("Response content should not be null or empty");
            _response.Content.Should().Contain("\"id\":", "The response should contain the 'id' of the created pet.");
            Log.Information($"Pet created successfully. Response content: {_response.Content}");
        }

        [Given(@"I have successfully created a pet with the following details")]
        public void GivenIHaveSuccessfullyCreatedAPetWithFollowingDetails(Table table)
        {
            var row = table.Rows[0];
            var name = row["Name"];
            var status = row["Status"];
            var category = row["Category"];
            var tags = row["Tags"];

            _response = _petBusinessLogic.CreatePet(name, status, category, tags);
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            _petId = ExtractPetIdFromResponse(_response);
            ScenarioContextHelper.SetOrReplace(_scenarioContext, PetId, _petId);
            Log.Information($"Pet created successfully for test. Pet ID: {_petId}");
        }

        [When(@"I retrieve the pet by ID")]
        public void WhenIRetrieveThePetByID()
        {
            var petId = _scenarioContext.Get<long>(PetId);
            _response = _petBusinessLogic.GetPetById(petId);
        }

        [Then(@"the pet details should be returned successfully")]
        public void ThenThePetDetailsShouldBeReturnedSuccessfully()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Log.Information("Pet details retrieved successfully. Response content: {Content}", _response.Content);
        }

        [When(@"I update the pet with generated ID with new details")]
        public void WhenIUpdateThePetWithGeneratedIDWithNewDetails(Table table)
        {
            var row = table.Rows[0];
            var name = row["Name"];
            var status = row["Status"];
            var category = row["Category"];
            var tags = row["Tags"];
            var petId = _scenarioContext.Get<long>(PetId);
            _response = _petBusinessLogic.UpdatePet(petId, name, status, category, tags);
        }

        [Then(@"the pet should be updated successfully")]
        public void ThenThePetShouldBeUpdatedSuccessfully()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Log.Information("Pet updated successfully. Response content: {Content}", _response.Content);
        }

        [When(@"I delete the pet with generated ID")]
        public void WhenIDeleteThePetWithGeneratedID()
        {
            var petId = _scenarioContext.Get<long>(PetId);
            _response = _petBusinessLogic.DeletePet(petId);
        }

        [Then(@"the pet should be deleted successfully")]
        public void ThenThePetShouldBeDeletedSuccessfully()
        {
            _response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            Log.Information("Pet deleted successfully.");
        }

        private long ExtractPetIdFromResponse(RestResponse response)
        {
            var petId = long.Parse(response.Content.Split("\"id\":")[1].Split(",")[0].Trim());
            return petId;
        }
    }
}
