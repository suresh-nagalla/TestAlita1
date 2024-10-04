using Example.TestAutomation.DemoTests.Pages;
using Example.TestAutomation.DemoTests.Settings;
using Example.TestAutomation.Ui.Options;
using Example.TestAutomation.Ui.Setup;
using Microsoft.Extensions.Options;

namespace Example.TestAutomation.DemoTests.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private ScenarioContext? _scenarioContext;
        private IOptions<ExampleOptions> _exampleOptions;

        private IPage _loginPage;
        private IWebDriver _driver;
        private readonly HomePage _homePage;

        public LoginSteps(ScenarioContext scenarioContext, IOptions<ExampleOptions> exampleOptions, IPage loginPage, IDriverFactory driverFactory)
        {
            _scenarioContext = scenarioContext;
            _exampleOptions = exampleOptions;
            _loginPage = loginPage;
            _driver = driverFactory.WebDriver;
            _homePage = new HomePage(_driver);

        }

        [Given(@"'([^']*)' user logs into WebApp")]
        public void GivenUserLogsIntoWebApp(UserProvider.Users userKey)
        {
            _loginPage.NavigateToLoginPage();
            var user = new UserProvider(_exampleOptions.Value).DefaultUiUser;
            _loginPage.LoginToApp(user);
        }

        [Given(@"'([^']*)' user logs into App")]
        public void GivenUserLogsIntoApp(UserProvider.Users userKey)
        {
            _loginPage.NavigateToLoginPage();
            var user = new UserProvider(_exampleOptions.Value).DefaultUiUser;
            _loginPage.LoginToApp(user);
        }

        [Then(@"Home screen is displayed")]
        public void ThenHomeScreenIsDisplayed()
        {
            _homePage.IsHomePageDisplayed().Should().BeTrue();
        }
    }

}
