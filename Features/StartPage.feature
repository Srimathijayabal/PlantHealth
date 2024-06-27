Feature: Start Page

@StartPage
Scenario: Startnow CTA 
	Given I launch the URL
	When Click on Startnow
	Then I am navigated to the next page

@StartPage
Scenario: Related links works as intended
	Given I launch the URL
	When I click on the related links
	Then the links are functional

