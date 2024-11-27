@UI
Feature: Gmail Login Functionality
  As a Gmail user
  I want to log in to my account
  So that I can access my inbox

  @Positive @SuccessfulLogin
  Scenario Outline: Successful login
    Given I navigate to Gmail login page
    When I enter "<Email>" and "<Password>"
    Then I should see the inbox

    Examples:
      | Email                 | Password     |
      | testuser@gmail.com    | Test@1234    |
      | anotheruser@gmail.com | Password@567 |

  @Negative @FailedLogin
  Scenario Outline: Unsuccessful login
    Given I navigate to Gmail login page
    When I enter "<Email>" and "<Password>"
    Then I should see an error message

    Examples:
      | Email                 | Password      |
      | invaliduser@gmail.com | WrongPassword |
      | ""                    | Test@1234     |
      | testuser@gmail.com    | ""            |
