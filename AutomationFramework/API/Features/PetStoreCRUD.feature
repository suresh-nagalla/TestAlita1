Feature: PetStore API CRUD operations

Background:
    Given the API endpoint is "https://petstore.swagger.io/v2/pet"

Scenario: Create a new pet
    When I send a POST request with the following data:
        | id | name   | status    |
        | 1  | Fluffy | available |
    Then the response status code should be 200
    And the response body should contain "Fluffy"

Scenario: Read pet by ID
    When I send a GET request
    Then the response status code should be 200
    And the response body should contain "Fluffy"

Scenario: Update existing pet
    When I send a PUT request with the following data:
        | id | name   | status |
        | 1  | Fluffy | sold   |
    Then the response status code should be 200
    And the response body should contain "sold"

Scenario: Delete a pet
    When I send a DELETE request
    Then the response status code should be 200

Scenario: Error handling for non-existent pet
    When I send a GET request for a non-existent pet
    Then the response status code should be 404
    And the response body should contain "Pet not found"

Scenario: Error handling for invalid data
    When I send a POST request with invalid data
    Then the response status code should be 400
    And the response body should contain "Invalid input"