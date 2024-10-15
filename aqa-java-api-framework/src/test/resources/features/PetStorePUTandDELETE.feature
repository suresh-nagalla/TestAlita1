Feature: Petstore API PUT and DELETE operations

  @put @positive
  Scenario Outline: Successfully update a pet in the store
    Given I have the details of a pet with id "<id>", name "<name>", and status "<status>"
    And the pet is added to the store
    When I update the pet with id "<id>" with new name "<new_name>" and status "<new_status>"
    Then the pet should have name "<new_name>" and status "<new_status>"

    Examples:
      | id  | name  | status    | new_name | new_status |
      | 1   | Doggy | available | Doge     | sold       |

  @delete @positive
  Scenario Outline: Successfully delete a pet from the store
    Given I have the details of a pet with id "<id>", name "<name>", and status "<status>"
    And the pet is added to the store
    When I delete the pet with id "<id>"
    Then the pet with id "<id>" should no longer exist in the store

    Examples:
      | id  | name  | status    |
      | 1   | Doggy | available |