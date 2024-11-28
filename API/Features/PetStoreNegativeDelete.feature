Feature: PetStore API Negative Delete Operations

  Scenario: Delete a pet with an invalid ID
    Given I have an invalid pet ID
    When I send a delete request to the PetStore API
    Then I should receive a 404 Not Found response

  Scenario: Delete a pet with a missing ID
    Given I have a missing pet ID
    When I send a delete request to the PetStore API
    Then I should receive a 400 Bad Request response