using OpenQA.Selenium;

namespace Example.TestAutomation.Ui.Setup;

public interface IDriverFactory
{
    IWebDriver? WebDriver { get; set; }
    IWebDriver GetRemoteWebDriver(string browserType, Uri uri, DriverOptions options);
    void CreateLocalWebDriverWithWebDriverManager(string browserType);
    IWebDriver CreateLocalWebDriver(string browserType);
}