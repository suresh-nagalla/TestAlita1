using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Example.TestAutomation.Ui
{
    public static class WaitHelper
    {
        private static WebDriverWait GetWait(IWebDriver driver, int timeoutInSeconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        public static void WaitForElementToBeVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            GetWait(driver, timeoutInSeconds)
                .Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementToBeClickable(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            GetWait(driver, timeoutInSeconds)
                .Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void EnterText(IWebDriver driver, By locator, string text, int timeoutInSeconds = 10)
        {
            WaitForElementToBeVisible(driver, locator, timeoutInSeconds);
            var element = driver.FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public static void Click(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WaitForElementToBeClickable(driver, locator, timeoutInSeconds);
            driver.FindElement(locator).Click();
        }

        public static string GetText(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WaitForElementToBeVisible(driver, locator, timeoutInSeconds);
            return driver.FindElement(locator).Text;
        }
    }
}