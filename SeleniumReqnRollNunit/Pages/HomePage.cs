using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumReqnRollNunit.Helpers;

namespace SeleniumReqnRollNunit.Pages
{
    public class HomePage(IWebDriver webDriver) : BasePage(webDriver)
    {
        readonly IWebDriver driver = webDriver;
        readonly WaitHelper waitHelper = new(webDriver);

        public void VerifyLogo()
        {
            Logo_img.Displayed.Equals(true);
        }

        public void NavigateToHomePage()
        {
            Logo_img.Click();
            waitHelper.WaitForWebElement(HomePageHeader_lbl);
        }

        public void EnterTextInSearchBox(string searchText)
        {
            Search_txt.SendKeys(searchText);
        }

        public void ClickOnSearchButton()
        {
            Search_btn.Click();
            waitHelper.WaitForWebElement(SearchResults_by);
        }

        public void VerifySearchRestultsPageDisplayed()
        {
            Assert.Equals(true, SearchResults_div.Displayed);
        }

        public void VerifySearchTextInResultHeader(string text)
        {
            string headerText = ResultHeaderSearch_txt.Text;
            headerText = headerText.Replace('"', ' ').Trim();

            if (text.Equals(headerText, StringComparison.InvariantCultureIgnoreCase))
                Assert.Pass(text + " present in search result header");
            else
                Assert.Fail(text + " not present in search result header");
        }

        public void VerifyResultCountText(string expCount)
        {
            string text = HeadingCounter_lbl.Text;
            string[] values = text.Split(' ');
            Assert.Equals(values[0], expCount);
        }

        public void VerifySortByDisplayed()
        {
            Assert.Equals(true, SortBy_drpdwn.Enabled);
        }

        public void VerifyShowingRestultsCountText(string expCount)
        {
            string text = ShowingResultCount_lbl.Text;
            string[] option = { "of" };
            string[] values = text.Split(option, StringSplitOptions.None);
            string[] partText = values[1].Trim().Split(' ');

            if (Int32.TryParse(partText[0].Trim(), out int count))          
                Assert.Equals(count, expCount);
            else            
                Assert.Fail("Invalid result count string");            
        }

        public void VerifySearchResultItemsCount(string expCount)
        {
            Assert.Equals(SearchResultItems_lst.Count, expCount);
        }


        IWebElement Logo_img => driver.FindElement(By.XPath("//div[@id='header_logo']/a[@title='My Shop']/img"));

        By HomePageHeader_lbl => By.XPath("//div[@class='columns-container']//div[@id='slider_row']");

        IWebElement SignIn_lnk => driver.FindElement(By.LinkText("Sign in"));

        IWebElement SignOut_lnk => driver.FindElement(By.LinkText("Sign out"));

        IWebElement UserDetails_lnk => driver.FindElement(By.XPath("//a[@title = 'View my customer account']"));

        IWebElement ContactUs_lnk => driver.FindElement(By.LinkText("Contact us"));

        IWebElement Women_lnk => driver.FindElement(By.LinkText("Women"));

        IWebElement Dresses_lnk => driver.FindElement(By.LinkText("Dresses"));

        IWebElement Tshirts_lnk => driver.FindElement(By.LinkText("T-shirts"));

        IWebElement Homepage_div => driver.FindElement(By.XPath("//div[@class='columns-container']//div[@id='slider_row']"));


        //Search related elements

        IWebElement Search_txt => driver.FindElement(By.Id("search_query_top"));

        IWebElement Search_btn => driver.FindElement(By.Name("submit_search"));

        IWebElement HeadingCounter_lbl => driver.FindElement(By.ClassName("heading-counter"));

        IWebElement ResultHeaderSearch_txt => driver.FindElement(By.ClassName("lighter"));

        IWebElement SortBy_drpdwn => driver.FindElement(By.Id("selectProductSort"));

        IWebElement SearchResults_div => driver.FindElement(By.Id("center_column"));
        
        By SearchResults_by => By.Id("center_column");

        IList<IWebElement> SearchResultItems_lst => driver.FindElements(By.XPath("//ul[@class='product_list grid row']/li"));

        IWebElement ShowingResultCount_lbl => driver.FindElement(By.ClassName("product-count"));
    }
}
