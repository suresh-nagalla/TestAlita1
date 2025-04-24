Feature: PetStore API Negative Scenarios

  Scenario: Delete a pet with an invalid ID
    Given I have an invalid pet ID
    When I send a DELETE request to the PetStore API
    Then I should receive a 404 Not Found response

  Scenario: Delete a pet with a non-existent ID
    Given I have a non-existent pet ID
    When I send a DELETE request to the PetStore API
    Then I should receive a 404 Not Found response