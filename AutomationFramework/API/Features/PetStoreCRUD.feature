Feature: PetStore CRUD Operations

Background:
    Given the API endpoint is "https://petstore.swagger.io/v2/pet"

@create @positive
Scenario: Create a new pet
    When I send a POST request with the following data:
        | id  | name    | status    |
        | 123 | Fluffy  | available |
    Then the response status code should be 200
    And the response body should contain "Fluffy"

@read @positive
Scenario: Retrieve an existing pet
    Given a pet with id 123 exists
    When I send a GET request for pet with id 123
    Then the response status code should be 200
    And the response body should contain "Fluffy"

@update @positive
Scenario: Update an existing pet
    Given a pet with id 123 exists
    When I send a PUT request with the following data:
        | id  | name    | status    |
        | 123 | Whiskers| sold      |
    Then the response status code should be 200
    And the response body should contain "Whiskers"
    And the response body should contain "sold"

@delete @positive
Scenario: Delete an existing pet
    Given a pet with id 123 exists
    When I send a DELETE request for pet with id 123
    Then the response status code should be 200

@negative
Scenario: Attempt to retrieve a non-existent pet
    When I send a GET request for pet with id 999
    Then the response status code should be 404

@negative
Scenario: Attempt to update a non-existent pet
    When I send a PUT request with the following data:
        | id  | name    | status    |
        | 999 | Ghost   | unknown   |
    Then the response status code should be 404

@negative
Scenario: Attempt to delete a non-existent pet
    When I send a DELETE request for pet with id 999
    Then the response status code should be 404