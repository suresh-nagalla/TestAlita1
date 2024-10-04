using Example.TestAutomation.DemoTests.Constants;
using Example.TestAutomation.Ui.Extensions;

namespace Example.TestAutomation.DemoTests.Pages;


public class HomePage
{
    private IWebDriver _driver;
    private readonly By _homePageTitle = By.XPath("//div[@class='product_label']");

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public bool IsHomePageDisplayed()
    {
        _driver.WaitForLoadingIconToDisappear();
        var isHomePageDisplayed = _driver.LocateWidget(_homePageTitle, 120).Displayed;
        _driver.WaitForLoadingIconToDisappear(TimeSpan.FromSeconds(SimpleTimeConstants.ThreeSeconds));
        return isHomePageDisplayed;
    }
    

    

}
