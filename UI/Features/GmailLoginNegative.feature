@UI @NegativeScenario
Feature: Gmail Login Negative Scenarios
  As a Gmail user
  I want to ensure proper error handling for invalid login attempts
  So that the system is robust against incorrect inputs

@Negative @FailedLogin
Scenario: Attempt to login with incorrect email format
  Given I navigate to Gmail login page
  When I enter "invalidemailformat" and "ValidPassword123"
  Then I should see an error message indicating invalid email format
