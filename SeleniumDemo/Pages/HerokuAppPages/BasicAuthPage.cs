using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumDemo.Framework;
using System.Collections.Generic;

namespace SeleniumDemo.Pages.HerokuAppPages
{
    public class BasicAuthPage
    {
        private readonly RemoteWebDriver _driver;
        private static ILog logger = LoggerHelper.GetLogger(typeof(AddPostsPage));

        public BasicAuthPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public IList<IWebElement> txtSuccessMessage => _driver.FindElements(By.XPath("//div[@id='content']//p[contains(text(),'Congratulations! You must have the proper credentials.')]"));
        public IList<IWebElement> txtFailureMessage => _driver.FindElements(By.XPath("//body[contains(text(),'Not authorized')]"));

        public void LoginSuccessfully(string userName, string passWord)
        {
            ElementActions.AlertDataEnter(_driver, userName);
            ElementActions.AlertDataEnter(_driver, passWord);
            ElementActions.AlertAccept(_driver);            
        }

        public void LoginUnSuccessfully()
        {
            ElementActions.AlertDismiss(_driver);            
        }

        public bool verifyMessage(string condition, string message)
        {
            bool returnValue = false;
            IList<IWebElement> eleMessage = null;
            switch (condition)
            {
                case "Login_success":
                    eleMessage = txtSuccessMessage;
                    break;
                case "Login_Failure":
                    eleMessage = txtSuccessMessage;
                    break;
            }
            Assert.IsTrue(eleMessage.Count > 0, message);
            return returnValue;
        }

    }
}
