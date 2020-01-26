using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumDemo.Pages
{
    public class AddPostsPage
    {
        private readonly RemoteWebDriver _driver;
        public AddPostsPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        IList<IWebElement> pnlTip => _driver.FindElements(By.XPath("//div[@class='components-popover__content']"));
        IWebElement btnCross => _driver.FindElementByXPath("//div[@class='components-popover__content']/button[contains(@class,'nux-dot-tip__disable')]");
        IWebElement txtTitle => _driver.FindElementByXPath("//div[@class='editor-writing-flow block-editor-writing-flow']//div[@class='editor-post-title']//textarea[@placeholder='Add title']");
        IWebElement txtPara => _driver.FindElementByXPath("//div[@class='editor-writing-flow block-editor-writing-flow']//div[@class='editor-block-list__block-edit block-editor-block-list__block-edit']//div/p[@role='textbox']");
        IWebElement btnPublish => _driver.FindElementByXPath("//div[@class='edit-post-header']/div[@class='edit-post-header__settings']/button[contains(text(),'Publish')]");
        string txtbtnPublish = "//div[@class='edit-post-header']/div[@class='edit-post-header__settings']/button[contains(text(),'Publish')]";

        public void fillPostDetails()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            if (pnlTip.Count == 1)
            {
                btnCross.Click();
            }

            txtTitle.SendKeys("Blog Post 1");
            txtTitle.SendKeys(Keys.Tab);

            txtPara.SendKeys("This is the first line.\n");
            txtPara.SendKeys("\nThis is the second line.\n");
            txtPara.SendKeys("\nThis is the last line.\n");

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(txtbtnPublish)));

            btnPublish.Click();
            //btnPublish.SendKeys(Keys.Return);

            Thread.Sleep(5000);
            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(txtbtnPublish)));

            //btnPublish.Click();
            //Actions action = new Actions(_driver);
            //action.MoveToElement(btnPublish).Perform();

            btnPublish.SendKeys(Keys.Return);

        }

    }
}
