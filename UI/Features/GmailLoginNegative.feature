Feature: Gmail Login Negative Scenarios
  As a Gmail user
  I want to validate negative scenarios for Gmail login
  So that I can ensure the login functionality handles errors gracefully

  @Negative @FailedLogin
  Scenario: Unsuccessful login with invalid credentials
    Given I navigate to Gmail login page
    When I enter "invaliduser@gmail.com" and "WrongPassword"
    Then I should see an error message indicating invalid credentials
