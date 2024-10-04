Feature: Update and Delete Pet Information

  Scenario: Successfully update a pet's information
    Given I have the details of the pet "1234", "Rover", "available"
    When I send a PUT request to the "pet/1234" endpoint with the updated pet's details
    Then the pet should be updated in the store's inventory
    And the response status code should be 200
    And the response should contain the updated pet name "Rover" and status "available"

  Scenario: Successfully delete a pet from the store
    Given I have the details of the pet "1234"
    When I send a DELETE request to the "pet/1234" endpoint
    Then the pet should be removed from the store's inventory
    And the response status code should be 200