using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Method to fetch the page title
        public string GetPageTitle()
        {
            return _driver.Title;
        }
    }
}