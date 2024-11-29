using TechTalk.SpecFlow;
using OpenQA.Selenium;
using FluentAssertions;

[Binding]
public class GmailLoginPositiveSteps
{
    private readonly ScenarioContext _scenarioContext;
    private IWebDriver _driver;

    public GmailLoginPositiveSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _driver = (IWebDriver)_scenarioContext["driver"];
    }

    [Given("I am on the Gmail login page")]
    public void GivenIAmOnTheGmailLoginPage()
    {
        _driver.Navigate().GoToUrl("https://mail.google.com");
    }

    [When("I enter a valid username")]
    public void WhenIEnterAValidUsername()
    {
        var usernameField = _driver.FindElement(By.Id("identifierId"));
        usernameField.SendKeys("valid.username@gmail.com");
    }

    [Then("I should see the next button enabled")]
    public void ThenIShouldSeeTheNextButtonEnabled()
    {
        var nextButton = _driver.FindElement(By.Id("identifierNext"));
        nextButton.Enabled.Should().BeTrue();
    }
}