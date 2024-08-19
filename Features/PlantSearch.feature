Feature: Plant Search
  As a user
  I want to search for plants
  So that I can see a list of search results matching my search text
 
 Background:
	Given I am logged in as a user

  Scenario Outline: Validating the plant search results for different search texts
    Given I am on the plant search page
    When I search for "<searchText>"
    Then each result should contain "<searchText>"
 
    Examples:
      | searchText |
      | abies      |
      | pinus      |
      | Castanea   |
      | acacia     |
      | Chara      |

    Scenario Outline: Validating the navigation to plant details page
    Given I am on the plant search page
    When I search for "<searchText>"
    And I select a plant from the list "<searchText>"
    And I click continue on the search page
    Then I should see the country page

    Examples:
      | searchText |
      | abies      |
      | pinus      |
      
    Scenario: Validating the error page when no data selected
    Given I am on the plant search page
    And I click continue on the search page
    Then I should see the error page to enter the details

    Scenario Outline: Validating the no results component
    Given I am on the plant search page
    When I search for "<searchText>"
    Then I should see the no results component

    Examples:
      | searchText |
      | xyz123      |

   