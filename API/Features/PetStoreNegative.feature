Feature: Pet Store API Negative Scenarios
  As an API consumer
  I want to validate negative scenarios for Pet Store API
  So that I can ensure the API handles errors gracefully

  @DeletePet @NegativeScenario
  Scenario: Delete a pet with invalid ID
    Given I have an invalid pet ID
    When I send a DELETE request to delete the pet
    Then the response status code should be 404
    And the response message should indicate that the pet was not found

  @DeletePet @NegativeScenario
  Scenario: Delete a pet without providing an ID
    Given I do not provide a pet ID
    When I send a DELETE request to delete the pet
    Then the response status code should be 400
    And the response message should indicate that the pet ID is required
