using TechTalk.SpecFlow;
using AutomationFramework.UI.BusinessLogic;
using AutomationFramework.Core.Config;
using OpenQA.Selenium;
using FluentAssertions;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class NewGmailLoginNegativeSteps
    {
        private readonly IWebDriver _driver;
        private readonly GmailLoginBusinessLogic _gmailLoginBusinessLogic;

        public NewGmailLoginNegativeSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
            _gmailLoginBusinessLogic = new GmailLoginBusinessLogic(_driver);
        }

        [Given("I navigate to the Gmail login page")]
        public void GivenINavigateToTheGmailLoginPage()
        {
            var url = ConfigManager.GetConfigValue<string>("GmailLoginUrl");
            _driver.Navigate().GoToUrl(url);
        }

        [When("I enter an invalid username and password")]
        public void WhenIEnterAnInvalidUsernameAndPassword()
        {
            var invalidEmail = "invalid@example.com";
            var invalidPassword = "invalidPassword";
            _gmailLoginBusinessLogic.Login(invalidEmail, invalidPassword);
        }

        [Then("I should see an error message indicating invalid credentials")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidCredentials()
        {
            _gmailLoginBusinessLogic.VerifyErrorMessageVisible().Should().BeTrue("Error message should be displayed for invalid credentials.");
        }
    }
}
