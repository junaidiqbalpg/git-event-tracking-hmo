using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace GitEventTracking.Web.IntegrationTest.Hooks
{
    [Binding]
    public class Hooks
    {
        private static Microsoft.Extensions.Configuration.IConfiguration _config;
        private IWebDriver _webDriver; 

        [BeforeTestRun]
        public static void CreateConfig()
        {
            if (_config == null)
            {
                _config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
            }
        }

        [BeforeScenario]
        public void CreateWebDriver(ScenarioContext context)
        {
            // We are using Chrome, but you can use any driver
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");
            options.AddArgument("--disable-gpu");
            if (_config.GetValue<bool>("headless"))
            {
                options.AddArgument("--headless");
            }
            
            var testDataDirectory = "/Integration.Test";
            if (_config.GetValue<bool>("useDocker")) {
                // Connect to Selenium Grid
                _webDriver = new RemoteWebDriver(new Uri("http://hub:4444/wd/hub/"), options);
            } else {
                _webDriver = new ChromeDriver(".", options);
                testDataDirectory = Directory.GetCurrentDirectory();
            }
            testDataDirectory = Path.Combine(testDataDirectory, "TestData");
            Directory.CreateDirectory(testDataDirectory);

            var domain = _config.GetValue<string>("domain");
            var defaultTimeoutSeconds = _config.GetValue<int>("defaultTimeoutSeconds");
            context["TEST_SETTINGS"] = new TestSettings(domain, _webDriver, defaultTimeoutSeconds, testDataDirectory);
        }

        [AfterScenario]
        public void CloseWebDriver(ScenarioContext context)
        {
            _webDriver.Quit();
        }
    }
}