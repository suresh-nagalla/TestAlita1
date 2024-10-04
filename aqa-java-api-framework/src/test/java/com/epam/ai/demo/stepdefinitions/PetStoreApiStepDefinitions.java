package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.api.APIRequest;
import com.epam.ai.demo.api.APIResponse;
import com.epam.ai.demo.api.HttpMethod;
import com.epam.ai.demo.entity.Pet;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.testng.Assert;

public class PetStoreApiStepDefinitions {

    private APIResponse response;
    private Pet pet;
    private ObjectMapper mapper = new ObjectMapper();

    @Given("^I have the details of the pet with id \"([^\"]*)\", name \"([^\"]*)\", and status \"([^\"]*)\"$")
    public void i_have_the_details_of_the_pet(String id, String name, String status) {
        pet = new Pet(Integer.parseInt(id), name, status);
    }

    @Given("^the pet exists in the store$")
    public void the_pet_exists_in_the_store() {
        // Code to verify the pet exists in the store
    }

    @When("^I update the pet with id \"([^\"]*)\" with new name \"([^\"]*)\" and new status \"([^\"]*)\"$")
    public void i_update_the_pet(String id, String new_name, String new_status) throws JsonProcessingException {
        pet.setName(new_name);
        pet.setStatus(new_status);
        APIRequest.createRequest("pet/" + id, mapper.writeValueAsString(pet));
        response = APIResponse.sendRequest(HttpMethod.PUT);
    }

    @Then("^the pet should be updated in the store with name \"([^\"]*)\" and status \"([^\"]*)\"$")
    public void the_pet_should_be_updated_in_the_store(String new_name, String new_status) {
        Assert.assertEquals(response.getStatusCode(), 200);
        Assert.assertTrue(response.asString().contains(new_name));
        Assert.assertTrue(response.asString().contains(new_status));
    }

    @Given("^I have the id of an existing pet \"([^\"]*)\"$")
    public void i_have_the_id_of_an_existing_pet(String id) {
        // Code to verify the pet exists with the given id
    }

    @When("^I delete the pet with id \"([^\"]*)\"$")
    public void i_delete_the_pet(String id) {
        APIRequest.createRequest("pet/" + id, "{}");
        response = APIResponse.sendRequest(HttpMethod.DELETE);
    }

    @Then("^the pet should be deleted from the store$")
    public void the_pet_should_be_deleted_from_the_store() {
        Assert.assertEquals(response.getStatusCode(), 200);
        // Additional code to verify the pet is deleted
    }

    // Additional step definitions
}