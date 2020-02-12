using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using SeleniumDemo.Framework;
using SeleniumDemo.Pages.HerokuAppPages;

namespace SeleniumDemo.Tests
{
    [TestClass]
    public class HerokuAppTestCases
    {
        RemoteWebDriver _driver = null;
        HomePage homePage = null;

        [TestInitialize]
        public void Initialize()
        {

            _driver = BaseClass.Setup();
            homePage = new HomePage(_driver);

        }

        [TestMethod]
        public void VerifyBasicAuthSuccess()
        {
            homePage.NavigateSubPage("Basic Auth");
            BasicAuthPage basicAuthPage = new BasicAuthPage(_driver);
            basicAuthPage.LoginSuccessfully("admin", "admin");
            basicAuthPage.verifyMessage("Login_success", "Login success verified");

        }

        [TestMethod]
        public void VerifyBasicAuthFailure()
        {
            homePage.NavigateSubPage("Basic Auth");
            BasicAuthPage basicAuthPage = new BasicAuthPage(_driver);
            basicAuthPage.LoginUnSuccessfully();
            basicAuthPage.verifyMessage("Login_Failure", "Login failure verified");

        }

        [TestMethod]
        public void VerifyCheckBoxes()
        {
            homePage.NavigateSubPage("Checkboxes");
            CheckboxesPage checkboxesPage = new CheckboxesPage(_driver);
            checkboxesPage.CheckCheckBox(1);
            checkboxesPage.verifyChecked(1, "1st checkbox checked");
            checkboxesPage.CheckCheckBox(2);
            checkboxesPage.verifyChecked(2, "1st checkbox checked");
        }

        [TestCleanup]
        public void CleanUp()
        {
            homePage.LogOut();
            
        }
    }
}
