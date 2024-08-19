Feature: CountrySearch

Country search page allowing the use to enter a valid country from the list of countries shown and proceed to format selection
Background:
	Given I am logged in as a user

@countrySearch
Scenario Outline: Select Country from the list and navigate to format page
	
	Given I am on the Country search page 
	When I search for a country "<searchText>"
	And I select a country from the list "<searchText>"
	And I click Continue on the country page
	Then I am taken to the format selection page

    Examples:
      | searchText |
      | India      |
      | China      |

@countrySearch
Scenario: Invalid search and verify no results component 

	Given I am on the Country search page 
	When I search for a country "xyz"
	Then I see the no results displayed

@countrySearch
	Scenario: Validating the error page when no data selected

    Given  I am on the Country search page 
    When I click Continue on the country page
    Then I should see the error page to enter the country
