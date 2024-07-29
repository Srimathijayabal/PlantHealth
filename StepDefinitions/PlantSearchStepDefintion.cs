using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using PlantHealth.Config;
using PlantHealth.Page;
using System.Net;
using SeleniumExtras.WaitHelpers;
using TechTalk.SpecFlow;
using System.Data;
using TechTalk.SpecFlow.Infrastructure;


namespace PlantHealth.StepDefinitions
{
    [Binding]
    public sealed class PlantSearchStepDefintions
    {
        public string Url => URLs.SearchPage;
        private IWebDriver driver;
        private PlantSearchPage _plantSearchPage;
        private CountryPage _countryPage;
        private ErrorPage _errorPage;
        private readonly DataComparer _dataComparer;
        private readonly ISpecFlowOutputHelper _outputHelper;
       


        public PlantSearchStepDefintions(IWebDriver driver,
                                         PlantSearchPage plantSearchPage,
                                         CountryPage countryPage,            
                                         ErrorPage errorPage,
                                         DataComparer dataComparer,
                                         ISpecFlowOutputHelper specFlowOutputHelper)
        {

            this.driver = driver;
            _plantSearchPage = plantSearchPage;
            _countryPage = countryPage;
            _errorPage = errorPage;
            _outputHelper = specFlowOutputHelper;
            _dataComparer = dataComparer;
            

        }

        [Given(@"I am on the plant search page")]
        public void GivenIAmOnThePlantSearchPage()
        {
            driver.Url = Url;
            _plantSearchPage.IsSearchPageDisplayed();
        }

        [When(@"I search for ""([^""]*)""")]
        public void WhenISearchFor(string p0)
        {
            _plantSearchPage.enterSearchText(p0);
        }       

        [Then(@"each result should contain ""([^""]*)""")]
        public void ThenEachResultShouldContain(string p0)
        {
            _plantSearchPage.ValidateSearchResults(p0);
        }
        
        [When(@"I select a plant from the list ""([^""]*)""")]
        public void WhenISelectAPlantFromTheList(string p0)
        {
            _plantSearchPage.selectAPlant(p0);
        }

        [Given(@"I click continue on the search page")]
        [When(@"I click continue on the search page")]
        public void WhenIClickContinueOnTheSearchPage()
        {
            _plantSearchPage.clickContinue();
        }

        [Then(@"I should see the country page")]
        public void ThenIShouldSeeTheCountryPage()
        {
            
            Assert.IsTrue(_countryPage.IsSearchPageDisplayed(), "Error page is not displayed");

        }

        [Then(@"I should see the error page to enter the details")]
        public void ThenIShouldSeeTheErrorPageToEnterTheDetails()
        {
            
            Assert.IsTrue(_errorPage.IsErrorPageEnterAPlantNameIsDisplayed(), "Error page is not displayed");
        }

        [Then(@"I should see the no results component")]
        public void ThenIShouldSeeTheNoResultsComponent()
        {
            Assert.IsTrue(_plantSearchPage.noResultsFound(),"No results container is not displayed");
        }

        [Then(@"I should see the matching latinNames")]
        public void ThenIShouldSeeTheMatchingLatinNames(Table table)
        {
            
        }
        [Then(@"I should compare the data")]
        public async void ThenIShouldCompareTheData()
        {
             // Read data from an Excel file
             DataSet excelData = _dataComparer.ReadExcelFile("Latin_Name.xlsx");

            _outputHelper.WriteLine("Sheet Names:");

            foreach (DataTable table in excelData.Tables)
            {
                _outputHelper.WriteLine(table.TableName);
            }
            // Define the API endpoint and parameters
            string url = "https://phi-etl-fera-backend.test.cdp-int.defra.cloud/search/plants?";
            var parameters = new Dictionary<string, string>
        {
            { "search", "Castanea a" }
        };

            // Fetch the JSON data from the API
            Datamodel jsonData = await _dataComparer.FetchJsonFromApi(url, parameters);

            // Compare data (example: print matching records)
            _dataComparer.compareData(excelData.Tables[0], jsonData);

            }
        

        [Then(@"I should see the matching ""([^""]*)""")]
        public void ThenIShouldSeeTheMatching(string p0)
        {
            
        }


    }
}
