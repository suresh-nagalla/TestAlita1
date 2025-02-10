Feature: PetStore API CRUD Operations

  Scenario: Get a pet successfully
    Given the API endpoint is "/pet/{petId}"
    When I send a GET request
    Then the response status code should be 200
    And the response body should contain the pet details

  Scenario: Create a new pet successfully
    Given the API endpoint is "/pet"
    When I send a POST request with the following data:
      | name    | category | status |
      | Max     | Dog      | available |
    Then the response status code should be 200
    And the response body should contain the new pet ID

  Scenario: Update an existing pet successfully
    Given the API endpoint is "/pet/{petId}"
    When I send a PUT request with the following data:
      | name    | category | status |
      | Charlie | Cat      | pending |
    Then the response status code should be 200
    And the response body should contain the updated pet details

  Scenario: Delete a pet successfully
    Given the API endpoint is "/pet/{petId}"
    When I send a DELETE request
    Then the response status code should be 204