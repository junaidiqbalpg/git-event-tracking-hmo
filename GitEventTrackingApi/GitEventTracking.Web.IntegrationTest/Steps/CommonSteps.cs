using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace GitEventTracking.Web.IntegrationTest.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IWebDriver _driver;
        private readonly TestSettings _settings;
        public CommonSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _settings = scenarioContext["TEST_SETTINGS"] as TestSettings;
            if (_settings is null) throw new NullReferenceException("Test Settings are required");
            _driver = _settings.Driver;
        }

        [Given(@"I see '(.*)'")]
        [When(@"I see '(.*)'")]
        [Then(@"I see '(.*)'")]
        public void SeeText(string text)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(e => e.FindElement(By.XPath($"//body//*[contains(text(),'{text}')]")));
            Assert.IsTrue(element.Displayed);
        }

        [When(@"I enter '(.*)' into the '(.*)' field")]
        [Then(@"I enter '(.*)' into the '(.*)' field")]
        public void WhenIEnterTextIntoTheField(string text, string fieldName)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(e => e.FindElement(By.Name(fieldName))).SendKeys(text);
        }

        [When(@"I click the '(.*)' button")]
        [Then(@"I click the '(.*)' button")]
        public void WhenIClickTheButton(string buttonText)
        {
            _driver.FindElement(By.XPath($"//button[contains(text(), '{buttonText}')]")).Click();
        }
    }
}
