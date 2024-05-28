using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace SeleniumReqnRollNunit.Helpers
{
    public class WaitHelper(IWebDriver webDriver)
    {
        private readonly IWebDriver driver = webDriver;

        public void WaitForWebElement(By locator, int timeoutInMilliseconds = 5000)
        {
            TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutInMilliseconds);
            var wait = new WebDriverWait(driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(250)
            };
            wait.Until(c => c.FindElement(locator));
        }
    }
}
