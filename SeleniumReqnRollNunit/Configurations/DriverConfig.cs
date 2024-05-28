using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace SeleniumReqnRollNunit.Configurations
{
    public class DriverConfig
    {
        public IWebDriver InitializeDriver(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AcceptInsecureCertificates = true;
                    options.AddArguments("start-maximized", "--disable-popup-blocking");
                    return new ChromeDriver(options);

                case BrowserType.Firefox:
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    firefoxOptions.AcceptInsecureCertificates = true;
                    firefoxOptions.AddArguments("start-maximized");
                    return new FirefoxDriver(firefoxOptions);

                case BrowserType.Edge:
                    return new EdgeDriver();

                case BrowserType.Safari:
                    return new SafariDriver();

                default:
                    throw new ArgumentException($"Browser not implemented {browserType}");
            }
        }

        public enum BrowserType
        {
            Chrome,
            Firefox,
            Edge,
            Safari
        };
    }
}
