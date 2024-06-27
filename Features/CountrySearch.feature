Feature: CountrySearch

Country search page allowing the use to enter a valid country from the list of countries shown and proceed to format selection

@countrySearch
Scenario: Select Country from the list and navigate to format page
	
	Given I am on the Country search page 
	When I enter the country name "India" in the search box
	And I select an matching entry "India" from the drop down
	And I click Continue on the country page
	Then I am taken to the format selection page

@countrySearch
Scenario: Invalid search and verify no results component 

	Given I am on the Country search page 
	When I enter the country name "xyzz" in the search box
	Then I see the no results displayed

@countrySearch
	Scenario: Validating the error page when no data selected

    Given  I am on the Country search page 
    And I click Continue on the country page
    Then I should see the error page to enter the details
