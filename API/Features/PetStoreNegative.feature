Feature: PetStore API Negative Scenarios

  Scenario: Delete pet with non-existent ID
    Given the PetStore API is available and accessible
    When I delete the pet with ID 999999
    Then the response status code should be 404
    And the response should contain "Pet not found"

  Scenario: Delete pet with invalid ID
    Given the PetStore API is available and accessible
    When I delete the pet with ID abcdef
    Then the response status code should be 400
    And the response should contain "Invalid ID supplied"
