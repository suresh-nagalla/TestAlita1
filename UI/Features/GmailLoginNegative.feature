@UI @NegativeScenario
Feature: Gmail Login Negative Scenarios
  As a Gmail user
  I want to handle login errors gracefully
  So that I can ensure security and proper user feedback

  @Negative @FailedLogin
  Scenario: Attempt to login with an invalid email format
    Given I navigate to Gmail login page
    When I enter "invalidemail" and "ValidPassword123"
    Then I should see an error message indicating invalid email format
