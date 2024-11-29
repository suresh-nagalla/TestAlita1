Feature: Gmail Login Negative Scenarios

  Scenario: Login with invalid credentials
    Given I am on the Gmail login page
    When I enter invalid credentials
    And I click the login button
    Then I should see an error message indicating invalid credentials