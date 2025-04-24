Feature: Gmail Login Negative Scenarios

  Scenario: Login with invalid credentials
    Given I navigate to Gmail login page
    When I enter "invalid_user@gmail.com" and "wrongpassword"
    Then I should see an error message
