Feature: FormatSelection

Country search page allowing the use to enter a valid country from the list of countries shown and proceed to format selection

Background:
	Given I am logged in as a user

@formatSelection
Scenario Outline: Select Country from the list and navigate to format page
	
	Given I am on the Format selection page 
	When I select a format "<plantFormat>"
	And I click Continue 
	Then I am taken to the plant detail page

Examples: 
| plantFormat        |
|Plants for planting |
|Part of a planting  |
|Produce			 |
|Wood				 |
|Isolated Bark       |


@formatSelction
	Scenario: Validating the error page when no data selected

    Given I am on the Format selection page 
    When  I click Continue 
    Then I should see the error page to enter the details
