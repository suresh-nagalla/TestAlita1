using System;
using TechTalk.SpecFlow;
using UI.Pages;
using Core.Utilities;

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

        [Given("I navigate to the Gmail login page")]
        public void GivenINavigateToTheGmailLoginPage()
        {
            _gmailLoginPage.NavigateToLoginPage();
        }

        [When("I enter a valid username in the username text box")]
        public void WhenIEnterAValidUsernameInTheUsernameTextBox()
        {
            _gmailLoginPage.EnterUsername("valid.username@gmail.com");
        }

        [Then("the username text box should contain the entered username")]
        public void ThenTheUsernameTextBoxShouldContainTheEnteredUsername()
        {
            _gmailLoginPage.GetUsernameTextBoxValue().Should().Be("valid.username@gmail.com");
        }
    }
}