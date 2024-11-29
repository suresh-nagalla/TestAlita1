Feature: PetStore API Negative Scenarios

  Scenario: Delete a pet with an invalid ID
    Given I have an invalid pet ID
    When I send a DELETE request to the PetStore API
    Then I should receive a 404 Not Found response

  Scenario: Delete a pet without providing an ID
    Given I do not provide a pet ID
    When I send a DELETE request to the PetStore API
    Then I should receive a 400 Bad Request response