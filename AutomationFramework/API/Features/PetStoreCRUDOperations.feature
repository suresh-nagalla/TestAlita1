Feature: PetStore API CRUD Operations

  Scenario: Verify GET operation returns status code 200
    Given I have a valid pet ID
    When I send a GET request to the PetStore API
    Then the response status code should be 200

  Scenario: Verify POST operation returns status code 201
    Given I have a valid pet payload
    When I send a POST request to the PetStore API
    Then the response status code should be 201

  Scenario: Verify PUT operation returns status code 200
    Given I have an existing pet ID and updated pet payload
    When I send a PUT request to the PetStore API
    Then the response status code should be 200

  Scenario: Verify DELETE operation returns status code 204
    Given I have an existing pet ID
    When I send a DELETE request to the PetStore API
    Then the response status code should be 204