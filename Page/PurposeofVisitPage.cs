using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantHealth.Page
{
    public class PurposeofVisitPage
    {
        private IWebDriver driver;
        public PurposeofVisitPage(IWebDriver driver)
        {
            this.driver = driver;

        }
        private IWebElement plantImportRulesOption => driver.FindElement(By.XPath("//input[@id='whatdoyouwanttofind']"));
        private IWebElement pestOrDiseaseOption => driver.FindElement(By.XPath("//input[@id='whatdoyouwanttofind-2']"));

        private IWebElement continueOption => driver.FindElement(By.XPath("//button[@type='submit']"));

        private IWebElement journeyPage => driver.FindElement(By.XPath("//h1[@class='govuk-fieldset__heading' and contains(.,'What do you want to find out?')]"));

        public void journeyPageDisplayed()
        {
            
            Assert.IsTrue(journeyPage.Displayed, "Navigated to the journey confirmation page");

        }
        public void ClickPlantImportRuleOption()
        {
            plantImportRulesOption.Click();
        }

        public void ClickPestOrDiseaseOption()
        {
            pestOrDiseaseOption.Click();
        }

        public void ClickContinue()
        {
            continueOption.Click();
        }
    }
}
