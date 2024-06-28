using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlantHealth.Config;
using PlantHealth.Page;
using System.Net;
using System.Security.Policy;
using TechTalk.SpecFlow;

namespace PlantHealth.StepDefinitions
{
    [Binding]
    public sealed class CountrySearchStepDefinition
    {
        public string countryPage = URLs.CountryPage;
        private IWebDriver driver;
        private CountryPage _countryPage;
        private ErrorPage _errorPage;
        private FormatSelectionPage _formatSelectionPage;

        public CountrySearchStepDefinition(IWebDriver driver, ErrorPage errorPage,CountryPage countryPage,FormatSelectionPage formatSelection)
        {
            this.driver = driver;            
            _errorPage = errorPage;
            _countryPage = countryPage; 
            _formatSelectionPage = formatSelection;
        }

        [Given(@"I am on the Country search page")]
        public void GivenIAmOnTheCountrySearchPage()
        {
            driver.Url = countryPage;
        }

        [When(@"I search for a country ""([^""]*)""")]
        public void WhenISearchForACountry(string countryName)
        {
            _countryPage.enterCountryName(countryName);
        }

        [When(@"I select a country from the list ""([^""]*)""")]
        public void WhenISelectACountryFromTheList(string countryName)
        {
            _countryPage.selectACountry(countryName);
        }

        [When(@"I click Continue on the country page")]
        public void WhenIClickContinueOnTheCountryPage()
        {
            _countryPage.continueBtnClick();
        }

        [Then(@"I am taken to the format selection page")]
        public void ThenIAmTakenToTheFormatSelectionPage()
        {
            _formatSelectionPage.IsFormatPageDisplayed();
        }      

        [Then(@"I see the no results displayed")]
        public void ThenISeeTheNoResultsDisplayed()
        {
            Assert.IsTrue(_countryPage.IsDisplayedNoresults(),"No reults component is not displayed");
        }

        [Then(@"I should see the error page to enter the country")]
        public void ThenIShouldSeeTheErrorPageToEnterTheCountry()
        {
            _errorPage.IsErrorPageEntertheNameOfCountry();
        }

    }
}
