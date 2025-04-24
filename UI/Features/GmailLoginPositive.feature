Feature: Gmail Login Positive Scenario

  Scenario: Enter username in Gmail login
    Given I am on the Gmail login page
    When I enter a valid username
    Then I should see the next button enabled