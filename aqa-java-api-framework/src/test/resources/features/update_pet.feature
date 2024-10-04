Feature: Update pet information in the Petstore

  Scenario: Successfully update a pet's information
    Given I have the details of the pet "1234", "Rover", "available"
    When I send a PUT request to the "/pet" endpoint with the updated pet's details
    Then the pet should be updated in the store's inventory
    And the response status code should be 200
    And the response should contain the updated pet name "Rover" and status "available"