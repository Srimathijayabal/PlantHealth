Feature: PlantImportConfirmation

Plant import confirmation page with options allowing the user to select the journey

@journeyConfirmation
Scenario: Select GB option
	Given I see two options
	When I select GB
	And I click continue on journey page
	Then I see the plant search page

@journeyConfirmation
Scenario: Select NI
	Given I see two options
	When I select NI
	And I click continue on journey page
	Then I see the NI signposting page

@journeyConfirmation
Scenario: Select no option to view the error page 
	Given I see two options
	When I click continue on journey page
	Then I am taken to the error page prompting the user to select an option on Where Are You Importing