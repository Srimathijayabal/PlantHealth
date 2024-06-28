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

        


    }
}

        