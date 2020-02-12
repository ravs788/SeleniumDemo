using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace SeleniumDemo.Framework
{
    public static class BaseClass
    {
        private static RemoteWebDriver _driver;

        private static RemoteWebDriver Driver(string browserType)
        {
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.AddArguments("headless");
            //var FireFoxDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //driver = new FirefoxDriver(FireFoxDriverPath);

            if (_driver != null)
            {
                return _driver;
            }

            if (browserType == "Chrome")
            {
                _driver = new ChromeDriver();
            }
            else if(browserType == "Firefox")
            {
                var FireFoxDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                _driver = new FirefoxDriver(FireFoxDriverPath);
            }

            
            return _driver;
        }

        public static RemoteWebDriver Setup()
        {
            string URL = ConfigurationManager.AppSettings["URL"];
            string browserType = ConfigurationManager.AppSettings["Browser"];
            _driver = Driver(browserType);
            _driver.Url = URL;
            _driver.Manage().Window.Maximize();
            return _driver;
        }
    }
}