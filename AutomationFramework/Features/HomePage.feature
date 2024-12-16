Feature: Home Page Title Verification
  Scenario: Verify the title of the landing page
    Given the user is on the landing page
    When the page is loaded
    Then the page title should be "nopCommerce demo store"