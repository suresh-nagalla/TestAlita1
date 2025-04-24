using TechTalk.SpecFlow;
using AutomationFramework.UI.BusinessLogic;
using AutomationFramework.Core.Config;
using OpenQA.Selenium;
using FluentAssertions;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class GmailLoginNegativeSteps
    {
        private readonly IWebDriver _driver;
        private readonly GmailLoginBusinessLogic _gmailLoginBusinessLogic;

        public GmailLoginNegativeSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
            _gmailLoginBusinessLogic = new GmailLoginBusinessLogic(_driver);
        }

        [Given(@"I navigate to Gmail login page")]
        public void GivenINavigateToGmailLoginPage()
        {
            var url = ConfigManager.GetConfigValue<string>("GmailLoginUrl");
            _driver.Navigate().GoToUrl(url);
        }

        [When(@"I enter "invaliduser@gmail.com" and "WrongPassword")]
        public void WhenIEnterInvalidCredentials()
        {
            _gmailLoginBusinessLogic.Login("invaliduser@gmail.com", "WrongPassword");
        }

        [Then(@"I should see an error message indicating invalid credentials")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidCredentials()
        {
            _gmailLoginBusinessLogic.VerifyErrorMessageVisible().Should().BeTrue("Error message should be displayed after a failed login attempt.");
        }
    }
}
