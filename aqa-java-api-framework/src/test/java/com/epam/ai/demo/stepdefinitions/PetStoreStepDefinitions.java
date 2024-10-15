package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.api.APIRequest;
import com.epam.ai.demo.api.APIResponse;
import com.epam.ai.demo.api.HttpMethod;
import com.epam.ai.demo.entity.Pet;
import com.epam.ai.demo.utils.ConfigManager;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.testng.Assert;

public class PetStoreStepDefinitions {

    private Pet pet;
    private APIResponse response;
    private ObjectMapper mapper = new ObjectMapper();

    @Given("^I have the details of a pet with id \"([^\"]*)\", name \"([^\"]*)\", and status \"([^\"]*)\"$")
    public void i_have_the_details_of_a_pet(String id, String name, String status) {
        pet = new Pet(Integer.parseInt(id), name, status);
    }

    @Given("^the pet is added to the store$")
    public void the_pet_is_added_to_the_store() {
        String endpoint = ConfigManager.getInstance().getString("pet.endpoint");
        APIRequest.createRequest(endpoint, mapper.writeValueAsString(pet));
        response = APIResponse.sendRequest(HttpMethod.POST);
        Assert.assertEquals(response.getStatusCode(), 200);
    }

    @When("^I update the pet with id \"([^\"]*)\" with new name \"([^\"]*)\" and status \"([^\"]*)\"$")
    public void i_update_the_pet(String id, String new_name, String new_status) throws JsonProcessingException {
        pet.setName(new_name);
        pet.setStatus(new_status);
        String endpoint = ConfigManager.getInstance().getString("pet.endpoint") + "/" + id;
        APIRequest.createRequest(endpoint, mapper.writeValueAsString(pet));
        response = APIResponse.sendRequest(HttpMethod.PUT);
        Assert.assertEquals(response.getStatusCode(), 200);
    }

    @Then("^the pet should have name \"([^\"]*)\" and status \"([^\"]*)\"$")
    public void the_pet_should_have_name_and_status(String name, String status) {
        Pet updatedPet = response.getBody(Pet.class);
        Assert.assertEquals(updatedPet.getName(), name);
        Assert.assertEquals(updatedPet.getStatus(), status);
    }

    @When("^I delete the pet with id \"([^\"]*)\"$")
    public void i_delete_the_pet(String id) {
        String endpoint = ConfigManager.getInstance().getString("pet.endpoint") + "/" + id;
        response = APIResponse.sendRequest(HttpMethod.DELETE);
        Assert.assertEquals(response.getStatusCode(), 200);
    }

    @Then("^the pet with id \"([^\"]*)\" should no longer exist in the store$")
    public void the_pet_with_id_should_no_longer_exist_in_the_store(String id) {
        String endpoint = ConfigManager.getInstance().getString("pet.endpoint") + "/" + id;
        response = APIResponse.sendRequest(HttpMethod.GET);
        Assert.assertEquals(response.getStatusCode(), 404);
    }
}