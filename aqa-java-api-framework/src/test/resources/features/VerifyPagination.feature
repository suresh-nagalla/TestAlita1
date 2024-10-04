Feature: Retrieve list of users with pagination

  Scenario Outline: Verify pagination when retrieving the list of users
    Given The API endpoint is set to "<API_Endpoint>"
    When I send a GET request to retrieve users on page "<Page>"
    Then The API should return a 200 OK response
    And The response should contain a list of users for page "<Page>"
    And The response should include a "total_pages" field
    And The current page should be "<Page>"

  Examples:
    | API_Endpoint                 | Page |
    | https://reqres.in/api/users  | 1    |
    | https://reqres.in/api/users  | 2    |