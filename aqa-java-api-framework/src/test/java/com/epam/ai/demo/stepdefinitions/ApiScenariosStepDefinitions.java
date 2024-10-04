package com.epam.ai.demo.stepdefinitions;

import io.cucumber.java.en.Given;
import io.cucumber.java.en.When;
import io.cucumber.java.en.Then;

public class ApiScenariosStepDefinitions {

    @Given("I have the details of the pet {string}, {string}, {string}")
    public void i_have_the_details_of_the_pet(String id, String name, String status) {
        // Code to setup pet details
    }

    @When("I send a PUT request to the {string} endpoint with the updated pet's details")
    public void i_send_a_put_request_to_the_endpoint_with_the_updated_pet_s_details(String endpoint) {
        // Code to send PUT request
    }

    @Then("the pet should be updated in the store's inventory")
    public void the_pet_should_be_updated_in_the_store_s_inventory() {
        // Code to verify pet update
    }

    @Given("I have the details of the pet {string}")
    public void i_have_the_details_of_the_pet(String id) {
        // Code to setup pet details for deletion
    }

    @When("I send a DELETE request to the {string} endpoint")
    public void i_send_a_delete_request_to_the_endpoint(String endpoint) {
        // Code to send DELETE request
    }

    @Then("the pet should be removed from the store's inventory")
    public void the_pet_should_be_removed_from_the_store_s_inventory() {
        // Code to verify pet deletion
    }
}