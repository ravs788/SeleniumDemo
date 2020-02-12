using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using SeleniumDemo.Framework;
using SeleniumDemo.Pages;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class OpenSourceCmsTestCases
    {

        RemoteWebDriver driver = null;
        
        [TestInitialize]
        public void Initialize()
        {
        
            driver = BaseClass.Setup();

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
        }
    }
}
