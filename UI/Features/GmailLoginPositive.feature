Feature: Gmail Login Positive Scenario

  Scenario: Verify the Gmail login username text box
    Given I navigate to the Gmail login page
    When I enter a valid username in the username text box
    Then the username text box should contain the entered username