@PetStoreAPI @NegativeScenario
Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to ensure proper error handling for invalid operations
  So that the system is robust against incorrect inputs

@DeletePet @NegativeScenario
Scenario: Attempt to delete a non-existent pet
  Given I have a non-existent pet ID
  When I attempt to delete the pet
  Then the response status code should be 404
  And an error message should indicate the pet does not exist

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with invalid ID format
  Given I have an invalid pet ID format
  When I attempt to delete the pet
  Then the response status code should be 400
  And an error message should indicate invalid ID format
