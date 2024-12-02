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

        [Given(@"I am on the Gmail login page")]
        public void GivenIAmOnTheGmailLoginPage()
        {
            var url = ConfigManager.GetConfigValue<string>("GmailLoginUrl");
            _driver.Navigate().GoToUrl(url);
        }

        [When(@"I enter invalid credentials")]
        public void WhenIEnterInvalidCredentials()
        {
            var invalidEmail = "invalid@example.com";
            var invalidPassword = "invalidPassword";
            _gmailLoginBusinessLogic.Login(invalidEmail, invalidPassword);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _gmailLoginBusinessLogic.ClickLoginButton();
        }

        [Then(@"I should see an error message indicating invalid login")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidLogin()
        {
            _gmailLoginBusinessLogic.VerifyErrorMessageVisible().Should().BeTrue("Error message should be displayed after a failed login attempt.");
        }
    }
}