using NUnit.Framework;
using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PlantHealth.Page
{
    public class ErrorPage
    {
        private IWebDriver driver;
        public ErrorPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement errorHeadingSelectWhatyouwanttoFindOut => driver.FindElement(By.XPath("//a[normalize-space()='Select what do you want to find out']"));
        private IWebElement errorHeadingSelectWhereAreyouImporting => driver.FindElement(By.XPath("//a[normalize-space()='Select where are you importing your plant or plant product to']"));

        private IWebElement errorHeadingEnterThePlantName => driver.FindElement(By.XPath("//h2[@class='govuk-error-summary__title' and contains(text(),'There is a problem')]"));

        private IWebElement errorHeadingEnterTheCountry => driver.FindElement(By.XPath("//a[contains(text(),'Enter the name of the country you are importing')]"));

        public bool IsErrorPageWhatyouwanttoFindOutDisplayed()
        {
            return errorHeadingSelectWhatyouwanttoFindOut.Displayed;
        }

        public bool IsErrorPageWhereAreYouImportingDisplayed()
        {
            return errorHeadingSelectWhereAreyouImporting.Displayed;
        }

        public bool IsErrorPageEnterAPlantNameIsDisplayed()
        {
            return errorHeadingEnterThePlantName.Displayed;
        }

        public bool IsErrorPageEntertheNameOfCountry()
        {
            return errorHeadingEnterTheCountry.Displayed;
        }
    }
}
