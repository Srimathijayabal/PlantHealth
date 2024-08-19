Feature: Plant search API tests

    Scenario: Send a post request to plant search api and verify the response
    Given I have the following search parameter
      | search      |
      | Momordica    |
    When I send a POST request 
    Then I should receive the API response with status as 200 OK
    And the plant name should contain the search text

