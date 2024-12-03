Feature: Gmail Login Positive Scenarios

  Scenario: Enter valid username in Gmail login
    Given I am on the Gmail login page
    When I enter a valid username
    Then the username should be accepted