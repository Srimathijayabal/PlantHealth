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


namespace PlantHealth.Page
{
    public class CountryPage
    {

        private IWebDriver driver;
        public CountryPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement countrySearchHeading => driver.FindElement(By.XPath("//label[contains(text(),'Which country are you importing')]"));

        private IWebElement countrySearchTextbox => driver.FindElement(By.XPath("//input[@name='countrySearchQuery']"));

        private IWebElement continueBtn => driver.FindElement(By.XPath("//button[@id='submitButton']"));

        private string noResultsComponent = "//li[text()='No results found']";
        public bool IsSearchPageDisplayed()
        {
            return countrySearchHeading.Displayed;
        }

        public void enterCountryName(string countryName)
        {
            countrySearchTextbox.SendKeys(countryName);
        }

        public void continueBtnClick()
        {
            continueBtn.Click();
        }

        public void selectACountry(string countryName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            string country = "//li[@id='searchResults0']";
            
            wait.Until(ExpectedConditions.ElementExists(By.XPath(country))).Click();          

        }

        public bool IsDisplayedNoresults()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementExists(By.XPath(noResultsComponent)));

            return true;
        }
    }
}
