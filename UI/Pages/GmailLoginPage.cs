using OpenQA.Selenium;
using AutomationFramework.Core.Base;

namespace AutomationFramework.UI.Pages
{
    public class GmailLoginPage : BasePage
    {
        private By EmailField => By.Id("identifierId");
        private By PasswordField => By.Name("password");
        private By NextButton => By.Id("identifierNext");
        private By ErrorMessage => By.CssSelector("div[jsname='B34EJ']"); // Example error message selector
        private By InboxContainer => By.CssSelector("div[role='main']");

        public GmailLoginPage(IWebDriver driver) : base(driver) { }

        public void EnterEmail(string email)
        {
            EnterText(EmailField, email);
        }

        public void ClickNext()
        {
            ClickElement(NextButton);
        }

        public void EnterPassword(string password)
        {
            EnterText(PasswordField, password);
        }

        public bool IsInboxVisible()
        {
            return IsElementVisible(InboxContainer);
        }

        public bool IsErrorMessageVisible()
        {
            return IsElementVisible(ErrorMessage);
        }
    }
}
