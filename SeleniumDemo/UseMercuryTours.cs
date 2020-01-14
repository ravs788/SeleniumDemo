
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
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
    public class UseMercuryTours
    {
        [TestMethod]
        public void LogintoWebsite()
        {
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments ("headless");

            var ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driver = new ChromeDriver(ChromeDriverPath);//, chromeOptions);
            driver.Url = "https://s1.demo.opensourcecms.com/wordpress/";

            driver.Manage().Window.Maximize();

            var userName = "opensourcecms";

            IWebElement lnkLogin = driver.FindElement(By.XPath("//a[text()='Log in']"));
            lnkLogin.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@id='user_login']")));

            IWebElement txtLogin = driver.FindElement(By.XPath("//input[@id='user_login']"));
            txtLogin.SendKeys(userName);
            
            IWebElement txtPasswd = driver.FindElement(By.XPath("//input[@id='user_pass']"));
            txtPasswd.SendKeys(userName);

            IWebElement btnLogin = driver.FindElement(By.XPath("//input[@value='Log In']"));
            btnLogin.Click();

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//ul[@class='ab-top-secondary ab-top-menu']/li//span[text()='"+userName+"']")));

            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//ul[@class='ab-top-secondary ab-top-menu']/li/a")));

            IWebElement lnkLogOut = driver.FindElement(By.XPath("//ul[@class='ab-submenu']/li[@id='wp-admin-bar-logout']/a[text()='Log Out']"));
            lnkLogOut.Click();

            driver.Quit();
        }
    }
}
