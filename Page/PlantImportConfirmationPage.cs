using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantHealth.Page
{
    public class PlantImportConfirmationPage
    {
        private IWebDriver driver;
        public PlantImportConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;

        }
        private IWebElement plantImportHeading => driver.FindElement(By.XPath("//h1[contains(.,'Where are you importing your plant or plant product to?')]"));

        private IWebElement GBOption => driver.FindElement(By.XPath("//input[@id='whereareyouimportinginto']"));
        private IWebElement NIOption => driver.FindElement(By.XPath("//input[@id='whereareyouimportinginto-2']"));

        private IWebElement continueOption => driver.FindElement(By.XPath("//button[@type='submit']"));



        public bool IsplantImportPageDisplayed()
        {
            return plantImportHeading.Displayed;
        }
        public void ClickGBOption()
        {
            GBOption.Click();
        }

        public void ClickNIOption()
        {
            NIOption.Click();
        }

        public void ClickContinue()
        {
            continueOption.Click();
        }
    }
}
