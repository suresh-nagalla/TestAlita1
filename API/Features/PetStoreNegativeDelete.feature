Feature: PetStore API Negative Delete Scenarios

  Scenario: Delete a pet with an invalid ID
    Given I have an invalid pet ID
    When I send a DELETE request to the PetStore API
    Then the response status code should be 404

  Scenario: Delete a pet with a non-existent ID
    Given I have a non-existent pet ID
    When I send a DELETE request to the PetStore API
    Then the response status code should be 404