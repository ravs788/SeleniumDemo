using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using SeleniumDemo.Framework;

namespace SeleniumDemo.Pages
{
    public class DashBoardPage
    {
        private readonly RemoteWebDriver _driver = null;

        public DashBoardPage(RemoteWebDriver driver) => _driver = driver;

        IWebElement lnkAddNew => _driver.FindElementByXPath("//div[@id='adminmenuwrap']/ul/li[@id='menu-posts']/ul[contains(@class,'wp-submenu-wrap')]/li/a[text()='Add New']");
        IList<IWebElement> lnkPosts => _driver.FindElements(By.XPath("//div[@id='adminmenuwrap']/ul/li[@id='menu-posts']//div[text()='Posts']"));
        IWebElement elePostNew => _driver.FindElement(By.XPath("//div[@id='adminmenuwrap']/ul/li[@id='menu-posts']//div[text()='Posts']"));

        public void CreateBlog()
        {

            elePostNew.MoveToElement(_driver);

            lnkAddNew.ClickElement();

            Assert.IsTrue(lnkPosts.Count == 1, "Add New Post opened.");

            AddPostsPage addPostsPage = new AddPostsPage(_driver);
            addPostsPage.fillPostDetails();
        }
    }
}
