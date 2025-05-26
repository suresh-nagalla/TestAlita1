Feature: PetStore CRUD Operations

Background:
    Given the API endpoint is "https://petstore.swagger.io/v2"

@create @positive
Scenario: Create a new pet
    When I send a POST request to "/pet" with the following data:
        | id  | name    | status    |
        | 100 | Fluffy  | available |
    Then the response status code should be 200
    And the response body should contain "Fluffy"

@read @positive
Scenario: Retrieve an existing pet
    Given a pet with id 100 exists
    When I send a GET request to "/pet/100"
    Then the response status code should be 200
    And the response body should contain "Fluffy"

@update @positive
Scenario: Update an existing pet
    Given a pet with id 100 exists
    When I send a PUT request to "/pet" with the following data:
        | id  | name    | status    |
        | 100 | Whiskers| sold      |
    Then the response status code should be 200
    And the response body should contain "Whiskers"
    And the response body should contain "sold"

@delete @positive
Scenario: Delete an existing pet
    Given a pet with id 100 exists
    When I send a DELETE request to "/pet/100"
    Then the response status code should be 200

@negative
Scenario: Attempt to retrieve a non-existent pet
    When I send a GET request to "/pet/999999"
    Then the response status code should be 404