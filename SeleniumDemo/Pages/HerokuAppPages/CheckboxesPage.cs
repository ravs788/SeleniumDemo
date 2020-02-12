using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using SeleniumDemo.Framework;

namespace SeleniumDemo.Pages.HerokuAppPages
{
    public class CheckboxesPage
    {
        private readonly RemoteWebDriver _driver;
        private static ILog logger = LoggerHelper.GetLogger(typeof(CheckboxesPage));

        public CheckboxesPage(RemoteWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement chkBox1 => _driver.FindElement(By.XPath("//div[@class='example']/form/input[@type='checkbox'][1]"));
        private IWebElement chkBox2 => _driver.FindElement(By.XPath("//div[@class='example']/form/input[@type='checkbox'][2]"));


        public void CheckCheckBox(int eleOrder)
        {   
            switch(eleOrder)
            {
                case 1:
                    chkBox1.CheckCheckBox();
                    break;
                case 2:
                    chkBox2.CheckCheckBox();
                    break;
            }
        }

        public void verifyChecked(int eleOrder, string message)
        {
            bool returnValue = false;
            switch (eleOrder)
            {
                case 1:
                    returnValue = chkBox1.VerifyChecked();
                    break;
                case 2:
                    returnValue = chkBox2.VerifyChecked();
                    break;
            }
            CoreMethods.AssertTrue(returnValue, message);
        }

    }
}
