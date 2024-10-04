using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using Example.TestAutomation.Ui.Options;
using Example.TestAutomation.Ui.Reports;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Example.TestAutomation.Ui.Setup.Hooks;

[Binding]
public sealed class StartupHooks : IDisposable
{
    private static readonly object _lockObject = new object();
    private readonly ScenarioContext _scenarioContext;

    private readonly IDriverFactory _driverFactory;

    private readonly IOptions<ExampleOptions> _exampleOptions;
    public static ExtentReports ExtentReports { get; private set; }
    public static ExtentSparkReporter ExtentSparkReporter { get; private set; }
    public static ReportHelper ReportHelper { get; private set; }
    private static string _path;


    public StartupHooks(IOptions<ExampleOptions> exampleOptions, ScenarioContext scenarioContext, IDriverFactory driverFactory)
    {
        _exampleOptions = exampleOptions!;
        _scenarioContext = scenarioContext;
        _driverFactory = driverFactory;
    }


    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        ExtentReports = new ExtentReports();
        var dateTime = DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss tt");
        _path = Path.Combine(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "AutomationReports", dateTime);
        var reportPath = Path.Combine(_path, "reports.html");
        ExtentSparkReporter = new ExtentSparkReporter(reportPath);
        ReportHelper = new ReportHelper(ExtentReports, ExtentSparkReporter);
    }

    [BeforeFeature]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        ReportHelper.InitializeFeature(featureContext);
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        ReportHelper.CloseReports();
    }

    [BeforeScenario(Order = 1)]
    public void BeforeScenario()
    {
        _driverFactory.CreateLocalWebDriver(_exampleOptions.Value.BaseConfigOptions.BrowserName!);
        ReportHelper.SetScenario(_scenarioContext);
    }

    [AfterStep(Order = int.MinValue)]
    public void AfterStep(ScenarioContext scenarioContext)
    {
        GenerateReport(scenarioContext);
        //lock (_lockObject)
        //{
        //    GenerateReport(scenarioContext);
        //}
    }

    private void GenerateReport(ScenarioContext scenarioContext)
    {
        string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
        string stepName = scenarioContext.StepContext.StepInfo.Text;


        if (scenarioContext.TestError == null)
        {
            MarkupHelper.CreateLabel("ScenarioPassed", ExtentColor.Green);
            switch (stepType)
            {
                case "Given":
                    ReportHelper.Scenario!.CreateNode<Given>($"{stepName}");
                    break;
                case "When":
                    ReportHelper.Scenario!.CreateNode<When>($"{stepName}");
                    break;
                case "Then":
                    ReportHelper.Scenario!.CreateNode<Then>($"{stepName}");
                    break;
                case "And":
                    ReportHelper.Scenario!.CreateNode<And>($"{stepName}");
                    break;
            }
        }

        //When scenario fails
        if (scenarioContext.TestError != null)
        {
            //MarkupHelper.CreateLabel("Pass", ExtentColor.Red);
            switch (stepType)
            {
                case "Given":
                    ReportHelper.Scenario!.CreateNode<Given>($"{stepName}").Fail(scenarioContext.TestError.Message,
                                    MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenShot(scenarioContext)).Build());
                    break;
                case "When":
                    ReportHelper.Scenario!.CreateNode<When>($"{stepName}").Fail(scenarioContext.TestError.Message,
                            MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenShot(scenarioContext)).Build());
                    break;
                case "Then":
                    ReportHelper.Scenario!.CreateNode<Then>($"{stepName}").Fail(scenarioContext.TestError.Message,
                            MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenShot(scenarioContext)).Build());
                    break;
                case "And":
                    ReportHelper.Scenario!.CreateNode<And>($"{stepName}").Fail(scenarioContext.TestError.Message,
                            MediaEntityBuilder.CreateScreenCaptureFromPath(CaptureScreenShot(scenarioContext)).Build());
                    break;
            }
        }
    }


    private string CaptureScreenShot(ScenarioContext scenarioContext)
    {
        var screenshot = ((ITakesScreenshot)_driverFactory.WebDriver).GetScreenshot();
        var title = scenarioContext.ScenarioInfo.Title.Replace(" ", "").Replace("\"", "").Replace("/", ""); ;
        title = title.Length > 35 ? title[..35] : title;
        string location = Path.Combine($"{_path}", $"{title}.png");
        screenshot.SaveAsFile(location);
        return location;
    }

    [AfterScenario]
    public void AfterScenario()
    {
        if (_driverFactory.WebDriver != null)
        {
            Dispose();
        }
    }

    public void Dispose()
    {
        _driverFactory.WebDriver.Quit();
    }
}