using Example.TestAutomation.DemoTests.Settings.Models;
using Example.TestAutomation.Ui.Extensions;
using Example.TestAutomation.Ui.Options;
using Example.TestAutomation.Ui.Setup;
using Microsoft.Extensions.Options;

namespace Example.TestAutomation.DemoTests.Pages
{
    public class LoginPage : IPage
    {
        private readonly IWebDriver _driver;
        private readonly IOptions<ExampleOptions> _exampleOptions;
        public LoginPage(IDriverFactory driverFactory, IOptions<ExampleOptions> exampleOptions)
        {
            _driver = driverFactory.WebDriver!;
            _exampleOptions = exampleOptions!;
        }

        private readonly By _loginButton = By.XPath("//input[@type='submit']");
        private readonly By _userName = By.XPath("//input[@id='user-name']");
        private readonly By _password = By.XPath("//input[@id='password']");

        public IOptions<ExampleOptions> oneIncOptions => throw new NotImplementedException();

        public void ClickLoginButton()
        {
            SeleniumExtensions.LocateWidget(_driver, _loginButton).Click();
        }

        public void LoginToApp(User user)
        {
            SetUserName(user.UserName);
            SetPassword(user.Password);
            ClickLoginButton();
        }

        public void NavigateToLoginPage()
        {
            NavigateToPage(_exampleOptions.Value.SwagLabsOptions!.WebAppUrl);
        }

        public void NavigateToPage(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void SetPassword(string password)
        {
            SeleniumExtensions.LocateWidget(_driver, _password).SendKeys(password);
        }

        public void SetUserName(string userName)
        {
            SeleniumExtensions.LocateWidget(_driver, _userName).SendKeys(userName);
        }
    }
}
