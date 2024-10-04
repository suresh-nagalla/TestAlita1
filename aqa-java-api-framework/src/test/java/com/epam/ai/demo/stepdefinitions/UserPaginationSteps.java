package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.config.ConfigManager;
import com.epam.ai.demo.models.APIRequest;
import com.epam.ai.demo.models.APIResponse;
import com.epam.ai.demo.models.HttpMethod;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.testng.Assert;

public class UserPaginationSteps {

    private APIResponse response;

    @Given("The API endpoint is set to {string}")
    public void the_api_endpoint_is_set_to(String apiEndpoint) {
        APIRequest.setBaseUri(ConfigManager.getProperty(apiEndpoint));
    }

    @When("I send a GET request to retrieve users on page {string}")
    public void i_send_a_get_request_to_retrieve_users_on_page(String page) {
        response = APIRequest.createRequest("/users?page=" + page).sendRequest(HttpMethod.GET);
    }

    @Then("The API should return a 200 OK response")
    public void the_api_should_return_a_200_ok_response() {
        Assert.assertEquals(response.getStatusCode(), 200);
    }

    @Then("The response should contain a list of users for page {string}")
    public void the_response_should_contain_a_list_of_users_for_page(String page) {
        // Implementation for checking the list of users
    }

    @Then("The response should include a \"total_pages\" field")
    public void the_response_should_include_a_total_pages_field() {
        // Implementation for checking the total_pages field
    }

    @Then("The current page should be {string}")
    public void the_current_page_should_be(String page) {
        // Implementation for checking the current page
    }
}