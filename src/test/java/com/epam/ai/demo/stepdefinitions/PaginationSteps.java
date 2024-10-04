package com.epam.ai.demo.stepdefinitions;

import io.cucumber.java.en.Given;
import io.cucumber.java.en.When;
import io.cucumber.java.en.Then;
import io.restassured.RestAssured;
import io.restassured.response.Response;
import static org.hamcrest.Matchers.*;

public class PaginationSteps {
    private String apiEndpoint;
    private Response response;
    private int page;

    @Given("The API endpoint is set to {string}")
    public void setApiEndpoint(String endpoint) {
        this.apiEndpoint = endpoint;
    }

    @When("I send a GET request to retrieve users on page {string}")
    public void sendGetRequest(String page) {
        this.page = Integer.parseInt(page);
        response = RestAssured.given()
            .queryParam("page", this.page)
            .when()
            .get(apiEndpoint);
    }

    @Then("The API should return a 200 OK response")
    public void verifyResponseStatus() {
        response.then().statusCode(200);
    }

    @Then("The response should contain a list of users for page {string}")
    public void verifyUsersList(String page) {
        response.then().body("data.size()", greaterThan(0));
    }

    @Then("The response should include a \"total_pages\" field")
    public void verifyTotalPagesField() {
        response.then().body("total_pages", notNullValue());
    }

    @Then("The current page should be {string}")
    public void verifyCurrentPage(String page) {
        response.then().body("page", equalTo(Integer.parseInt(page)));
    }
}