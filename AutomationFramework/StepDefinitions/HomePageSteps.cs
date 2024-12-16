using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationFramework.StepDefinitions
{
    [Binding]
    public class HomePageSteps
    {
        private readonly IWebDriver _driver;
        private readonly HomePage _homePage;

        public HomePageSteps(IWebDriver driver)
        {
            _driver = driver;
            _homePage = new HomePage(driver);
        }

        [Given(@"the user is on the landing page")]
        public void GivenTheUserIsOnTheLandingPage()
        {
            _driver.Navigate().GoToUrl("https://demo.nopcommerce.com/");
        }

        [When(@"the page is loaded")]
        public void WhenThePageIsLoaded()
        {
            Assert.IsTrue(_driver.Url.Contains("nopcommerce.com"), "The page did not load correctly.");
        }

        [Then(@"the page title should be "(.*)")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            string actualTitle = _homePage.GetPageTitle();
            Assert.AreEqual(expectedTitle, actualTitle, "The page title did not match.");
        }
    }
}