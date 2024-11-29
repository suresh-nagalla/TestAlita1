using TechTalk.SpecFlow;
using AutomationFramework.UI.BusinessLogic;
using FluentAssertions;
using OpenQA.Selenium;

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

        [When(@"I enter "invalidemail" and "ValidPassword123"")]
        public void WhenIEnterInvalidEmailFormat()
        {
            _gmailLoginBusinessLogic.Login("invalidemail", "ValidPassword123");
        }

        [Then(@"I should see an error message indicating invalid email format")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidEmailFormat()
        {
            _gmailLoginBusinessLogic.VerifyInvalidEmailFormatError().Should().BeTrue("Error message for invalid email format should be displayed.");
        }
    }
}
