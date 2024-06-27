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
    public class NISignPostingPage
    {
        private IWebDriver driver;
        public NISignPostingPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement NISignpostingHeading => driver.FindElement(By.XPath("//h1[contains(.,'This service does not include import and plant health information for Northern Ireland')]"));
        
        public bool IsNIPageDisplayed()
        {
            return NISignpostingHeading.Displayed;
        }

    }
}
