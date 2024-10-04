using Example.TestAutomation.Ui.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Example.TestAutomation.Ui.Setup
{
    public class Startup
    {
        public static IServiceCollection SetServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();

            services.AddSingleton(config);
            services.Configure<ExampleOptions>(options => config.GetSection(nameof(ExampleOptions)).Bind(options));
            services.AddSingleton<IExampleOptions, ExampleOptions>();
            services.AddScoped<IDriverFactory, DriverFactory>();
            return services;
        }
    }

}
