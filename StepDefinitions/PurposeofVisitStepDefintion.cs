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
    public sealed class PurposeofVisitStepDefinition
    {
        public string purposePage => URLs.PurposePage;
        private IWebDriver driver;
        private PurposeofVisitPage _purposeofVisitPage;
        private PlantImportConfirmationPage _importConfirmationPage;
        private PestPage _pestPage;
        private ErrorPage _errorPage;

        public PurposeofVisitStepDefinition(IWebDriver driver, PurposeofVisitPage purposeofVisitPage, PlantImportConfirmationPage importConfirmationPage, PestPage pestPage, ErrorPage errorPage)
        {
            this.driver = driver;
            _purposeofVisitPage = purposeofVisitPage;
            _importConfirmationPage = importConfirmationPage;
            _pestPage = pestPage;
            _errorPage = errorPage;
        }

        [Given(@"I see purpose of visit page with two options")]     
        public void GivenISeePurposeOfVisitPageWithTwoOptions()
        {
            driver.Url = purposePage;
            _purposeofVisitPage.journeyPageDisplayed();
        }

        [When(@"I can select the plant import option")]
        public void WhenICanSelectThePlantImportOption()
        {
            _purposeofVisitPage.ClickPlantImportRuleOption();
        }
       
        [When(@"I click continue")]
        public void WhenIClickContinue()
        {
            _purposeofVisitPage.ClickContinue();
        }

        [Then(@"I am taken to the journey confirmation page in the journey")]
        public void ThenIAmTakenToTheJourneyConfirmationPageInTheJourney()
        {
            _importConfirmationPage.IsplantImportPageDisplayed();
        }

        [When(@"I can select the pest or disease")]
        public void ThenICanSelectThePestOrDisease()
        {
            _purposeofVisitPage.ClickPestOrDiseaseOption();
        }

        [Then(@"I am taken to the pest page")]
        public void ThenIAmTakenToThePestPage()
        {
            _pestPage.IsPestPageDisplayed();
        }

        [Then(@"I am taken to the error page prompting the user to select an option")]
        public void WhenIAmTakenToTheErrorPagePromptingTheUserToSelectAnOption()
        {
            _errorPage.IsErrorPageWhatyouwanttoFindOutDisplayed();
        }


    }
}
