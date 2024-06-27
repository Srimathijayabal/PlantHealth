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

        public CountrySearchStepDefinition(IWebDriver driver, ErrorPage errorPage,CountryPage countryPage)
        {
            this.driver = driver;            
            _errorPage = errorPage;
            _countryPage = countryPage; 
        }

        [Given(@"I am on the Country search page")]
        public void GivenIAmOnTheCountrySearchPage()
        {
            driver.Url = countryPage;
        }

        [When(@"I enter the country name ""([^""]*)"" in the search box")]
        public void WhenIEnterTheCountryNameInTheSearchBox(string india)
        {
            _countryPage.enterCountryName(india);
        }

        [When(@"I select an matching entry ""([^""]*)"" from the drop down")]
        public void WhenISelectAnMatchingEntryFromTheDropDown(string india)
        {
            _countryPage.selectACountry(india);
        }

        [When(@"I click Continue on the country page")]
        public void WhenIClickContinueOnTheCountryPage()
        {
            _countryPage.continueBtnClick();
        }

        [Then(@"I am taken to the format selection page")]
        public void ThenIAmTakenToTheFormatSelectionPage()
        {
            throw new PendingStepException();
        }

        [When(@"I enter the country name in the search box")]
        public void WhenIEnterTheCountryNameInTheSearchBox()
        {
            throw new PendingStepException();
        }

        [Then(@"I see the no results displayed")]
        public void ThenISeeTheNoResultsDisplayed()
        {
            throw new PendingStepException();
        }

        [Given(@"I click Continue on the country page")]
        public void GivenIClickContinueOnTheCountryPage()
        {
            throw new PendingStepException();
        }
    }
 }
