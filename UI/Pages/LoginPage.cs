using OpenQA.Selenium;

public class LoginPage
{
    private IWebDriver _driver;

    public void EnterUsername(string username)
    {
        _driver.FindElement(By.Id("username")).SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        _driver.FindElement(By.Id("password")).SendKeys(password);
    }

    public void ClickLogin()
    {
        _driver.FindElement(By.Id("login")).Click();
    }
}
