@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to handle errors gracefully
  So that I can manage pet information efficiently

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with an invalid ID
  Given the PetStore API is available and accessible
  When I attempt to delete a pet with an invalid ID
  Then the response status code should be 404
  And the error message should indicate that the pet was not found

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with a non-existent ID
  Given the PetStore API is available and accessible
  When I attempt to delete a pet with a non-existent ID
  Then the response status code should be 404
  And the error message should indicate that the pet was not found