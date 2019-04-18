
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumDemo
{
    [TestClass]
    public class SearchGoogle
    {
        [TestMethod]
        public void SearchForCheese()
        {
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments ("headless");

            var ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(ChromeDriverPath);//, chromeOptions);
            driver.Url = "https://www.google.com";

            driver.Manage().Window.Maximize();

            IWebElement searchText = driver.FindElement(By.XPath("//input[@name='q']"));
            searchText.SendKeys("Cheese");
            searchText.Submit();
            
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='resultStats']")));

            Assert.AreEqual(driver.Title, "Cheese - Google Search");

            driver.Quit();
        }
    }
}
