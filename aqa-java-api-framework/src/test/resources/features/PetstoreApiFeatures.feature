@put @positive
Feature: Update existing pet information

  Scenario Outline: Successfully update a pet's information
    Given I have the details of a pet with id "<id>", name "<name>", and status "<status>"
    And the pet exists in the store
    When I update the pet with id "<id>" with new name "<new_name>" and status "<new_status>"
    Then the pet's information should be updated in the store
    And the response should reflect the new name "<new_name>" and status "<new_status>"

    Examples:
      | id  | name  | status    | new_name | new_status |
      | 1   | Doggo | available | Doggy    | sold       |
      | 2   | Kitty | pending   | Cat      | available  |

@delete @positive
Feature: Delete existing pet from the store

  Scenario Outline: Successfully delete a pet from the store
    Given I have the details of a pet with id "<id>"
    And the pet exists in the store
    When I delete the pet with id "<id>"
    Then the pet should be removed from the store
    And the response should confirm the deletion

    Examples:
      | id  |
      | 1   |
      | 2   |