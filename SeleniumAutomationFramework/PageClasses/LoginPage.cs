using AventStack.ExtentReports;
using OpenQA.Selenium;

namespace SeleniumAutomationFramework.PageClasses
{
    internal class LoginPage
    {
        private IWebDriver driver;
        protected ExtentTest test;

        public LoginPage(IWebDriver _driver, ExtentTest _test)
        {
            driver = _driver;
            test = _test;
        }

        private By userNameEle = By.Id("username");
        private By passwordEle = By.Id("password");
        private By submitButton = By.XPath("//button[@class='radius']");
        private By failedMessage = By.Id("flash");


        public void enterUsername(string username)
        {
            driver.FindElement(userNameEle).SendKeys(username);
            test.Log(Status.Info, "Username " + username + "was entered");


        }

        public void enterPassword(string password)
        {          
            driver.FindElement(passwordEle).SendKeys(password);
            test.Log(Status.Info, "Password was entered");
        }

        public void submit()
        {
            driver.FindElement(submitButton).Click();
            test.Log(Status.Info, "Hit Enter");

        }

        public SecureAreaPage logIn(string username, string password)
        {
            enterUsername(username);
            enterPassword(password);
            submit();

            return new SecureAreaPage(driver);
        }

        public string getFailedMessage() 
        {
            return driver.FindElement(failedMessage).Text;
        }
    }
}
