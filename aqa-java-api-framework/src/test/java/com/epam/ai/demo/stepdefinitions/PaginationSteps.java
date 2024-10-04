package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.config.ConfigManager;
import com.epam.ai.demo.restassured.APIRequest;
import com.epam.ai.demo.restassured.APIResponse;
import com.epam.ai.demo.restassured.HttpMethod;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import static org.junit.Assert.*;

public class PaginationSteps {

    private APIResponse response;

    @Given("The API endpoint is set to {string}")
    public void the_api_endpoint_is_set_to(String apiEndpoint) {
        ConfigManager.getInstance().setPropertyValue("new_api_url", apiEndpoint);
    }

    @When("I send a GET request to retrieve users on page {string}")
    public void i_send_a_get_request_to_retrieve_users_on_page(String page) {
        String url = ConfigManager.getInstance().getPropertyValue("new_api_url");
        response = APIRequest.request(HttpMethod.GET, url + "?page=" + page);
    }

    @Then("The API should return a 200 OK response")
    public void the_api_should_return_a_200_ok_response() {
        assertEquals("Expected HTTP status 200", 200, response.getStatusCode());
    }

    @Then("The response should contain a list of users for page {string}")
    public void the_response_should_contain_a_list_of_users_for_page(String page) {
        // Add assertion to check the list of users
    }

    @Then("The response should include a \"total_pages\" field")
    public void the_response_should_include_a_total_pages_field() {
        // Add assertion to check the total_pages field
    }

    @Then("The current page should be {string}")
    public void the_current_page_should_be(String page) {
        // Add assertion to check the current page
    }
}