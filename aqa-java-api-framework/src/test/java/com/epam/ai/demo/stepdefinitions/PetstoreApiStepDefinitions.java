import org.testng.Assert;
import com.epam.ai.demo.api.APIRequest;
import com.epam.ai.demo.api.APIResponse;
import com.epam.ai.demo.api.HttpMethod;
import com.epam.ai.demo.entity.Pet;
import com.fasterxml.jackson.core.JsonProcessingException;
import io.cucumber.java.en.Given;
import io.cucumber.java.en.Then;
import io.cucumber.java.en.When;

public class PetstoreApiStepDefinitions {

    private Pet pet;
    private APIResponse response;

    @Given("I have the details of a pet with id {string}, name {string}, and status {string}")
    public void i_have_the_details_of_the_pet(String id, String name, String status) {
        pet = new Pet(Integer.parseInt(id), name, status);
    }

    @Given("the pet exists in the store")
    public void the_pet_exists_in_the_store() {
        APIRequest.createRequest("pet", pet);
        response = APIResponse.sendRequest(HttpMethod.POST);
        Assert.assertEquals(response.getStatusCode(), 200);
    }

    @When("I update the pet with id {string} with new name {string} and status {string}")
    public void i_update_the_pet_with_new_name_and_status(String id, String new_name, String new_status) throws JsonProcessingException {
        pet.setName(new_name);
        pet.setStatus(new_status);
        APIRequest.createRequest("pet/" + id, pet);
        response = APIResponse.sendRequest(HttpMethod.PUT);
    }

    @Then("the pet's information should be updated in the store")
    public void the_pet_information_should_be_updated_in_the_store() {
        Assert.assertEquals(response.getStatusCode(), 200);
        Assert.assertTrue(response.asString().contains(pet.getName()));
        Assert.assertTrue(response.asString().contains(pet.getStatus()));
    }

    @When("I delete the pet with id {string}")
    public void i_delete_the_pet_with_id(String id) {
        APIRequest.createRequest("pet/" + id, null);
        response = APIResponse.sendRequest(HttpMethod.DELETE);
    }

    @Then("the pet should be removed from the store")
    public void the_pet_should_be_removed_from_the_store() {
        Assert.assertEquals(response.getStatusCode(), 200);
        // Additional verification logic can be implemented here if needed
    }

    @Then("the response should reflect the new name {string} and status {string}")
    public void the_response_should_reflect_the_new_name_and_status(String new_name, String new_status) {
        Assert.assertTrue(response.asString().contains(new_name));
        Assert.assertTrue(response.asString().contains(new_status));
    }

    @Then("the response should confirm the deletion")
    public void the_response_should_confirm_the_deletion() {
        Assert.assertTrue(response.asString().contains("Pet deleted"));
        // The response body should contain a confirmation message or similar evidence of deletion
    }
}