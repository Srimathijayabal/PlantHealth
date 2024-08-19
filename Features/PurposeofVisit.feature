Feature: PurposeofVisit

Purpose of visit page with options allowing the user to select the journey

Background:
	Given I am logged in as a user

@purpose
Scenario: Select plant import 
	
	Given I see purpose of visit page with two options
	When I can select the plant import option
	And I click continue
	Then I am taken to the journey confirmation page in the journey

@purpose
Scenario: Select pest or disease

	Given I see purpose of visit page with two options
	When I can select the pest or disease
	And I click continue
	Then I am taken to the pest page 

@purpose
Scenario: Select no option to view the error page 

	Given I see purpose of visit page with two options
	When I click continue
	Then I am taken to the error page prompting the user to select an option