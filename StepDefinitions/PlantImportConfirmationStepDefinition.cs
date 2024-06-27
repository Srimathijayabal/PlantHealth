using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlantHealth.Config;
using PlantHealth.Page;
using System.Net;
using TechTalk.SpecFlow;

namespace PlantHealth.StepDefinitions
{
    [Binding]
    public sealed class PlantImportConfirmationStepDefinition
    {
        public string plantImportURL => URLs.PlantImportPage;
        private IWebDriver driver;
        private PurposeofVisitPage _purposeofVisitPage;
        private PlantImportConfirmationPage _importConfirmationPage;
        private PestPage _pestPage;
        private ErrorPage _errorPage;
        private NISignPostingPage _signPostingPageNI;
        private PlantSearchPage _plantsearchPage;

        public PlantImportConfirmationStepDefinition(IWebDriver driver, PurposeofVisitPage purposeofVisitPage, PlantImportConfirmationPage importConfirmationPage, PestPage pestPage, ErrorPage errorPage, NISignPostingPage signPostingPageNI, PlantSearchPage plantsearchPage)
        {
            this.driver = driver;
            _purposeofVisitPage = purposeofVisitPage;
            _importConfirmationPage = importConfirmationPage;
            _pestPage = pestPage;
            _errorPage = errorPage;
            _signPostingPageNI = signPostingPageNI;
            _plantsearchPage = plantsearchPage;
        }


        [Given(@"I see two options")]
        public void GivenISeeTwoOptions()
        {
            driver.Url = plantImportURL;
            _importConfirmationPage.IsplantImportPageDisplayed();
        }
       
        [When(@"I select GB")]
        public void WhenISelectGB()
        {
            _importConfirmationPage.ClickGBOption();
        }

        [Then(@"I see the plant search page")]
        public void ThenISeeThePlantSearchPage()
        {
            _plantsearchPage.IsSearchPageDisplayed();
        }

        [When(@"I select NI")]
        public void WhenISelectNI()
        {
            _importConfirmationPage.ClickNIOption();
        }

        [Then(@"I see the NI signposting page")]
        public void ThenISeeTheNISignpostingPage()
        {
            _signPostingPageNI.IsNIPageDisplayed();
        }
      
        [When(@"I click continue on journey page")]
        public void WhenIClickContinueOnJourneyPage()
        {
            _importConfirmationPage.ClickContinue();
        }

        [Then(@"I am taken to the error page prompting the user to select an option on Where Are You Importing")]
        public void ThenIAmTakenToTheErrorPagePromptingTheUserToSelectAnOptionOnWhereAreYouImporting()
        {
            _errorPage.IsErrorPageWhereAreYouImportingDisplayed();
        }

    }
}
