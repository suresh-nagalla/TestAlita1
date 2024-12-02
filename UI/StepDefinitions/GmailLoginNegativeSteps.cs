using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using AutomationFramework.UI.Pages;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class GmailLoginNegativeSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly GmailLoginPage _gmailLoginPage;

        public GmailLoginNegativeSteps(ScenarioContext scenarioContext, GmailLoginPage gmailLoginPage)
        {
            _scenarioContext = scenarioContext;
            _gmailLoginPage = gmailLoginPage;
        }

        [Given("I am on the Gmail login page")]
        public void GivenIAmOnTheGmailLoginPage()
        {
            _gmailLoginPage.NavigateToLoginPage();
        }

        [When("I enter an invalid username and password")]
        public void WhenIEnterAnInvalidUsernameAndPassword()
        {
            _gmailLoginPage.EnterUsername("invalid_username");
            _gmailLoginPage.EnterPassword("invalid_password");
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _gmailLoginPage.ClickLoginButton();
        }

        [Then("I should see an error message indicating invalid credentials")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidCredentials()
        {
            Assert.IsTrue(_gmailLoginPage.IsErrorMessageDisplayed(), "Error message not displayed");
        }
    }
}