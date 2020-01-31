using log4net;
using log4net.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace SeleniumDemo.Framework
{
    public static class ElementActions
    {
        private static ILog logger = LoggerHelper.GetLogger(typeof(ElementActions));
        public static void EnterText(this IWebElement element, string value)
        {
            try
            {
                element.SendKeys(value);
                logger.Debug("Enter Text passed for element");
            }
            catch (Exception e)
            {
                logger.Debug("Enter Text failed for element with exception - "+e.Message);
            }
        }

        public static void ClickElement(this IWebElement element)
        {
            try
            {
                element.Click();
                logger.Debug("Click Element passed for element");
            }
            catch (Exception e)
            {
                logger.Debug("Click Element failed for element with exception - " + e.Message);
            }
        }

        public static void MoveToElement(this IWebElement element, RemoteWebDriver _driver)
        {

            try
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(element).Perform();
                logger.Debug("Move to Element passed for element");
            }
            catch (Exception e)
            {
                logger.Debug("Move to Element failed for element with exception - " + e.Message);
            }
        }

        public static void ClickElementJS(this IWebElement element, RemoteWebDriver _driver)
        {

            try
            {
                IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
                executor.ExecuteScript("arguments[0].scrollIntoView();", element);
                executor.ExecuteScript("arguments[0].click();", element);
                executor.ExecuteScript("var evt = document.createEvent('MouseEvents');" + "evt.initMouseEvent('click',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" + "arguments[0].dispatchEvent(evt);", element);
                logger.Debug("Click Element passed for element");
            }
            catch (Exception e)
            {
                logger.Debug("Click Element failed for element with exception - " + e.Message);
            }

        }
    }
}
