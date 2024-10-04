package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.config.ConfigManager;
import com.epam.ai.demo.models.APIRequest;
import com.epam.ai.demo.models.APIResponse;
import com.epam.ai.demo.models.HttpMethod;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.testng.Assert;

public class PaginationStepDefinitions {

    private APIResponse response;

    @Given("^The API endpoint is set to "([^"]*)"$")
    public void theApiEndpointIsSetTo(String apiEndpoint) {
        ConfigManager.getInstance().setApiUrl(apiEndpoint);
    }

    @When("^I send a GET request to retrieve users on page "([^"]*)"$")
    public void iSendAGetRequestToRetrieveUsersOnPage(String page) {
        String url = ConfigManager.getInstance().getApiUrl() + "?page=" + page;
        response = new APIRequest(HttpMethod.GET, url).sendRequest();
    }

    @Then("^The API should return a 200 OK response$")
    public void theApiShouldReturnAOkResponse() {
        Assert.assertEquals(response.getStatusCode(), 200);
    }

    @Then("^The response should contain a list of users for page "([^"]*)"$")
    public void theResponseShouldContainAListOfUsersForPage(String page) {
        // Assert that the response contains a list of users for the specified page
    }

    @Then("^The response should include a \"total_pages\" field$")
    public void theResponseShouldIncludeATotalPagesField() {
        // Assert that the response includes a "total_pages" field
    }

    @Then("^The current page should be "([^"]*)"$")
    public void theCurrentPageShouldBe(String page) {
        // Assert that the current page in the response is the specified page
    }
}