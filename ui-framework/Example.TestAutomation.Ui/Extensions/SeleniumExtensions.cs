using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Example.TestAutomation.Ui.Extensions
{
    public static class SeleniumExtensions
    {
        private const int _webDriverWaitTimeout = 30;

        public static List<IWebElement> LocateWidgets(this IWebDriver driver, By locator, int webDriverWaitTimeout = _webDriverWaitTimeout)
        {
            int retries = 0;
            int MAX_RETRIES = 10;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(webDriverWaitTimeout));
            while (true)
            {
                try
                {
                    var elements = wait.Until(driver => driver.FindElements(locator).Where(e => e.Displayed).ToList());
                    return elements;
                }
                catch (WebDriverTimeoutException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("The HTTP request to the remote WebDriver server for URL"))
                    {
                        throw new Exception("Fatal Webdriver error in LocateWidget: " + e.Message);
                    }
                    if (retries < MAX_RETRIES)
                    {
                        retries++;
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        throw new Exception("Gave up retries in LocateWidget: " + e.GetType());
                    }
                }
            }
        }

        public static IWebElement LocateWidget(this IWebDriver driver, By locator, int webDriverWaitTimeout = _webDriverWaitTimeout)
        {
            int retries = 0;
            int MAX_RETRIES = 10;
            var waitObj = new WebDriverWait(driver, TimeSpan.FromSeconds(webDriverWaitTimeout));
            while (true)
            {
                try
                {
                    waitObj.Until(driver => driver.FindElement(locator).Displayed);
                    return driver.FindElement(locator);
                }
                catch (WebDriverTimeoutException e)
                {
                    throw e;
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("The HTTP request to the remote WebDriver server for URL"))
                    {
                        throw new Exception("Fatal Webdriver error in LocateWidget: " + e.Message);
                    }
                    if (retries < MAX_RETRIES)
                    {
                        retries++;
                        Thread.Sleep(1000);
                        continue;
                    }
                    else
                    {
                        throw new Exception("Gave up retries in LocateWidget: " + e.GetType());
                    }
                }
            }
        }

        public static bool WaitForElementToBeDisplayed(this IWebDriver driver, By locator)
        {
            return driver.LocateWidget(locator).Displayed;
        }

        public static bool WaitForElementToBeEnabled(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_webDriverWaitTimeout));
            wait.IgnoreExceptionTypes(typeof(TimeoutException), typeof(StaleElementReferenceException), typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromSeconds(1.5);
            wait.Until(driver => driver.FindElement(locator).Enabled);
            return driver.LocateWidget(locator).Enabled;
        }

        public static void WaitForPageToLoad(this IWebDriver driver)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_webDriverWaitTimeout));
            wait.Until(driver => (IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete");
        }

        public static void WaitForLoadingIconToDisappear(this IWebDriver driver)
        {
            driver.WaitForElementToDisappear(By.XPath("//div[@id='alerts']"));
        }

        public static void WaitForLoadingIconToDisappear(this IWebDriver driver, TimeSpan timeSpan)
        {
            driver.WaitForElementToDisappear(By.XPath("//div[@id='alerts']"), timeSpan);
        }

        public static void WaitForElementToDisappear(this IWebDriver driver, By locator)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(driver => !driver.FindElement(locator).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }
        }

        public static void WaitForElementToDisappear(this IWebDriver driver, By locator, TimeSpan timeSpan)
        {

            var wait = new WebDriverWait(driver, timeSpan);
            try
            {
                wait.Until(driver => !driver.FindElement(locator).Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return;
            }
        }

        public static void SetText(this IWebDriver driver, By locator, string text)
        {
            driver.LocateWidget(locator).Clear();
            driver.LocateWidget(locator).SendKeys(text);
        }

        public static void SelectValueFromDropdown(this IWebDriver driver, By locator, string optionToSelect)
        {
            var dropdown = driver.LocateWidgets(locator).FirstOrDefault();
            dropdown.Click();
            var options = dropdown.FindElements(By.TagName("option")).ToList();
            options.Find(e => e.Text.Contains(optionToSelect)).Click();
        }

        public static void MoveToElementAndClick(this IWebDriver driver, By locator)
        {
            var actions = new Actions(driver);
            actions.MoveToElement(driver.LocateWidget(locator)).Click().Build().Perform();
        }

        public static void JavascriptClick(this IWebDriver driver, By element)
        {
            driver.ExecuteJsScript("arguments[0].click()", driver.FindElements(element).FirstOrDefault(e => e.Displayed));
        }

        public static void ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            var location = ((ILocatable)element).LocationOnScreenOnceScrolledIntoView;
            driver.ExecuteJsScript($"window.scrollBy({location.X},{location.Y});");
        }

        public static object ExecuteJsScript(this IWebDriver driver, string script, params object[] args)
        {
            var js = (IJavaScriptExecutor)driver;
            return js.ExecuteScript(script, args);
        }
    }
}
