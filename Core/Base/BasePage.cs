using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomationFramework.Core.Base
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateToPage(string url)
        {
            Log.Information("Navigating to URL: {Url}", url);
            Driver.Navigate().GoToUrl(url);
        }

        public void RefreshPage()
        {
            Log.Information("Refreshing the current page.");
            Driver.Navigate().Refresh();
        }

        public IWebElement LocateWidget(By locator, int timeoutInSeconds = 15)
        {
            try
            {
                Log.Debug("Attempting to locate element: {Locator}", locator);
                var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeoutInSeconds));
                var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                Log.Information("Element located successfully: {Locator}", locator);
                return element;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to locate element: {Locator}", locator);
                throw;
            }
        }

        public void ClickElement(By locator, int timeoutInSeconds = 15)
        {
            try
            {
                Log.Information("Attempting to click element: {Locator}", locator);
                var element = LocateWidget(locator, timeoutInSeconds);
                element.Click();
                Log.Information("Element clicked successfully: {Locator}", locator);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to click element: {Locator}", locator);
                throw;
            }
        }

        public void EnterText(By locator, string text, int timeoutInSeconds = 15)
        {
            try
            {
                Log.Information("Entering text '{Text}' into element: {Locator}", text, locator);
                var element = LocateWidget(locator, timeoutInSeconds);
                element.Clear();
                element.SendKeys(text);
                Log.Information("Text entered successfully: {Locator}", locator);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to enter text into element: {Locator}", locator);
                throw;
            }
        }

        public bool IsElementVisible(By locator, int timeoutInSeconds = 15)
        {
            try
            {
                Log.Information("Checking visibility of element: {Locator}", locator);
                LocateWidget(locator, timeoutInSeconds);
                Log.Information("Element is visible: {Locator}", locator);
                return true;
            }
            catch
            {
                Log.Warning("Element is not visible: {Locator}", locator);
                return false;
            }
        }

        public void SelectDropdownValue(By locator, string valueToSelect)
        {
            try
            {
                Log.Information("Selecting value '{Value}' from dropdown: {Locator}", valueToSelect, locator);
                var dropdown = LocateWidget(locator);
                var selectElement = new SelectElement(dropdown);
                selectElement.SelectByText(valueToSelect);
                Log.Information("Dropdown value selected successfully: {Locator}", locator);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to select dropdown value: {Locator}", locator);
                throw;
            }
        }
    }
}
