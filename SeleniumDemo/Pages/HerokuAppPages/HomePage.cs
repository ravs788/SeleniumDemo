using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumDemo.Framework;
namespace SeleniumDemo.Pages.HerokuAppPages
{
    public class HomePage
    {
        private readonly RemoteWebDriver _driver;
        private static ILog logger = LoggerHelper.GetLogger(typeof(HomePage));

        public HomePage(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement lnkBasicAuth => _driver.FindElementByXPath("//div[@id='content']/ul/li/a[text()='Basic Auth']");
        public IWebElement lnkCheckBoxes => _driver.FindElementByXPath("//div[@id='content']/ul/li/a[text()='Checkboxes']");
        public IWebElement lnkContextMenu => _driver.FindElementByXPath("//div[@id='content']/ul/li/a[text()='Context Menu']");

        public void NavigateSubPage(string subPage)
        {
            switch(subPage)
            {
                case "Basic Auth":
                    lnkBasicAuth.ClickElement();
                    break;
                case "Checkboxes":
                    lnkCheckBoxes.ClickElement();
                    break;
                case "Context Menu":
                    lnkContextMenu.ClickElement();
                    break;
            }
            
        }

        public void LogOut()
        {
            _driver.Quit();
            CoreMethods coreMethods = new CoreMethods();
            coreMethods.KillProcess("chromedriver");
            coreMethods.KillProcess("conhost");
        }
    }
}
