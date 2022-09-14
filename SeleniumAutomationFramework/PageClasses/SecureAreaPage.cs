using OpenQA.Selenium;

namespace SeleniumAutomationFramework.PageClasses
{
    internal class SecureAreaPage
    {
        private IWebDriver driver;

        public SecureAreaPage(IWebDriver _driver)
        {
            driver = _driver;

        }

        By successMessage = By.XPath("//div[contains(text(),'You logged into a secure area!')]");

        public String getSuccessMessage()
        {
            return driver.FindElement(successMessage).Text;

        }
    }
}
