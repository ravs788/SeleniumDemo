
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumDemo
{
    [TestClass]
    public class CoreAutomationMethods
    {
        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");

            var ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(ChromeDriverPath);//, chromeOptions);
            driver.Url = "https://s1.demo.opensourcecms.com/wordpress/wp-login.php";

            driver.Manage().Window.Maximize();            
        }

        [TestMethod]
        public void LogintoWebsite()
        {

            var userName = "opensourcecms";

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='user_login']")));

            IWebElement txtLogin = driver.FindElement(By.XPath("//input[@id='user_login']"));
            txtLogin.SendKeys(userName);

            IWebElement txtPasswd = driver.FindElement(By.XPath("//input[@id='user_pass']"));
            txtPasswd.SendKeys(userName);

            IWebElement btnLogin = driver.FindElement(By.XPath("//input[@value='Log In']"));
            btnLogin.Click();

            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@class='ab-top-secondary ab-top-menu']/li//span[text()='"+userName+"']")));

            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//div[@id='adminmenuwrap']/ul/li[@id='menu-posts']//div[text()='Posts']"))).Perform();

            IWebElement lnkAddNew = driver.FindElement(By.XPath("//div[@id='adminmenuwrap']/ul/li[@id='menu-posts']/ul[contains(@class,'wp-submenu-wrap')]/li/a[text()='Add New']"));
            lnkAddNew.Click();

            IList<IWebElement> lnkPosts = driver.FindElements(By.XPath("//div[@id='adminmenuwrap']/ul/li[@id='menu-posts']//div[text()='Posts']"));
            Assert.IsTrue(lnkPosts.Count == 1, "Add New Post opened.");

            IList<IWebElement> pnlTip = driver.FindElements(By.XPath("//div[@class='components-popover__content']"));
            if(pnlTip.Count==1)
            {
                IWebElement btnCross = driver.FindElement(By.XPath("//div[@class='components-popover__content']/button[contains(@class,'nux-dot-tip__disable')]"));
                btnCross.Click();
            }

            IWebElement txtTitle = driver.FindElement(By.XPath("//div[@class='editor-writing-flow block-editor-writing-flow']//div[@class='editor-post-title']//textarea[@placeholder='Add title']"));
            txtTitle.SendKeys("Blog Post 1");
            txtTitle.SendKeys(Keys.Tab);

            IWebElement txtPara = driver.FindElement(By.XPath("//div[@class='editor-writing-flow block-editor-writing-flow']//div[@class='editor-block-list__block-edit block-editor-block-list__block-edit']//div/p[@role='textbox']"));
            txtPara.SendKeys("This is the first line.\n");
            txtPara.SendKeys("This is the second line.\n");
            txtPara.SendKeys("This is the last line.\n");

            IWebElement btnPublish = driver.FindElement(By.XPath("//div[@class='edit-post-header']/div[@class='edit-post-header__settings']/button[contains(text(),'Publish')]"));
            btnPublish.Click();

            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='edit-post-header']/div[@class='edit-post-header__settings']/button[contains(text(),'Publish')]")));

            btnPublish.SendKeys(Keys.Return);

        }

        [TestCleanup]
        public void CleanUp()
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(By.XPath("//ul[@class='ab-top-secondary ab-top-menu']/li/a"))).Perform();

            IWebElement lnkLogOut = driver.FindElement(By.XPath("//ul[@class='ab-submenu']/li[@id='wp-admin-bar-logout']/a[text()='Log Out']"));
            lnkLogOut.Click();

            driver.Quit();
        }
    }
}
