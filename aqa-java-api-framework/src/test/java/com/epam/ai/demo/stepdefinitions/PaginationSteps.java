package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.config.ConfigManager;
import com.epam.ai.demo.restassured.APIRequest;
import com.epam.ai.demo.restassured.APIResponse;
import com.epam.ai.demo.restassured.HttpMethod;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.testng.Assert;

import java.util.Map;

public class PaginationSteps {

    private APIResponse response;

    @Given("^The API endpoint is set to "([^"]*)"$")
    public void theApiEndpointIsSetTo(String apiEndpoint) {
        ConfigManager.getInstance().setApiUrl(apiEndpoint);
    }

    @When("^I send a GET request to retrieve users on page "([^"]*)"$")
    public void iSendAGETRequestToRetrieveUsersOnPage(String page) {
        Map<String, String> queryParams = Map.of("page", page);
        response = APIRequest.request(HttpMethod.GET, ConfigManager.getInstance().getApiUrl(), queryParams);
    }

    @Then("^The API should return a (\d+) OK response$")
    public void theApiShouldReturnAOKResponse(int statusCode) {
        Assert.assertEquals(response.getStatusCode(), statusCode);
    }

    @Then("^The response should contain a list of users for page "([^"]*)"$")
    public void theResponseShouldContainAListOfUsersForPage(String page) {
        // Assert that the response contains a list of users
        // This will require parsing the response body and verifying the page
    }

    @Then("^The response should include a "total_pages" field$")
    public void theResponseShouldIncludeATotalPagesField() {
        // Assert that the response includes a total_pages field
        // This will require parsing the response body and verifying the field exists
    }

    @Then("^The current page should be "([^"]*)"$")
    public void theCurrentPageShouldBe(String page) {
        // Assert that the current page in the response matches the expected page
        // This will require parsing the response body and verifying the page
    }
}