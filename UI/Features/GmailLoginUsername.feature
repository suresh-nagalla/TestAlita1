Feature: Gmail Login Username Text Box

  Scenario: Enter valid username in Gmail login
    Given I am on the Gmail login page
    When I enter a valid username in the username text box
    Then I should see the next button enabled