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
    public sealed class StartPageStepDefinitions
    {
        public string Url => URLs.StartPageURL;
        private IWebDriver driver;
        private StartPage _startPage;
        

        public StartPageStepDefinitions(IWebDriver driver, StartPage startPage) { 
           
            this.driver = driver;
            _startPage = startPage;
        }

        [Given(@"I launch the URL")]
        public void GivenILaunchTheURL()
        {
           
            driver.Url = Url;
        }
       
        [When(@"Click on Startnow")]
        public void WhenClickOnStartnow()
        {

         //   _startPage.TakeStartNowElementScreenshot("StartnowCTA.png");
            _startPage.ClickStartnow();

        }

        [Then(@"I am navigated to the next page")]
        public void ThenIAmNavigatedToTheNextPage()
        {
            IWebElement journeyPage = driver.FindElement(By.XPath("//h1[@class='govuk-fieldset__heading' and contains(.,'What do you want to find out?')]"));
            Assert.IsTrue(journeyPage.Displayed,"Navigated to the journey confirmation page");

            
        }

        [When(@"I click on the related links")]
        public void WhenIClickOnTheRelatedLinks()
        {
            _startPage.IsURLsValid();


        }
        [Then(@"the links are functional")]
        public void ThenTheLinksAreFunctional()
        {
           
        }

    }
}
