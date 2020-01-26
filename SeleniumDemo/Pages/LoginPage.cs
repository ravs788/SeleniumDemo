using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Pages
{
    public class LoginPage
    {
        private readonly RemoteWebDriver _driver = null;

        public LoginPage(RemoteWebDriver driver) => _driver = driver;

        IWebElement txtUserName => _driver.FindElementByXPath("//input[@id='user_login']");

        IWebElement txtPasswd => _driver.FindElementByXPath("//input[@id='user_pass']");

        IWebElement btnLogin => _driver.FindElementByXPath("//input[@value='Log In']");

        IWebElement eleUserName => _driver.FindElementByXPath("//ul[@class='ab-top-secondary ab-top-menu']/li/a");

        IWebElement lnkLogOut => _driver.FindElementByXPath("//ul[@class='ab-submenu']/li[@id='wp-admin-bar-logout']/a[text()='Log Out']");

        string eleUserLogin = "//input[@id='user_login']";

        string eleUserVerify = "//ul[@class='ab-top-secondary ab-top-menu']/li//span[text()='sUserName']";

        public void Login()
        {
            string userName = "opensourcecms";
                    
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(eleUserLogin)));

            txtUserName.SendKeys(userName);

            txtPasswd.SendKeys(userName);

            btnLogin.Click();

            eleUserVerify = eleUserVerify.Replace("sUserName", userName);

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(eleUserVerify)));

        }

        public void LogOut()
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(eleUserName).Perform();

            lnkLogOut.Click();

        }
    }
}
