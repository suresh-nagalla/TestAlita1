@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with an invalid ID
	Given I have an invalid pet ID
	When I send a DELETE request to delete the pet
	Then the response status code should be 404
	And the pet should not be found

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet without providing an ID
	Given I do not provide a pet ID
	When I send a DELETE request to delete the pet
	Then the response status code should be 400
	And the request should be invalid