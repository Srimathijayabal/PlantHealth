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
        public string FormatPage = URLs.FormatPage;
        private IWebDriver driver;
        private ErrorPage _errorPage;
        private FormatSelectionPage _formatSelectionPage;
        private string _selectedFormat;

        public FormatSelectionStepDefintion(IWebDriver driver, ErrorPage errorPage,FormatSelectionPage formatSelectionPage)
        {
            this.driver = driver;            
            _errorPage = errorPage;
             _formatSelectionPage  = formatSelectionPage; 
        }

        [Given(@"I am on the Format selection page")]
        public void GivenIAmOnTheFormatSelectionPage()
        {
            driver.Url = FormatPage;
        }


        [When(@"I select a format ""([^""]*)""")]
        public void WhenISelectAFormat(string p0)
        {
            _selectedFormat = p0;
            _formatSelectionPage.clickRadio(p0);
        }

        [When(@"I click Continue")]
        public void WhenIClickContinue()
        {
            _formatSelectionPage.clickContinue();
        }

        [Then(@"I am taken to the plant detail page")]
        public void ThenIAmTakenToThePlantDetailPage()
        {
           string plantDetailPageUrl = driver.Url;
            plantDetailPageUrl.Contains(_selectedFormat);
        }
       

    }
}
