Feature: Gmail Login Username Textbox
  As a Gmail user
  I want to verify the presence of the username text box
  So that I can enter my email address to log in

  Background:
    Given I navigate to Gmail login page

  @Positive @UsernameTextbox
  Scenario: Verify the presence of the username text box
    Then I should see the username text box