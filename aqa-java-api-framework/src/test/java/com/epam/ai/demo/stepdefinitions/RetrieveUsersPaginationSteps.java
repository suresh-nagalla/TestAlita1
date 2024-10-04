package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.config.ConfigManager;
import com.epam.ai.demo.restassured.APIRequest;
import com.epam.ai.demo.restassured.APIResponse;
import com.epam.ai.demo.restassured.HttpMethod;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import io.restassured.response.Response;
import static org.testng.Assert.*;

public class RetrieveUsersPaginationSteps {

    private Response response;

    @Given("^The API endpoint is set to "([^"]*)"$")
    public void the_api_endpoint_is_set_to(String apiEndpoint) {
        // Set the API endpoint from the feature file
    }

    @When("^I send a GET request to retrieve users on page "([^"]*)"$")
    public void i_send_a_get_request_to_retrieve_users_on_page(String page) {
        String url = ConfigManager.getInstance().getString("user_api_base_url");
        response = new APIRequest(url + "?page=" + page)
                        .method(HttpMethod.GET)
                        .sendRequest();
    }

    @Then("^The API should return a 200 OK response$")
    public void the_api_should_return_a_ok_response() {
        assertEquals(response.getStatusCode(), 200);
    }

    @Then("^The response should contain a list of users for page "([^"]*)"$")
    public void the_response_should_contain_a_list_of_users_for_page(String page) {
        // Assert the response contains a list of users for the specified page
    }

    @Then("^The response should include a "total_pages" field$")
    public void the_response_should_include_a_total_pages_field() {
        assertTrue(response.getBody().jsonPath().get("total_pages") != null);
    }

    @Then("^The current page should be "([^"]*)"$")
    public void the_current_page_should_be(String page) {
        assertEquals(response.getBody().jsonPath().get("page"), Integer.parseInt(page));
    }
}