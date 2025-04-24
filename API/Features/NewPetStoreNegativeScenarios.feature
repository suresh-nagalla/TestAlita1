Feature: Negative Scenarios for Pet Store API Delete Operation
  As an API consumer
  I want to test negative scenarios for deleting pets
  So that I can ensure the API handles errors gracefully

  @DeletePet @NegativeScenario
  Scenario: Attempt to delete a pet with a non-existent ID
    Given I have a non-existent pet ID
    When I attempt to delete the pet
    Then the response status code should be 404
    And the response message should indicate that the pet was not found

  @DeletePet @NegativeScenario
  Scenario: Attempt to delete a pet with an invalid ID format
    Given I have an invalid pet ID format
    When I attempt to delete the pet
    Then the response status code should be 400
    And the response message should indicate a bad request