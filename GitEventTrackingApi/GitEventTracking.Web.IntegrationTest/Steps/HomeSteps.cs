using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GitEventTracking.Web.IntegrationTest.Steps
{
    [Binding]
    public sealed class HomeSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly TestSettings _settings;
        public HomeSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _settings = scenarioContext["TEST_SETTINGS"] as TestSettings;
            if (_settings is null) throw new NullReferenceException("Test Settings are required");
            _driver = _settings.Driver;
        }

        [Given(@"I am on Home page")]
        public void GivenIAmOnHomePage()
        {
            var url = _settings.Domain;
            _driver.Navigate().GoToUrl(url);
        }
    }
}
