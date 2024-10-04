package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.api.APIRequest;
import com.epam.ai.demo.api.APIResponse;
import com.epam.ai.demo.api.HttpMethod;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import static org.junit.Assert.*;

public class PetStoreApiStepDefinitions {

  private APIResponse response;

  @Given("^I have the details of the pet "([^"]*)", "([^"]*)", "([^"]*)"$")
  public void i_have_the_details_of_the_pet(String id, String name, String status) {
    // Code to set up pet details
  }

  @When("^I send a PUT request to the "([^"]*)" endpoint with the updated pet's details$")
  public void i_send_a_put_request_to_the_endpoint_with_the_updated_pets_details(String endpoint) {
    response = APIRequest.send(HttpMethod.PUT, endpoint, /* Pet details here */);
  }

  @Then("^the pet should be updated in the store's inventory$")
  public void the_pet_should_be_updated_in_the_stores_inventory() {
    assertEquals("Pet update failed", 200, response.getStatusCode());
    // Additional assertions can be added here
  }

  @When("^I send a DELETE request to the "([^"]*)" endpoint$")
  public void i_send_a_delete_request_to_the_endpoint(String endpoint) {
    response = APIRequest.send(HttpMethod.DELETE, endpoint);
  }

  @Then("^the pet should be removed from the store's inventory$")
  public void the_pet_should_be_removed_from_the_stores_inventory() {
    assertEquals("Pet deletion failed", 200, response.getStatusCode());
    // Additional assertions can be added here
  }
}