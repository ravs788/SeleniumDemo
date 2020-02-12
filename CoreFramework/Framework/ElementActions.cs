using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
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
                logger.Debug("Enter Text "+value+" in element successfully");
            }
            catch (Exception e)
            {
                logger.Error("Enter Text failed for element with exception - "+e.Message);
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
                logger.Error("Click Element failed for element with exception - " + e.Message);
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
                logger.Error("Click Element failed for element with exception - " + e.Message);
            }

        }


        public static void CheckCheckBox(this IWebElement element)
        {
            try
            {
                if (!element.GetAttribute("checked").Equals(true))
                    element.Click();
                logger.Debug("Check element passed for element");
            }
            catch (Exception e)
            {
                logger.Error("Check element failed for element with exception - " + e.Message);
            }
        }

        public static bool VerifyChecked(this IWebElement element)
        {
            bool returnValue = false;
            try
            {
                if (element.GetAttribute("checked").Equals(false))
                    returnValue = true;
                logger.Debug("Element is checked as expected.");
            }
            catch (Exception e)
            {
                logger.Error("Element is not checked with exception - " + e.Message);
            }
            return returnValue;
        }

        public static void AlertDataEnter(RemoteWebDriver _driver, string value)
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                //_driver.SwitchTo().
                alert.SendKeys(value);
                logger.Debug("Entered text "+value+" in alert textbox successfully");
                alert.SendKeys(Keys.Tab);
            }
            catch (Exception e)
            {
                logger.Error("Enter text failed for alert text box with exception - " + e.Message);
            }

        }

        public static void AlertAccept(RemoteWebDriver _driver)
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                alert.Accept();
                logger.Debug("Alert accepted successfully.");
            }
            catch (Exception e)
            {
                logger.Error("Accpeting alert failed with exception - " + e.Message);
            }
        }

        public static void AlertDismiss(RemoteWebDriver _driver)
        {
            try
            {
                IAlert alert = _driver.SwitchTo().Alert();
                alert.Dismiss();
                logger.Debug("Alert accepted successfully.");
            }
            catch (Exception e)
            {
                logger.Error("Accpeting alert failed with exception - " + e.Message);
            }
        }
    }
}
