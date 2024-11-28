Feature: PetStore Delete Operation

Scenario: Attempt to delete a pet that does not exist
Given A pet with id '999999' does not exist in the PetStore
When I send a DELETE request to '/pet/999999'
Then I should receive a '404 Not Found' response

Scenario: Attempt to delete a pet with an invalid id
Given A pet with id 'invalid_id' does not exist in the PetStore
When I send a DELETE request to '/pet/invalid_id'
Then I should receive a '400 Bad Request' response