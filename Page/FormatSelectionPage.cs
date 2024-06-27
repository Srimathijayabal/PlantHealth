using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PlantHealth.Config;
using RestSharp;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using static PlantHealth.Support.Datamodel;

namespace PlantHealth.Page
{
    public class FormatSelectionPage
    {

        private IWebDriver driver;
        public FormatSelectionPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement formatSelectionHeading => driver.FindElement(By.XPath("//h1[@class='govuk-fieldset__heading']"));

        private IWebElement continueBtn => driver.FindElement(By.XPath("//button[@id='submitButton']"));

        public bool IsFormatPageDisplayed()
        {
            return formatSelectionHeading.Displayed;
        }

        [Given(@"I am on the Format selection page")]
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

        