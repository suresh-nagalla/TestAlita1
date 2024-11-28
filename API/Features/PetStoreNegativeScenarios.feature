Feature: PetStore API Negative Scenarios for Delete Operation

  Scenario: Attempt to delete a pet with a non-existent ID
    Given a non-existent pet ID
    When attempting to delete the pet
    Then the response status code should be 404
    And the error message should indicate that the pet was not found

  Scenario: Attempt to delete a pet with an invalid ID format
    Given an invalid pet ID format
    When attempting to delete the pet
    Then the response status code should be 400
    And the error message should indicate an invalid ID format