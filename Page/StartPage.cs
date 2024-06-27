using NUnit.Framework;
using OpenQA.Selenium;
using PlantHealth.Config;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PlantHealth.Page
{
    public class StartPage
    {

        private IWebDriver driver;
        
        public StartPage(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement startnowCTA => driver.FindElement(By.XPath("//a[@class='govuk-button govuk-button--start']"));
        public void ClickStartnow()
        {
            startnowCTA.Click();
            
        }        
       
        public void IsURLsValid()
        {
            var links = driver.FindElements(By.XPath("//*[contains(@class,'govuk-body-s')]/a"));
            var hrefs = links.Select(link => link.GetAttribute("href")).Where(href => !string.IsNullOrEmpty(href)).Distinct().ToList();

            List<string> brokenLinks = new List<string>();

            foreach (var href in hrefs)
            {
                if (!IsUrlValid(href))
                {
                    brokenLinks.Add(href);
                }
            }
            foreach (var href in brokenLinks)
            {
                Console.WriteLine("Broken Links:" + href);
            }
        }
        static bool IsUrlValid(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.AllowAutoRedirect = true; // Allows for redirections
                request.Method = "GET";
                request.Accept = "*/*";

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    int statusCode = (int)response.StatusCode;
                    if (statusCode >= 200 && statusCode < 300)
                    {
                        return true; // Valid URL
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse response)
                {
                    int statusCode = (int)response.StatusCode;
                    if (statusCode >= 200 && statusCode < 300)
                    {
                        return true; // Valid URL
                    }
                }
            }
            return false; // Invalid URL
        }
    }
}
