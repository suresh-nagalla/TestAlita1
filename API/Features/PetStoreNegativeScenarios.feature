Feature: PetStore API Negative Scenarios

  Scenario: Delete non-existing pet
    Given I have a pet ID that does not exist
    When I send a DELETE request to the PetStore API
    Then I should receive a 404 Not Found response

  Scenario: Delete pet with invalid ID
    Given I have an invalid pet ID
    When I send a DELETE request to the PetStore API
    Then I should receive a 400 Bad Request response