package com.epam.ai.demo.stepdefinitions;

import com.epam.ai.demo.api.APIRequest;
import com.epam.ai.demo.api.APIResponse;
import com.epam.ai.demo.api.HttpMethod;
import com.epam.ai.demo.entities.Pet;
import com.fasterxml.jackson.core.JsonProcessingException;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;
import org.testng.Assert;

public class PetStoreStepDefinitions {

    private Pet pet;
    private APIResponse response;

    @Given("^I have the details of an existing pet with id "([^"]*)", name "([^"]*)", and status "([^"]*)"$")
    public void i_have_the_details_of_an_existing_pet(String id, String name, String status) {
        pet = new Pet(Integer.parseInt(id), name, status);
    }

    @When("^I send a PUT request to update the pet with id "([^"]*)" with new name "([^"]*)" and status "([^"]*)"$")
    public void i_send_a_put_request_to_update_the_pet(String id, String new_name, String new_status) throws JsonProcessingException {
        pet.setName(new_name);
        pet.setStatus(new_status);
        response = APIRequest.createRequest("/pet/" + id, pet).sendRequest(HttpMethod.PUT);
    }

    @When("^I send a DELETE request to remove the pet with id "([^"]*)"$")
    public void i_send_a_delete_request_to_remove_the_pet(String id) {
        response = APIRequest.createRequest("/pet/" + id).sendRequest(HttpMethod.DELETE);
    }

    @Then("^the response code should be (\d+)$")
    public void the_response_code_should_be(int statusCode) {
        Assert.assertEquals(response.getStatusCode(), statusCode);
    }

    @Then("^the response should contain the updated pet details with name "([^"]*)" and status "([^"]*)"$")
    public void the_response_should_contain_the_updated_pet_details(String name, String status) {
        Assert.assertTrue(response.asString().contains(name) && response.asString().contains(status));
    }

    @Then("^the pet with id "([^"]*)" should no longer exist in the store$")
    public void the_pet_with_id_should_no_longer_exist_in_the_store(String id) {
        response = APIRequest.createRequest("/pet/" + id).sendRequest(HttpMethod.GET);
        Assert.assertEquals(response.getStatusCode(), 404);
    }
}