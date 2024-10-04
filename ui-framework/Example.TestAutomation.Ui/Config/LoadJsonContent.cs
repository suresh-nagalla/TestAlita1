using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;




namespace Example.TestAutomation.Ui.Config;

public class LoadJsonContent
{
    //public ServiceProvider ConfigureServices(IServiceCollection services)
    //{
    //    //services = new ServiceCollection()
    //    //    .AddTransient<IOneIncOptions, IOneIncOptions>()


    //}

    public IConfiguration ConfigureSettings()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
            .Build();

        return config;
    }
}