Feature: PetStore API Delete Negative Scenarios

  Scenario: Delete a pet with an invalid ID
    Given I have an invalid pet ID
    When I send a DELETE request to the PetStore API
    Then the response status code should be 404
    And the response message should indicate that the pet was not found

  Scenario: Delete a pet without providing an ID
    Given I do not provide a pet ID
    When I send a DELETE request to the PetStore API
    Then the response status code should be 400
    And the response message should indicate that the pet ID is required