Feature: Petstore API PUT and DELETE operations

  @put @positive
  Scenario Outline: Successfully update a pet's information
    Given I have the details of the pet with id "<id>", name "<name>", and status "<status>"
    And I send a POST request to add the pet to the store
    When I send a PUT request to update the pet with id "<id>" with new name "<new_name>" and status "<new_status>"
    Then the pet's information should be updated in the store
    And the response status code should be 200
    And the response should contain the updated name "<new_name>" and status "<new_status>"

    Examples:
      | id   | name    | status    | new_name | new_status  |
      | 1234 | Whiskers | available | Fluffy   | sold        |
      | 5678 | Fido     | pending   | Buddy    | available   |

  @delete @positive
  Scenario Outline: Successfully delete a pet from the store
    Given I have the details of the pet with id "<id>"
    And I send a POST request to add the pet to the store
    When I send a DELETE request to remove the pet with id "<id>"
    Then the pet should be removed from the store's inventory
    And the response status code should be 200

    Examples:
      | id   |
      | 1234 |
      | 5678 |