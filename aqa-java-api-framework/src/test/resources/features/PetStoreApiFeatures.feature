@put @positive
Feature: Update an existing pet

  Scenario Outline: Successfully update an existing pet's information
    Given I have the details of the pet with id "<id>", name "<name>", and status "<status>"
    And the pet exists in the store
    When I update the pet with id "<id>" with new name "<new_name>" and new status "<new_status>"
    Then the pet should be updated in the store with name "<new_name>" and status "<new_status>"
    And the response status code should be 200

  Examples:
    | id  | name  | status    | new_name | new_status |
    | 1   | Doggo | available | Doge     | sold       |
    | 2   | Kitty | pending   | Catnip   | available  |

@delete @positive
Feature: Delete an existing pet

  Scenario Outline: Successfully delete an existing pet from the store
    Given I have the id of an existing pet "<id>"
    When I delete the pet with id "<id>"
    Then the pet should be deleted from the store
    And the response status code should be 200

  Examples:
    | id  |
    | 1   |
    | 2   |