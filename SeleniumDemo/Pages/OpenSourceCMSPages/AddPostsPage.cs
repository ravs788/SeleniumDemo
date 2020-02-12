using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Threading;
using SeleniumDemo.Framework;
using log4net;

namespace SeleniumDemo.Pages
{
    public class AddPostsPage
    {
        private readonly RemoteWebDriver _driver;
        private static ILog logger = LoggerHelper.GetLogger(typeof(AddPostsPage));
        
        
        public AddPostsPage(RemoteWebDriver driver)
        {
            _driver = driver;
            LoggerHelper.Layout = "%date{ dd-MMM-yyyy-HH:mm: ss}- [%level] - %class - %method -%message%newline";
        }

        IList<IWebElement> pnlTip => _driver.FindElements(By.XPath("//div[@class='components-popover__content']"));
        IWebElement btnCross => _driver.FindElementByXPath("//div[@class='components-popover__content']/button[contains(@class,'nux-dot-tip__disable')]");
        IWebElement txtTitle => _driver.FindElementByXPath("//div[@class='editor-writing-flow block-editor-writing-flow']//div[@class='editor-post-title']//textarea[@placeholder='Add title']");
        IWebElement txtPara => _driver.FindElementByXPath("//div[@class='editor-writing-flow block-editor-writing-flow']//div[@class='editor-block-list__block-edit block-editor-block-list__block-edit']//div/p[@role='textbox']");
        IWebElement btnPublish => _driver.FindElementByXPath("//div[@class='edit-post-header']/div[@class='edit-post-header__settings']/button[contains(text(),'Publish')]");

        readonly string txtbtnPublish = "//div[@class='edit-post-header']/div[@class='edit-post-header__settings']/button[contains(text(),'Publish')]";

        public void fillPostDetails()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            if (pnlTip.Count == 1)
            {
                btnCross.Click();
            }

            logger.Info("Entering Post Details");
            txtTitle.EnterText("Blog Post 1");
            txtTitle.EnterText(Keys.Tab);

            txtPara.EnterText("This is the first line.");
            txtPara.EnterText("This is the second line.");
            txtPara.EnterText("This is the last line.");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(txtbtnPublish)));

            btnPublish.ClickElement();

            Thread.Sleep(5000);
            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(txtbtnPublish)));

            btnPublish.ClickElementJS(_driver);
            btnPublish.ClickElementJS(_driver);            
        }

    }
}
