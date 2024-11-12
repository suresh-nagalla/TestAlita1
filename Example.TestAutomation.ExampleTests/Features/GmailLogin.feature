@GmailLogin @login @smoke
Feature: Gmail Login
  As a user, I want to be able to log in to Gmail successfully and handle incorrect credentials gracefully.

  @positive
  Scenario Outline: Successful Gmail login with valid credentials
    Given I navigate to the Gmail login page
    When I enter a valid email "<email>"
    And I enter the correct password "<password>"
    Then I should be redirected to the Gmail inbox page

    Examples:
      | email                | password      |
      | valid.user1@gmail.com | password123  |
      | valid.user2@gmail.com | mypassword!  |

  @negative
  Scenario Outline: Gmail login fails with invalid credentials
    Given I navigate to the Gmail login page
    When I enter an invalid email "<email>"
    And I enter the incorrect password "<password>"
    Then I should see an error message indicating invalid credentials

    Examples:
      | email                    | password       |
      | invalid.user1@gmail.com  | wrongpassword  |
      | invalid.user2@gmail.com  | 123456         |
      | valid.user1@gmail.com    | incorrectpwd   |