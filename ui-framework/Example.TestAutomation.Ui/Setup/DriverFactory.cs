using BoDi;
using Microsoft.Extensions.DependencyInjection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Example.TestAutomation.Ui.Setup
{
    public class DriverFactory : IDriverFactory
    {
        public IWebDriver? WebDriver { get; set; }
        public IWebDriver CreateLocalWebDriver(string browserType)
        {
            WebDriver = browserType switch
            {
                "chrome" => GetChromeBrowser(),
                "firefox" => GetFirefoxBrowser(),
                "edge" => GetEdgeBrowser(),
                _ => throw new ArgumentException($"Please provide matching browsers(chrome|firefox|edge) {nameof(browserType)}")
            };

            return WebDriver;
        }

        private IWebDriver GetChromeBrowser()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddUserProfilePreference("safebrowsing.disable_download_protection", true);
            options.AddArgument("--start-maximized");
            //options.AddArgument("--incognito");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-geolocation");
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore;
            WebDriver = new ChromeDriver(options);

            return WebDriver;
        }

        private IWebDriver GetFirefoxBrowser()
        {
            var options = new FirefoxOptions();
            options.AddAdditionalFirefoxOption("safebrowsing.enabled", true);
            options.AddAdditionalFirefoxOption("safebrowsing.disable_download_protection", true);
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore;
            IWebDriver firefoxDriver = new FirefoxDriver(options);
            return firefoxDriver;
        }

        private IWebDriver GetEdgeBrowser()
        {
            var options = new EdgeOptions();
            options.AddUserProfilePreference("safebrowsing.enabled", true);
            options.AddUserProfilePreference("safebrowsing.disable_download_protection", true);
            options.UnhandledPromptBehavior = UnhandledPromptBehavior.Ignore;
            IWebDriver edgeDriver = new EdgeDriver(options);
            return edgeDriver;
        }

        public IWebDriver GetRemoteWebDriver(string browserType, Uri uri, DriverOptions options)
        {
            if (uri is null || options is null)
            {
                throw new ArgumentNullException($"uri:{nameof(uri)} or options {nameof(options)} cannot be null");
            }
            return new RemoteWebDriver(uri, options);
        }


        public void CreateLocalWebDriverWithWebDriverManager(string browserType)
        {

        }
    }
}
