Feature: Header

Scenarios for the header

Background:
	Given the user is on the homepage
	Then the user accepts cookies

@header @prod
Scenario: a user is on the homepage and can see the header logo displayed
	Then the logo should be displayed in the header

@header @prod
Scenario Outline: a user is on the homepage and can see the correct Header link
	Then the <linkName> link is displayed on the header
Examples:
	| linkName |
	| Services |
	| Work     |
	| Insights |
	| Contact  |
