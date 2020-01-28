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
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        public static void ClickElement(this IWebElement element)
        {
            element.Click();
        }

        public static void MoveToElement(this IWebElement element, RemoteWebDriver _driver)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(element).Perform();
        }

        public static void ClickElementJS(this IWebElement element, RemoteWebDriver _driver)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)_driver;
            executor.ExecuteScript("arguments[0].scrollIntoView();", element);
            executor.ExecuteScript("arguments[0].click();", element);
            executor.ExecuteScript("var evt = document.createEvent('MouseEvents');" + "evt.initMouseEvent('click',true, true, window, 0, 0, 0, 0, 0, false, false, false, false, 0,null);" + "arguments[0].dispatchEvent(evt);", element);
        }
    }
}
