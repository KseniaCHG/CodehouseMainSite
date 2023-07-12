Feature: CookieBanner

Scenarios with all Cookie Banner behaviours

@regression @prod @cookie-banner
Scenario: Verify that after accepting cookie the cookie banner disappears
	Given the user is on the homepage
	And the cookie banner appears
	Then the user accepts cookies
	And they refresh the page
	Then the cookie banner disappears

@regression @prod @cookie-banner
Scenario: Verify that after not accepting cookie the cookie banner reappears
	Given the user is on the homepage
	And the cookie banner appears
	And they refresh the page
	Then the cookie banner appears

@regression @prod @cookie-banner
Scenario: Verify that after closing cookie the cookie banner disappears
	Given the user is on the homepage
	And the cookie banner appears
	Then the user closes cookie banner
	And they refresh the page
	Then the cookie banner disappears

@regression @prod @cookie-banner
Scenario: Customizing the cookies (toggled on)
	Given the user is on the homepage
	When a user clicks on customize the cookies CTA
	When a user toggles on all cookies preferences
	And the user saves its preferences
	And they refresh the page
	Then the user clicks on Cookie policy
	And the user clicks on Cookie Settings
	Then the cookie preferences should be all toggled on

	
@regression @prod @cookie-banner
Scenario: Customizing the cookies (toggled off)
	Given the user is on the homepage
	When a user clicks on customize the cookies CTA
	When a user toggles on all cookies preferences
	And the user saves its preferences
	And they refresh the page
	Then the user clicks on Cookie policy
	And the user clicks on Cookie Settings
	When a user toggles off all cookies preferences
	And the user saves its preferences
	And they refresh the page
	Then the user clicks on Cookie policy
	And the user clicks on Cookie Settings
	Then the cookie preferences should be all toggled off