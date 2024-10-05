@delete @positive
Feature: Delete pet details

  Scenario Outline: Successfully delete an existing pet from the store
    Given I have the details of an existing pet with id "<id>", name "<name>", and status "<status>"
    When I send a DELETE request to remove the pet with id "<id>"
    Then the response code should be 200
    And the pet with id "<id>" should no longer exist in the store

  Examples:
    | id  | name  | status    |
    | 1   | Doggo | available |
    | 2   | Kitty | pending   |