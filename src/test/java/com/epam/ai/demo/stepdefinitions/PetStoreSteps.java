package com.epam.ai.demo.stepdefinitions;

import io.cucumber.java.en.Given;
import io.cucumber.java.en.When;
import io.cucumber.java.en.Then;
import io.restassured.response.Response;
import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.*;

public class PetStoreSteps {

  private Response response;

  @Given("^I have the details of the pet "([^"]*)", "([^"]*)", "([^"]*)"$")
  public void i_have_the_details_of_the_pet(String id, String name, String status) {
    // Code to set up pet details
  }

  @When("^I send a PUT request to the "([^"]*)" endpoint with the updated pet's details$")
  public void i_send_a_PUT_request_to_the_endpoint_with_the_updated_pets_details(String endpoint) {
    // Code to send PUT request
  }

  @Then("^the pet should be updated in the store's inventory$")
  public void the_pet_should_be_updated_in_the_stores_inventory() {
    // Code to verify pet update
  }

  @Given("^I have the details of the pet "([^"]*)"$")
  public void i_have_the_details_of_the_pet(String id) {
    // Code to set up pet details for delete
  }

  @When("^I send a DELETE request to the "([^"]*)" endpoint$")
  public void i_send_a_DELETE_request_to_the_endpoint(String endpoint) {
    // Code to send DELETE request
  }

  @Then("^the pet should be removed from the store's inventory$")
  public void the_pet_should_be_removed_from_the_stores_inventory() {
    // Code to verify pet deletion
  }

  // Add more step definitions as needed
}