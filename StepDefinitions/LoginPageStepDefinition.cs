using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PlantHealth.Config;
using PlantHealth.Page;
using System.Net;
using TechTalk.SpecFlow;

namespace PlantHealth.StepDefinitions
{
    [Binding]
    public sealed class LoginPageStepDefintion
    {
        
      
        private LoginPage loginPage;        

        public LoginPageStepDefintion(LoginPage loginPage) { 

            this.loginPage = loginPage;
        }

        [Given(@"I am logged in as a user")]
        public void GivenIAmLoggedInAsAUser()
        {
            loginPage.NavigateTo();
            loginPage.EnterPassword();
            loginPage.Submit();
        }
    }

}

