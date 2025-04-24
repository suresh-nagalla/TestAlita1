using OpenQA.Selenium;

public class WebDriverManager
{
    public IWebDriver driver;

    public WebDriverManager()
    {
        driver = new ChromeDriver(); // Hardcoded dependency.
    }
}
