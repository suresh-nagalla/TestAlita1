using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFramework.Utilities
{
    public static class WebDriverManager
    {
        public static IWebDriver InitializeDriver(string browser)
        {
            IWebDriver driver;

            if (browser.ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else
            {
                throw new NotSupportedException($"Browser '{browser}' is not supported.");
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}