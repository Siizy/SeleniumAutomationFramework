using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomationFramework.Utils;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAutomationFramework.TestClasses
{
    internal class BaseTest
    {
       protected IWebDriver driver;
       protected Dictionary<string, string> testData;
       public static ExtentTest test;
       public static ExtentReports extent;



        [OneTimeSetUp]
        public void ExtentStart()
        {
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\ReportResults\");
            extent.AttachReporter(htmlreporter);
        }

        [SetUp]
        public void setUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);           
            testData = ExcelData.GetTestData(TestContext.CurrentContext.Test.Name);

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            test.Log(Status.Info, "Go to URL" + Settings.Default.url);
            driver.Url = Settings.Default.url;
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
                file.SaveAsFile(@"C:\ReportResults\screenshot.png");
                test.Fail("Test Failed",
                            MediaEntityBuilder.CreateScreenCaptureFromPath(@"C:\ReportResults\screenshot.png").Build());

            }

            driver.Quit();
        }
    }
}
