using OpenQA.Selenium;
using SeleniumReqnRollNunit.Helpers;

namespace SeleniumReqnRollNunit.Pages
{
    public class WomenSectionPage(IWebDriver webDriver) : BasePage(webDriver)
    {
        readonly IWebDriver driver = webDriver;
        readonly WaitHelper waitHelper = new(webDriver);

        public void ClickOnWomenSection()
        {
            Women_lnk.Click();
            waitHelper.WaitForWebElement(WomenSectionHeader_by);
        }

        public void VerifyCategoryTitle(string text)
        {
            Women_txt.Text.Trim().Equals(text);
        }

        public void VerifySubCategoriesCount(string count)
        {
            Categories_lst.Count.ToString().Trim().Equals(count);
        }

        IWebElement Women_lnk => driver.FindElement(By.LinkText("Women"));

        IWebElement Women_txt => driver.FindElement(By.XPath("//h1[@class='page-heading product-listing']/span[@class='cat-name']"));

        IList<IWebElement> Categories_lst => driver.FindElements(By.XPath("//span[text()='Categories']/../../ul/li"));

        By WomenSectionHeader_by => By.XPath("//h1[@class='page-heading product-listing']");
    }
}
