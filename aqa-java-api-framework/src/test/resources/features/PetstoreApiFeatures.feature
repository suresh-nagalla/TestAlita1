Feature: Petstore API PUT and DELETE operations

  Scenario: Successfully update a pet's information
    Given I have the details of the pet "1234", "Rover", "available"
    When I send a PUT request to the "pet/1234" endpoint with the updated pet's details
    Then the pet should be updated in the store's inventory
    And the response status code should be 200
    And the response should contain the updated pet name "Rover" and status "available"

  Scenario: Attempt to delete a non-existent pet
    Given I have the details of the pet "9999"
    When I send a DELETE request to the "pet/9999" endpoint
    Then the delete operation should fail
    And the response status code should be 404
    And the response should contain the error message "Pet not found"