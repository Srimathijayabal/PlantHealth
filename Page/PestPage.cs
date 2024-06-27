using MongoDB.Driver;
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
    public class PestPage
    {
        private IWebDriver driver;
        public PestPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement pestPageHeading => driver.FindElement(By.XPath("//h1[contains(.,'Pest or disease information unavailable')]"));
       
        public bool IsPestPageDisplayed()
        {
            return pestPageHeading.Displayed;
        }

    }
}
