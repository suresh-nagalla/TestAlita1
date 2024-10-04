Feature: Delete pet from the Petstore

  Scenario: Successfully delete a pet from the store
    Given I have the details of the pet "1234"
    When I send a DELETE request to the "/pet/1234" endpoint
    Then the pet should be removed from the store's inventory
    And the response status code should be 200