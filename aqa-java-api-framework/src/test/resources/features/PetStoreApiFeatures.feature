Feature: Petstore API PUT and DELETE operations

  @put
  Scenario: Update an existing pet in the store
    Given the pet with id "1" exists in the store
    When I send a PUT request to update the pet with id "1" with new name "Buddy" and new status "sold"
    Then the pet should be updated in the store with name "Buddy" and status "sold"

  @delete
  Scenario: Delete an existing pet from the store
    Given the pet with id "1" exists in the store
    When I send a DELETE request to remove the pet with id "1"
    Then the pet with id "1" should be removed from the store