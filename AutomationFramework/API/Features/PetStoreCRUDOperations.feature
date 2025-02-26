Feature: PetStore API CRUD Operations

  Scenario: Verify GET operation status code
    Given the PetStore API is available
    When I perform a GET request to retrieve a pet with ID "123"
    Then the response status code should be 200

  Scenario: Verify POST operation status code
    Given the PetStore API is available
    When I perform a POST request to add a new pet with the following details:
      | name  | category | status  |
      | Fluffy | Cats     | available |
    Then the response status code should be 201

  Scenario: Verify PUT operation status code
    Given the PetStore API is available
    When I perform a PUT request to update the pet with ID "123" with the following details:
      | name  | category | status  |
      | Fluffy | Cats     | sold    |
    Then the response status code should be 200

  Scenario: Verify DELETE operation status code
    Given the PetStore API is available
    When I perform a DELETE request to remove the pet with ID "123"
    Then the response status code should be 204
