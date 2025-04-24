Feature: Pet Store API CRUD Operations

  Scenario: Create a new pet
    Given the API endpoint is "https://petstore.swagger.io/v2/pet"
    When I send a POST request to create a pet with name "Doggie" and status "available"
    Then the response status code should be 200
    And the response should contain the pet name "Doggie"

  Scenario: Get the created pet by ID
    Given the API endpoint is "https://petstore.swagger.io/v2/pet/{petId}"
    And the pet ID is stored
    When I send a GET request to retrieve the pet
    Then the response status code should be 200
    And the response should contain the pet name "Doggie"

  Scenario: Update the pet status
    Given the API endpoint is "https://petstore.swagger.io/v2/pet"
    And the pet ID is stored
    When I send a PUT request to update the pet status to "sold"
    Then the response status code should be 200
    And the response should contain the pet status "sold"

  Scenario: Delete the created pet
    Given the API endpoint is "https://petstore.swagger.io/v2/pet/{petId}"
    And the pet ID is stored
    When I send a DELETE request to remove the pet
    Then the response status code should be 200
    And the pet should be removed successfully
