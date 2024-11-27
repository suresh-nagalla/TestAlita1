using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace AutomationFramework.Core.Singleton
{
    public static class BrowserFactory
    {
        public static IWebDriver CreateBrowser(string browserType)
        {
            IWebDriver driver;
            switch (browserType.ToLower())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new NotImplementedException($"Browser {browserType} not supported.");
            }
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
