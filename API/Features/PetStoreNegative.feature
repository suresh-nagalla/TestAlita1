@PetStoreAPI @NegativeScenario
Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to handle errors gracefully
  So that I can ensure robustness in my API interactions

  @DeletePet @NegativeScenario
  Scenario: Attempt to delete a pet with an invalid ID
    Given I have an invalid pet ID
    When I attempt to delete the pet
    Then I should receive a 404 Not Found error

  @DeletePet @NegativeScenario
  Scenario: Attempt to delete a pet without providing an ID
    Given I do not provide a pet ID
    When I attempt to delete the pet
    Then I should receive a 400 Bad Request error
