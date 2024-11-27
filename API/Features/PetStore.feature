@PetStoreAPI @Regression @APITesting
Feature: Pet Store API Operations
  As an API consumer
  I want to perform CRUD operations on pets
  So that I can manage pet information efficiently

Background:
	Given the PetStore API is available and accessible

@Smoke @CreatePet @PositiveScenario
Scenario Outline: Successfully create a new pet with valid data
	Given I have a pet creation payload with following details
		| Name      | Status      | Category | Tags      |
		| <PetName> | <PetStatus> | <Breed>  | <PetTags> |
	When I send a POST request to create the pet
	Then the response status code should be 200
	And the pet should be created successfully

Examples:
	| PetName  | PetStatus | Breed | PetTags  |
	| Buddy    | available | Dog   | Friendly |
	| Whiskers | pending   | Cat   | Playful  |
	| Rex      | sold      | Dog   | Guardian |

@RetrievePet @PositiveScenario
Scenario: Retrieve an existing pet by valid ID
	Given I have successfully created a pet with the following details
		| Name    | Status    | Category | Tags     |
		| Charlie | available | Dog      | Friendly |
	When I retrieve the pet by ID
	Then the pet details should be returned successfully

@UpdatePet @PositiveScenario
Scenario Outline: Update an existing pet with new details
	Given I have successfully created a pet with the following details
		| Name      | Status      | Category | Tags   |
		| <OldName> | <OldStatus> | <Breed>  | <Tags> |
	When I update the pet with generated ID with new details
		| Name      | Status      | Category | Tags   |
		| <NewName> | <NewStatus> | <Breed>  | <Tags> |
	Then the pet should be updated successfully

Examples:
	| OldName | OldStatus | NewName  | NewStatus | Breed | Tags    | PetID |
	| Max     | available | Maximus  | sold      | Dog   | Guard   | 1234  |
	| Kitty   | pending   | Princess | available | Cat   | Playful | 5678  |

@DeletePet @PositiveScenario
Scenario: Delete an existing pet by valid ID
	Given I have successfully created a pet with the following details
		| Name  | Status    | Category | Tags |
		| Daisy | available | Bird     | Calm |
	When I delete the pet with generated ID
	Then the pet should be deleted successfully
