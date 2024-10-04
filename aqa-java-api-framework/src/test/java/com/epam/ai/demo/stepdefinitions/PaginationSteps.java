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

public class PaginationSteps {

    private APIResponse response;

    @Given("The API endpoint is set to {string}")
    public void the_api_endpoint_is_set_to(String apiEndpoint) {
        // Assuming ConfigManager is used to manage the API endpoint
        ConfigManager.setApiEndpoint(apiEndpoint);
    }

    @When("I send a GET request to retrieve users on page {string}")
    public void i_send_a_get_request_to_retrieve_users_on_page(String page) {
        String endpoint = ConfigManager.getApiEndpoint() + "?page=" + page;
        response = APIRequest.sendRequest(HttpMethod.GET, endpoint);
    }

    @Then("The API should return a 200 OK response")
    public void the_api_should_return_a_200_ok_response() {
        assertThat(response.getStatusCode(), equalTo(200));
    }

    @Then("The response should contain a list of users for page {string}")
    public void the_response_should_contain_a_list_of_users_for_page(String page) {
        assertThat(response.getJsonPath().getString("page"), equalTo(page));
    }

    @Then("The response should include a \"total_pages\" field")
    public void the_response_should_include_a_total_pages_field() {
        assertThat(response.getJsonPath().get("total_pages"), notNullValue());
    }

    @Then("The current page should be {string}")
    public void the_current_page_should_be(String page) {
        assertThat(response.getJsonPath().getString("page"), equalTo(page));
    }
}