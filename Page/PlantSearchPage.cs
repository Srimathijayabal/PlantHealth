using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PlantHealth.Page
{
    public class PlantSearchPage
    {
        private IWebDriver driver;
        public PlantSearchPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement searchPageHeading => driver.FindElement(By.XPath("//label[contains(.,'What plant or plant product are you importing?')]"));

        private IWebElement searchText => driver.FindElement(By.XPath("//input[@id='query']"));

        private IWebElement searchResultItem => driver.FindElement(By.XPath("//div[ @id='div-latinName1']"));

        private IWebElement continueBtn => driver.FindElement(By.XPath("//button[@id='submitButton']"));

        private IWebElement noresultsContainer => driver.FindElement(By.XPath("//li[normalize-space()='No results found']"));
        public bool IsSearchPageDisplayed()
        {
            return searchPageHeading.Displayed;
        }

        public void enterSearchText(string searchQuery)
        {
            searchText.SendKeys(searchQuery);
        }
        public bool ValidateSearchResults(string plantName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

            // Wait until at least one element containing the plant name is found
            string xpath = "//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '" + plantName.ToLower() + "')]";

            wait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));

            // Find all elements that contain the plant name text
            var searchResultEntries = driver.FindElements(By.XPath(xpath));
           
            // Assert that search results are present and return true if they are
            if (searchResultEntries.Count > 0)
            {
                Assert.IsTrue(searchResultEntries.Count > 0, "Search results should be present but none were found.");
                return true;
            }
            else
            {
                // Fail the test if no search results are found
                Assert.Fail("No search results found for the plant name: " + plantName);
                return false; 
            }

         }
        public void selectAPlant(string plantName)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementExists(By.XPath("(//*[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'),'" + plantName.ToLower() + "')])[1]")));

            searchResultItem.Click();           

        }

        public void clickContinue()
        {
            continueBtn.Click();
        }

        public bool noResultsFound()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//li[normalize-space()='No results found']")));
            return noresultsContainer.Displayed;
        }
    }
}
