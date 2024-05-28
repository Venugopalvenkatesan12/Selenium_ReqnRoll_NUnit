using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumReqnRollNunit.Helpers;

namespace SeleniumReqnRollNunit.Pages
{
    public abstract class BasePage(IWebDriver webDriver)
    {
        readonly IWebDriver driver = webDriver;
        readonly WaitHelper waitHelper = new(webDriver);

        readonly string? applicationURL = JsonHelper.GetConfigValue("applicationDetails:url");
        readonly string? appTitle = JsonHelper.GetConfigValue("applicationDetails:title");

        public void BrowseURL()
        {
            driver.Navigate().GoToUrl(applicationURL);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            waitHelper.WaitForWebElement(HomePage_by);
            //test.Log(Status.Pass, "URL browser successfully!");
        }

        public void VerifyApplicationRunning()
        {
            if (driver.Title != null && driver.Title.Equals(appTitle))
                Assert.That(true, "Application Up and Running!");
            //test.Log(Status.Pass, "Application Up and Running!");
            else
                BrowseURL();            
        }

        public void VerifyPageTitle(string expTitle)
        {
            string actTitle = driver.Title;
            Assert.Equals(expTitle, actTitle);
            //test.Log(Status.Pass, "Verifed Page title successfully!");
        }

        By HomePage_by => By.XPath("//div[@id='header_logo']/a[@title='My Shop']");
    }
}
