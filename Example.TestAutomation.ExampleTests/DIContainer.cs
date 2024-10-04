using Example.TestAutomation.DemoTests.Pages;
using Example.TestAutomation.Ui.Setup;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;


namespace Example.TestAutomation.DemoTests
{
    public class DIContainer
    {
        public static IServiceCollection Services { get; set; }

        [ScenarioDependencies]
        public static IServiceCollection SetServices()
        {
            Services = new ServiceCollection();
            Services.AddScoped<IPage, LoginPage>();
            Startup.SetServices(Services);

            return Services;
        }
    }

}
