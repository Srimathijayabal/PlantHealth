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

        private IWebElement continueBtn => driver.FindElement(By.XPath("//button[@type='submit']"));

        private IWebElement pforp => driver.FindElement(By.XPath("//input[@value = 'plants for planting']"));
        private IWebElement pofp => driver.FindElement(By.XPath("//input[@value = 'parts of a plant']"));
        private IWebElement produce => driver.FindElement(By.XPath("//input[@value = 'produce']"));
        private IWebElement wood => driver.FindElement(By.XPath("//input[@value = 'wood']"));
        private IWebElement bark => driver.FindElement(By.XPath("//input[@value = 'isolated bark']"));


        public bool IsFormatPageDisplayed()
        {
            return formatSelectionHeading.Displayed;
        }

        public void clickContinue()
        {
            continueBtn.Click();
        }

        public void clickRadio(string Option)
        {
            switch (Option)
            {
                case "Plants for planting":
                    pforp.Click();
                    break;
                case "Part of a planting": 
                    pofp.Click();
                    break;
                case "Produce":
                    produce.Click();
                    break;
                case "Wood":
                    wood.Click();
                    break;
                case "Isolated Bark":
                    bark.Click();
                    break;
                default:
                    throw new ArgumentException("Invalid option provided");

            }
               
        }


    }
}

        