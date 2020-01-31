using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumDemo.Framework
{
    public class BaseClass
    {
        private static RemoteWebDriver _driver;

        private static RemoteWebDriver Driver(string browserType)
        {
            if(_driver != null)
            return _driver;

            if(browserType == "Chrome")
            {
                _driver = new ChromeDriver();
            }
            
            return _driver;
        }

        public static RemoteWebDriver Setup(string browserType, string URL)
        {
            _driver = Driver(browserType);
            _driver.Url = URL;
            _driver.Manage().Window.Maximize();
            return _driver;
        }
    }
}