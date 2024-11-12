using NUnit.Framework;
using TechTalk.SpecFlow;
using Example.TestAutomation.ExampleTests.Pages;

namespace Example.TestAutomation.ExampleTests.StepDefinitions
{
    [Binding]
    public class GmailLoginSteps
    {
        private readonly GmailLoginPage gmailLoginPage;

        public GmailLoginSteps(GmailLoginPage gmailLoginPage)
        {
            this.gmailLoginPage = gmailLoginPage;
        }

        [Given(@"I navigate to the Gmail login page")]
        public void GivenINavigateToTheGmailLoginPage()
        {
            gmailLoginPage.NavigateToLoginPage();
            Assert.IsTrue(gmailLoginPage.IsAtLoginPage(), "Failed to load Gmail login page.");
        }

        [When(@"I enter a valid email ""(.*)""")]
        public void WhenIEnterAValidEmail(string email)
        {
            gmailLoginPage.EnterEmail(email);
            gmailLoginPage.ClickNextButton();
        }

        [When(@"I enter the correct password ""(.*)""")]
        public void WhenIEnterTheCorrectPassword(string password)
        {
            gmailLoginPage.EnterPassword(password);
            gmailLoginPage.ClickPasswordNextButton();
        }

        [Then(@"I should be redirected to the Gmail inbox page")]
        public void ThenIShouldBeRedirectedToTheGmailInboxPage()
        {
            Assert.IsTrue(HomePage.IsAtInboxPage(), "Failed to navigate to Gmail inbox page.");
        }
    }
}