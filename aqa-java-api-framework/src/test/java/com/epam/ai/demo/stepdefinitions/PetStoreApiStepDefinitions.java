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

    private Pet pet;
    private APIResponse response;
    private ObjectMapper mapper = new ObjectMapper();

    @Given("^the pet with id \"([^\"]*)\" exists in the store$")
    public void the_pet_exists_in_the_store(String id) {
        pet = new Pet(id, "ExistingName", "available");
        APIRequest.createRequest("pet", mapper.writeValueAsString(pet));
        response = APIResponse.sendRequest(HttpMethod.POST);
        Assert.assertEquals(response.getStatusCode(), 200, "Failed to add pet");
    }

    @When("^I send a PUT request to update the pet with id \"([^\"]*)\" with new name \"([^\"]*)\" and new status \"([^\"]*)\"")
    public void i_send_a_put_request_to_update_the_pet(String id, String newName, String newStatus) throws JsonProcessingException {
        pet.setName(newName);
        pet.setStatus(newStatus);
        APIRequest.createRequest("pet/" + id, mapper.writeValueAsString(pet));
        response = APIResponse.sendRequest(HttpMethod.PUT);
    }

    @Then("^the pet should be updated in the store with name \"([^\"]*)\" and status \"([^\"]*)\"")
    public void the_pet_should_be_updated_in_the_store(String newName, String newStatus) {
        Assert.assertEquals(response.getStatusCode(), 200, "Failed to update pet");
        Assert.assertTrue(response.asString().contains(newName) && response.asString().contains(newStatus), "Pet update does not contain the expected name and status");
    }

    @When("^I send a DELETE request to remove the pet with id \"([^\"]*)\"")
    public void i_send_a_delete_request(String id) {
        APIRequest.createRequest("pet/" + id, null);
        response = APIResponse.sendRequest(HttpMethod.DELETE);
    }

    @Then("^the pet with id \"([^\"]*)\" should be removed from the store")
    public void the_pet_with_id_should_be_removed_from_the_store(String id) {
        Assert.assertEquals(response.getStatusCode(), 200, "Failed to delete pet");
        // Additional verification can be done by sending a GET request to confirm the pet is no longer in the store
    }
}