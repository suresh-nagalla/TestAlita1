using Example.TestAutomation.DemoTests.Settings.Models;
using Example.TestAutomation.Ui.Options;
using Microsoft.Extensions.Options;

namespace Example.TestAutomation.DemoTests.Pages
{
    public interface IPage
    {
        public IOptions<ExampleOptions> oneIncOptions { get; }

        public void NavigateToLoginPage();
        public void NavigateToPage(string url);

        public void SetUserName(string userName);

        public void SetPassword(string password);

        public void ClickLoginButton();
        void LoginToApp(User user);
    }
}