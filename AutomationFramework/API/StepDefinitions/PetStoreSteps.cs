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
        private readonly PetStoreApiHelper _petStoreApiHelper;
        private RestResponse _response;

        public PetStoreSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _petStoreApiHelper = new PetStoreApiHelper();
        }

        [When(@"I send a GET request to retrieve a pet with ID (.*)")]
        public void WhenISendAGetRequestToRetrieveAPetWithID(int petId)
        {
            string endpoint = $"/pet/{petId}";
            _response = _petStoreApiHelper.SendGetRequest(endpoint);
            _scenarioContext["Response"] = _response;
            Log.Information("GET request sent to endpoint: {Endpoint}", endpoint);
        }
    }
}
