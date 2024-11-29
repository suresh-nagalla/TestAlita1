using TechTalk.SpecFlow;
using FluentAssertions;
using UI.Pages;

namespace UI.StepDefinitions
{
    [Binding]
    public class GmailLoginNegativeSteps
    {
        private readonly GmailLoginPage _loginPage;

        public GmailLoginNegativeSteps(GmailLoginPage loginPage)
        {
            _loginPage = loginPage;
        }

        [Given("I am on the Gmail login page")]
        public void GivenIAmOnTheGmailLoginPage()
        {
            _loginPage.NavigateToLoginPage();
        }

        [When("I enter invalid credentials")]
        public void WhenIEnterInvalidCredentials()
        {
            _loginPage.EnterCredentials("invalid_user", "invalid_password");
        }

        [When("I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            _loginPage.ClickLoginButton();
        }

        [Then("I should see an error message indicating invalid credentials")]
        public void ThenIShouldSeeAnErrorMessageIndicatingInvalidCredentials()
        {
            _loginPage.GetErrorMessage().Should().Contain("Wrong password. Try again or click Forgot password to reset it.");
        }
    }
}