package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.config.ConfigManager;
import com.epam.ai.demo.restassured.APIRequest;
import com.epam.ai.demo.restassured.APIResponse;
import com.epam.ai.demo.restassured.HttpMethod;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.*;

public class UserPaginationSteps {

    private APIResponse response;

    @Given("^The API endpoint is set to "([^"]*)"$")
    public void theApiEndpointIsSetTo(String apiEndpoint) {
        ConfigManager.getInstance().setUrl(apiEndpoint);
    }

    @When("^I send a GET request to retrieve users on page "([^"]*)"$")
    public void iSendAGETRequestToRetrieveUsersOnPage(String page) {
        String url = ConfigManager.getInstance().getUrl() + "?page=" + page;
        response = new APIRequest(HttpMethod.GET, url).sendRequest();
    }

    @Then("^The API should return a (\d+) OK response$")
    public void theApiShouldReturnAOKResponse(int statusCode) {
        assertThat(response.getStatusCode(), equalTo(statusCode));
    }

    @Then("^The response should contain a list of users for page "([^"]*)"$")
    public void theResponseShouldContainAListOfUsersForPage(String page) {
        assertThat(response.getJsonPath().getString("page"), equalTo(page));
    }

    @Then("^The response should include a "total_pages" field$")
    public void theResponseShouldIncludeATotalPagesField() {
        assertThat(response.getJsonPath().get("total_pages"), notNullValue());
    }

    @Then("^The current page should be "([^"]*)"$")
    public void theCurrentPageShouldBe(String page) {
        assertThat(response.getJsonPath().getString("page"), equalTo(page));
    }
}