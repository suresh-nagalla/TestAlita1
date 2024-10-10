package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.api.APIRequest;
import com.epam.ai.demo.api.APIResponse;
import com.epam.ai.demo.api.HttpMethod;
import com.epam.ai.demo.entity.Pet;
import com.fasterxml.jackson.core.JsonProcessingException;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.testng.Assert;

public class PetstoreApiStepDefinitions {

    private Pet pet;
    private APIResponse response;

    @Given("^I have the details of the pet with id "([^"]*)", name "([^"]*)", and status "([^"]*)"$")
    public void i_have_the_details_of_the_pet(String id, String name, String status) {
        pet = new Pet(Integer.parseInt(id), name, status);
    }

    @Given("^I send a POST request to add the pet to the store$")
    public void i_send_a_post_request_to_add_the_pet() throws JsonProcessingException {
        APIRequest.createRequest("pet", pet);
        response = APIResponse.sendRequest(HttpMethod.POST);
        Assert.assertEquals(response.getStatusCode(), 200);
    }

    @When("^I send a PUT request to update the pet with id "([^"]*)" with new name "([^"]*)" and status "([^"]*)"$")
    public void i_send_a_put_request_to_update_the_pet(String id, String new_name, String new_status) throws JsonProcessingException {
        pet.setName(new_name);
        pet.setStatus(new_status);
        APIRequest.createRequest("pet/" + id, pet);
        response = APIResponse.sendRequest(HttpMethod.PUT);
    }

    @Then("^the pet's information should be updated in the store$")
    public void the_pets_information_should_be_updated() {
        Assert.assertEquals(response.getStatusCode(), 200);
        Assert.assertTrue(response.asString().contains(pet.getName()));
        Assert.assertTrue(response.asString().contains(pet.getStatus()));
    }

    @When("^I send a DELETE request to remove the pet with id "([^"]*)"$")
    public void i_send_a_delete_request_to_remove_the_pet(String id) {
        APIRequest.createRequest("pet/" + id, null);
        response = APIResponse.sendRequest(HttpMethod.DELETE);
    }

    @Then("^the pet should be removed from the store's inventory$")
    public void the_pet_should_be_removed_from_the_inventory() {
        Assert.assertEquals(response.getStatusCode(), 200);
        // Additional verification logic can be added here if needed
    }
}