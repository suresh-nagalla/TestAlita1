using OpenQA.Selenium;
using Example.TestAutomation.Helpers;

namespace Example.TestAutomation.ExampleTests.Pages
{
    public class GmailLoginPage : IPage
    {
        private readonly IWebDriver driver;

        public GmailLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By emailInput => By.Id("identifierId");
        private By passwordInput => By.Name("password");
        private By nextButton => By.Id("identifierNext");
        private By passwordNextButton => By.Id("passwordNext");

        public void NavigateToLoginPage()
        {
            driver.Navigate().GoToUrl("https://mail.google.com/");
        }

        public bool IsAtLoginPage()
        {
            return driver.Title.Contains("Gmail");
        }

        public void EnterEmail(string email)
        {
            WaitHelper.EnterText(driver, emailInput, email);
        }

        public void ClickNextButton()
        {
            WaitHelper.Click(driver, nextButton);
        }

        public void EnterPassword(string password)
        {
            WaitHelper.EnterText(driver, passwordInput, password);
        }

        public void ClickPasswordNextButton()
        {
            WaitHelper.Click(driver, passwordNextButton);
        }
    }
}