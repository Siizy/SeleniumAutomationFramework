using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomationFramework.PageClasses;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumAutomationFramework.TestClasses
{
    internal class LoginTest:BaseTest
    {

        LoginPage lp;
        WelcomePage wp;

        [Test]
        public void formAuthenticationTest()
        {
            wp = new WelcomePage(driver, test);
            lp= new LoginPage(driver, test);

            wp.OpenLink("Form Authentication");
            string msg = lp.logIn(testData["username"], testData["password"]).getSuccessMessage();
            Assert.That(msg.Contains("You logged into a secure area!"));
            test.Log(Status.Pass, "Test Passed");
        }

        [Test]
        public void formAuthenticationTestfail()
        {
            wp = new WelcomePage(driver, test);
            lp = new LoginPage(driver, test);

            wp.OpenLink("Form Authentication");           
            lp.logIn(testData["username"], testData["password"]);
            string msg = lp.getFailedMessage();
            Assert.That(msg.Contains("Your password is invalid!"));
            test.Log(Status.Pass, "Test Passed");
        }
       
    }
}