@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with a non-existent ID
	Given I have a non-existent pet ID
	When I attempt to delete the pet
	Then the response status code should be 404
	And the error message should indicate that the pet was not found

@DeletePet @NegativeScenario
Scenario: Attempt to delete a pet with an invalid ID format
	Given I have an invalid pet ID format
	When I attempt to delete the pet
	Then the response status code should be 400
	And the error message should indicate an invalid ID format