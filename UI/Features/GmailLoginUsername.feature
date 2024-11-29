@UI
Feature: Gmail Login Username Functionality
  As a Gmail user
  I want to verify the username text box
  So that I can ensure it accepts valid input

  @Positive @UsernameTextbox
  Scenario: Verify username text box accepts valid email
    Given I navigate to Gmail login page
    When I enter a valid email "validuser@gmail.com" in the username text box
    Then the email should be accepted without error