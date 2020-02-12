using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using SeleniumDemo.Framework;
using log4net;

namespace SeleniumDemo.Pages
{
    public class LoginPage
    {
        private readonly RemoteWebDriver _driver = null;
        readonly ILog logger = LoggerHelper.GetLogger(typeof(LoginPage));

        public LoginPage(RemoteWebDriver driver)
        {
            _driver = driver;
            LoggerHelper.Layout = "%date{ dd-MMM-yyyy-HH:mm: ss}- [%level] - %class - %method -%message%newline";
        }
        
        IWebElement txtUserName => _driver.FindElementByXPath("//input[@id='user_login']");
        IWebElement txtPasswd => _driver.FindElementByXPath("//input[@id='user_pass']");
        IWebElement btnLogin => _driver.FindElementByXPath("//input[@value='Log In']");
        IWebElement eleUserName => _driver.FindElementByXPath("//ul[@class='ab-top-secondary ab-top-menu']/li/a");
        IWebElement lnkLogOut => _driver.FindElementByXPath("//ul[@class='ab-submenu']/li[@id='wp-admin-bar-logout']/a[text()='Log Out']");

        readonly string eleUserLogin = "//input[@id='user_login']";
        string eleUserVerify = "//ul[@class='ab-top-secondary ab-top-menu']/li//span[text()='sUserName']";

        public void Login()
        {
            string userName = "opensourcecms";

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(eleUserLogin)));

            logger.Info("Login started");
            txtUserName.EnterText(userName);
            txtPasswd.EnterText(userName);
            btnLogin.ClickElement();
            eleUserVerify = eleUserVerify.Replace("sUserName", userName);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(eleUserVerify)));

        }

        public void LogOut()
        {
            logger.Info("Logout started");
            eleUserName.ClickElement();
            eleUserName.MoveToElement(_driver);

            lnkLogOut.ClickElement();
            logger.Info("---------Ending Logging-------------");

            CoreMethods coreMethods = new CoreMethods();
            coreMethods.KillProcess("chromedriver");
            coreMethods.KillProcess("conhost");
        }
    }
}
