@put @positive
Feature: Update pet details

  Scenario Outline: Successfully update an existing pet's details
    Given I have the details of an existing pet with id "<id>", name "<name>", and status "<status>"
    When I send a PUT request to update the pet with id "<id>" with new name "<new_name>" and status "<new_status>"
    Then the response code should be 200
    And the response should contain the updated pet details with name "<new_name>" and status "<new_status>"

  Examples:
    | id  | name  | status    | new_name | new_status |
    | 1   | Doggo | available | Doge     | sold       |
    | 2   | Kitty | pending   | Catnip   | available  |