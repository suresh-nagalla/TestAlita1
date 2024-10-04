
Feature: Example

@ExampleLogin
Scenario: To perform simple login on swaglabs
	Given 'DefaultUser' user logs into WebApp
	Then Home screen is displayed
