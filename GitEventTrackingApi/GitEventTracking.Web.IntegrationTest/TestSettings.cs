using OpenQA.Selenium;

namespace GitEventTracking.Web.IntegrationTest
{
    public class TestSettings
    {
        public string Domain { get; private set; }
        public IWebDriver Driver { get; private set; }
        public int DefaultTimeoutSeconds { get; private set; }
        public string TestDataDirectory { get; private set; }

        public TestSettings(string domain, IWebDriver driver, int defaultTimeoutSeconds, string testDataDirectory)
        {
            this.Domain = domain;
            this.Driver = driver;
            this.DefaultTimeoutSeconds = defaultTimeoutSeconds;
            this.TestDataDirectory = testDataDirectory;
        }
    }
}