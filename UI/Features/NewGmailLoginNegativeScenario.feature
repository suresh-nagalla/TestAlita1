Feature: Gmail Login Negative Scenario

  Scenario: Login with invalid credentials
    Given I navigate to the Gmail login page
    When I enter an invalid username and password
    And I click the login button
    Then I should see an error message indicating invalid credentials