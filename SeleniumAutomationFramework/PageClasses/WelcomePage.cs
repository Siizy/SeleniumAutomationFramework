using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace SeleniumAutomationFramework.PageClasses
{
    internal class WelcomePage
    {
        protected IWebDriver driver;
        protected ExtentTest test;
        public WelcomePage(IWebDriver _driver, ExtentTest _test)
        {
            driver = _driver;
            test = _test;
        }

        public void OpenLink(string linkName) 
        {
            driver.FindElement(By.LinkText(linkName)).Click();
            test.Log(Status.Info, "Link " + linkName + "was clicked" );

        }
    }
}
