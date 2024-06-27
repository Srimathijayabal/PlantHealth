Feature: Compare API response with Excel data
 
  Scenario: Send a POST request with parameters and compare the response with Excel data
    Given I have the following search parameter
      | search      |
      | abies a     |
    And I have the Excel file "Latin_Name.xlsx" with the data
    When I send a POST request to "https://phi-etl-fera-backend.test.cdp-int.defra.cloud/search/plants?" with these parameters
    Then the API response should match the data in the Excel file

