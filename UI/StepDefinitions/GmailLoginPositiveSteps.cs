using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using Core.Utilities;
using UI.Pages;

namespace UI.StepDefinitions
{
    [Binding]
    public class GmailLoginPositiveSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly GmailLoginPage _gmailLoginPage;

        public GmailLoginPositiveSteps(ScenarioContext scenarioContext, GmailLoginPage gmailLoginPage)
        {
            _scenarioContext = scenarioContext;
            _gmailLoginPage = gmailLoginPage;
        }

        [Given("I am on the Gmail login page")]
        public void GivenIAmOnTheGmailLoginPage()
        {
            _gmailLoginPage.NavigateToLoginPage();
        }

        [When("I enter a valid username")]
        public void WhenIEnterAValidUsername()
        {
            _gmailLoginPage.EnterUsername(ConfigManager.GmailUsername);
        }

        [Then("the username should be accepted")]
        public void ThenTheUsernameShouldBeAccepted()
        {
            _gmailLoginPage.IsUsernameAccepted().Should().BeTrue();
        }
    }
}