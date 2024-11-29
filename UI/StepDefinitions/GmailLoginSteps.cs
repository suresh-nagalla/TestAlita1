using TechTalk.SpecFlow;
using AutomationFramework.UI.BusinessLogic;
using AutomationFramework.Core.Config;
using OpenQA.Selenium;
using FluentAssertions;

namespace AutomationFramework.UI.StepDefinitions
{
    [Binding]
    public class GmailLoginSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly GmailLoginPage _gmailLoginPage;
    private readonly ILogger _logger;

    public GmailLoginSteps(ScenarioContext scenarioContext, GmailLoginPage gmailLoginPage, ILogger logger)
    {
        _scenarioContext = scenarioContext;
        _gmailLoginPage = gmailLoginPage;
        _logger = logger;
    }

    [Given("I am on the Gmail login page")]
    public void GivenIAmOnTheGmailLoginPage()
    {
        _gmailLoginPage.NavigateToLoginPage();
    }

    [When("I enter a valid username in the username text box")]
    public void WhenIEnterAValidUsernameInTheUsernameTextBox()
    {
        _gmailLoginPage.EnterUsername("valid.username@gmail.com");
    }

    [Then("I should see the next button enabled")]
    public void ThenIShouldSeeTheNextButtonEnabled()
    {
        _gmailLoginPage.IsNextButtonEnabled().Should().BeTrue();
    }
}
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
