using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

namespace Example.TestAutomation.Ui.Reports
{
    public class ReportHelper
    {
        public ExtentReports ExtentReports { get; set; }
        public ExtentSparkReporter ExtentSparkReporter { get; set; }



        [ThreadStatic]
        public static ExtentTest? Feature;

        [ThreadStatic]
        public static ExtentTest? Scenario;

        public ReportHelper(ExtentReports extentReports, ExtentSparkReporter extentSparkReporter)
        {
            ExtentReports = extentReports;

            ExtentSparkReporter = extentSparkReporter;


            ExtentReports.AttachReporter(ExtentSparkReporter);
        }

        public void InitializeFeature(FeatureContext featureContext)
        {
            Feature = ExtentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title).AssignCategory(featureContext.FeatureInfo.Tags);
        }

        public void SetScenario(ScenarioContext scenarioContext)
        {
            Scenario = Feature!.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            Scenario.AssignCategory(scenarioContext.ScenarioInfo.Tags);
        }

        public void CloseReports()
        {
            ExtentReports.Flush();
        }
    }
}
