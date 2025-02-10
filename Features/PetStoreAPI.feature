Feature: PetStore API Testing

  Scenario: Verify GET operation status code
    Given the PetStore API is available
    When I send a GET request to "/pet/findByStatus?status=available"
    Then the response status code should be 200

  Scenario: Verify POST operation status code
    Given the PetStore API is available
    When I send a POST request to "/pet" with body
      """
      {
        "id": 12345,
        "category": { "id": 1, "name": "Dogs" },
        "name": "Doggie",
        "photoUrls": [ "string" ],
        "tags": [ { "id": 1, "name": "tag1" } ],
        "status": "available"
      }
      """
    Then the response status code should be 200

  Scenario: Verify PUT operation status code
    Given the PetStore API is available
    When I send a PUT request to "/pet" with body
      """
      {
        "id": 12345,
        "category": { "id": 1, "name": "Dogs" },
        "name": "DoggieUpdated",
        "photoUrls": [ "string" ],
        "tags": [ { "id": 1, "name": "tag1" } ],
        "status": "available"
      }
      """
    Then the response status code should be 200

  Scenario: Verify DELETE operation status code
    Given the PetStore API is available
    When I send a DELETE request to "/pet/12345"
    Then the response status code should be 200