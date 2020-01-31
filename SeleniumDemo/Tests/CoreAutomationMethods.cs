
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumDemo.Framework;
using SeleniumDemo.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class CoreAutomationMethods
    {

        RemoteWebDriver driver = null;
        readonly string URL = "https://s1.demo.opensourcecms.com/wordpress/wp-login.php";
        
        [TestInitialize]
        public void Initialize()
        {

            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            //var FireFoxDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //driver = new FirefoxDriver(FireFoxDriverPath);

            driver = BaseClass.Setup("Chrome", URL);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login();
        }

        [TestMethod]
        public void LogintoWebsite()
        {
            DashBoardPage dashBoardPage = new DashBoardPage(driver);
            dashBoardPage.CreateBlog();
        }

        [TestCleanup]
        public void CleanUp()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.LogOut();

            CoreMethods coreMethods = new CoreMethods();
            coreMethods.KillProcess("chromedriver");
            coreMethods.KillProcess("conhost");
        }
    }
}
