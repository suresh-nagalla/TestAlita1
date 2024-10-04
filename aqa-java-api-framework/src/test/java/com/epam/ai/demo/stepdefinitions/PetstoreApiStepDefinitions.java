package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.APIRequest;
import com.epam.ai.demo.APIResponse;
import com.epam.ai.demo.HttpMethod;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import static org.junit.Assert.*;

public class PetstoreApiStepDefinitions {

    private APIResponse response;

    @Given("^I have the details of the pet "([^"]*)", "([^"]*)", "([^"]*)"$")
    public void i_have_the_details_of_the_pet(String id, String name, String status) {
        // Code to set up pet details
    }

    @When("^I send a PUT request to the "([^"]*)" endpoint with the updated pet's details$")
    public void i_send_a_put_request_to_the_endpoint_with_the_updated_pets_details(String endpoint) {
        response = APIRequest.send(HttpMethod.PUT, endpoint);
        // Code to include pet details in the request
    }

    @Then("^the pet should be updated in the store's inventory$")
    public void the_pet_should_be_updated_in_the_store() {
        assertEquals("Pet should be updated", 200, response.getStatusCode());
        // Additional assertions to verify the pet update
    }

    @When("^I send a DELETE request to the "([^"]*)" endpoint$")
    public void i_send_a_delete_request_to_the_endpoint(String endpoint) {
        response = APIRequest.send(HttpMethod.DELETE, endpoint);
    }

    @Then("^the delete operation should fail$")
    public void the_delete_operation_should_fail() {
        assertEquals("Delete should fail for non-existent pet", 404, response.getStatusCode());
        // Additional assertions to verify the error message
    }
}