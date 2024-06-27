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
    public sealed class FormatSelectionStepDefintion
    {
        public string countryPage = URLs.CountryPage;
        private IWebDriver driver;
        private CountryPage _countryPage;
        private ErrorPage _errorPage;

        public FormatSelectionStepDefintion(IWebDriver driver, ErrorPage errorPage,CountryPage countryPage)
        {
            this.driver = driver;            
            _errorPage = errorPage;
            _countryPage = countryPage; 
        }

        public void GivenIAmOnTheFormatSelectionPage()
        {
            throw new PendingStepException();
        }

        [When(@"I select a Plants for planting")]
        public void WhenISelectAPlantsForPlanting()
        {
            throw new PendingStepException();
        }

        [When(@"I click Continue")]
        public void WhenIClickContinue()
        {
            throw new PendingStepException();
        }

        [Then(@"I am taken to the plant detail page")]
        public void ThenIAmTakenToThePlantDetailPage()
        {
            throw new PendingStepException();
        }

        [Given(@"I click Continue")]
        public void GivenIClickContinue()
        {
            throw new PendingStepException();
        }
    }
 }
