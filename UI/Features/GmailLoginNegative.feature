@Negative @FailedLogin
Scenario: Attempt to login with an invalid email format
	Given I navigate to Gmail login page
	When I enter "invalidemail" and "Test@1234"
	Then I should see an error message