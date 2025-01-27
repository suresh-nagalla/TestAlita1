@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Delete Operations - Negative Scenarios
  As an API consumer
  I want to validate negative scenarios for deleting pets
  So that I can ensure proper error handling and responses

Background:
	Given the PetStore API is available and accessible

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with a non-existent ID
	Given I have a non-existent pet ID
	When I send a DELETE request to delete the pet
	Then the response status code should be 404
	And the response message should indicate that the pet was not found

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with an invalid ID format
	Given I have an invalid pet ID format
	When I send a DELETE request to delete the pet
	Then the response status code should be 400
	And the response message should indicate a bad request due to invalid ID format
