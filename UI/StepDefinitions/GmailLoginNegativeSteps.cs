using TechTalk.SpecFlow;
using NUnit.Framework;
using UI.Pages;

namespace UI.StepDefinitions
{
    [Binding]
    public class GmailLoginNegativeSteps
    {
        private readonly GmailLoginPage _gmailLoginPage;

        public GmailLoginNegativeSteps(GmailLoginPage gmailLoginPage)
        {
            _gmailLoginPage = gmailLoginPage;
        }

        [Given("I navigate to the Gmail login page")]
        public void GivenINavigateToTheGmailLoginPage()
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
            Assert.IsTrue(_gmailLoginPage.IsErrorMessageDisplayed(), "Error message not displayed");
        }
    }
}