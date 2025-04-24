using TechTalk.SpecFlow;
using NUnit.Framework;
using UI.Pages;

namespace UI.StepDefinitions
{
    [Binding]
    public class NewGmailLoginNegativeSteps
    {
        private readonly GmailLoginPage _gmailLoginPage;

        public NewGmailLoginNegativeSteps()
        {
            _gmailLoginPage = new GmailLoginPage();
        }

        [Given("I am on the Gmail login page")]
        public void GivenIAmOnTheGmailLoginPage()
        {
            _gmailLoginPage.NavigateToLoginPage();
        }

        [When("I enter invalid credentials")]
        public void WhenIEnterInvalidCredentials()
        {
            _gmailLoginPage.EnterCredentials("invalid_user", "invalid_password");
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _gmailLoginPage.ClickLoginButton();
        }

        [Then("I should see an error message indicating invalid credentials")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidCredentials()
        {
            Assert.IsTrue(_gmailLoginPage.IsErrorMessageDisplayed());
        }
    }
}