using System;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using AutomationFramework.API.BusinessLogic;
using Newtonsoft.Json;
using Serilog;

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

    // Step definitions for each scenario will be implemented here
}