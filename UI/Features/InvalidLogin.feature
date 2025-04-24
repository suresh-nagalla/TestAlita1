Feature: Invalid Login Test
  Scenario: Login fails
    Given user goes to login page
    When user enters wrong username and password
    Then login fails
    And login fails
