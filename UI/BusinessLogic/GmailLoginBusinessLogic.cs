using AutomationFramework.UI.Pages;
using OpenQA.Selenium;

namespace AutomationFramework.UI.BusinessLogic
{
    public class GmailLoginBusinessLogic
    {
        private readonly GmailLoginPage _gmailLoginPage;

        public GmailLoginBusinessLogic(IWebDriver driver)
        {
            _gmailLoginPage = new GmailLoginPage(driver);
        }

        public void Login(string email, string password)
        {
            _gmailLoginPage.EnterEmail(email);
            _gmailLoginPage.ClickNext();

            if (!string.IsNullOrEmpty(password))
            {
                _gmailLoginPage.EnterPassword(password);
                _gmailLoginPage.ClickNext();
            }
        }

        public bool VerifyInboxVisible()
        {
            return _gmailLoginPage.IsInboxVisible();
        }

        public bool VerifyErrorMessageVisible()
        {
            return _gmailLoginPage.IsErrorMessageVisible();
        }
    }
}
