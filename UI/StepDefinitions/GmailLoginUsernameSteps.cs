using TechTalk.SpecFlow;
using AutomationFramework.UI.BusinessLogic;
using AutomationFramework.Core.Config;
using OpenQA.Selenium;
using FluentAssertions;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class GmailLoginUsernameSteps
    {
        private readonly IWebDriver _driver;
        private readonly GmailLoginBusinessLogic _gmailLoginBusinessLogic;

        public GmailLoginUsernameSteps(ScenarioContext scenarioContext)
        {
            _driver = (IWebDriver)scenarioContext["WebDriver"];
            _gmailLoginBusinessLogic = new GmailLoginBusinessLogic(_driver);
        }

        [When(@"I enter a valid email "(.*)" in the username text box")]
        public void WhenIEnterAValidEmailInTheUsernameTextBox(string email)
        {
            _gmailLoginBusinessLogic.EnterUsername(email);
        }

        [Then(@"the email should be accepted without error")]
        public void ThenTheEmailShouldBeAcceptedWithoutError()
        {
            _gmailLoginBusinessLogic.VerifyUsernameAccepted().Should().BeTrue("The username should be accepted without any error.");
        }
    }
}
