using TechTalk.SpecFlow;

[Binding]
public class GmailLoginSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly GmailLoginPage _gmailLoginPage;

    public GmailLoginSteps(ScenarioContext scenarioContext, GmailLoginPage gmailLoginPage)
    {
        _scenarioContext = scenarioContext;
        _gmailLoginPage = gmailLoginPage;
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
        _gmailLoginPage.VerifyInvalidLoginErrorMessage();
    }
}
using AutomationFramework.UI.BusinessLogic;
using AutomationFramework.Core.Config;
using OpenQA.Selenium;
using FluentAssertions;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class GmailLoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly GmailLoginBusinessLogic _gmailLoginBusinessLogic;

        public GmailLoginSteps(ScenarioContext scenarioContext)
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

        [When(@"I enter ""(.*)"" and ""(.*)""")]
        public void WhenIEnterCredentials(string email, string password)
        {
            _gmailLoginBusinessLogic.Login(email, password);
        }

        [Then(@"I should see the inbox")]
        public void ThenIShouldSeeTheInbox()
        {
            _gmailLoginBusinessLogic.VerifyInboxVisible().Should().BeTrue("Inbox should be visible after a successful login.");
        }

        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            _gmailLoginBusinessLogic.VerifyErrorMessageVisible().Should().BeTrue("Error message should be displayed after a failed login attempt.");
        }
    }
}
