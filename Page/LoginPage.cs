using MongoDB.Driver;
using NUnit.Framework;
using OpenQA.Selenium;
using PlantHealth.Config;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PlantHealth.Page
{
    public class LoginPage
    {
        private IWebDriver driver;
        private string loginPage = URLs.loginPageURL;
        
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        public void NavigateTo()
        {
          
            driver.Navigate().GoToUrl(loginPage);
        }      
        public void EnterPassword()
        {
            driver.FindElement(By.Id("password")).SendKeys("Phidemo123");
        }

        public void Submit()
        {
            driver.FindElement(By.ClassName("govuk-button")).Click();
        }
    }
}
