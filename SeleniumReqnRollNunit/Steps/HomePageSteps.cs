using AventStack.ExtentReports;
using OpenQA.Selenium;
using Reqnroll;
using SeleniumReqnRollNunit.Pages;

namespace SeleniumReqnRollNunit.Steps
{
    [Binding]
    public class HomePageSteps(IWebDriver driver)
    {
        private readonly HomePage homePage = new(driver);

        [Given(@"I browse Application URL")]
        public void GivenIBrowseApplicationURL()
        {
            homePage.BrowseURL();
        }

        [Then(@"Verify website logo")]
        public void ThenVerifyWebsiteLogo()
        {
            homePage.VerifyLogo();
        }

        [Given(@"Application should be up and running")]
        public void GivenApplicationShouldBeUpAndRunning()
        {
            homePage.VerifyApplicationRunning();
        }

        [Given(@"I navigate to homepage")]
        public void GivenINavigateToHomepage()
        {
            homePage.NavigateToHomePage();
        }

        [When(@"I enter '(.*)' in seach box")]
        public void WhenIEnterInSeachBox(string searchText)
        {
            homePage.EnterTextInSearchBox(searchText);
        }

        [When(@"I click on search button")]
        public void WhenIClickOnSearchButton()
        {
            homePage.ClickOnSearchButton();
        }

        [Then(@"Verify search result page displayed")]
        public void ThenVerifySearchResultPageDisplayed()
        {
            homePage.VerifySearchRestultsPageDisplayed();
        }

        [Then(@"Verify search text '(.*)' in results page")]
        public void ThenVerifySearchTextInResultsPage(string searchText)
        {
            homePage.VerifySearchTextInResultHeader(searchText);
        }

        [Then(@"Verify result count '(.*)'")]
        public void ThenVerifyResultCountText(string expCount)
        {
            homePage.VerifyResultCountText(expCount);
        }

        [Then(@"Verify sort by dropdwon displayed")]
        public void ThenVerifySortByDropdwonDisplayed()
        {
            homePage.VerifySortByDisplayed();
        }

        [Then(@"Verify showing results text with count '(.*)'")]
        public void ThenVerifyShowingResultsTextWithCount(string expCount)
        {
            homePage.VerifyShowingRestultsCountText(expCount);
        }

        [Then(@"Verify '(.*)' items displayed in result page")]
        public void ThenVerifyItemsDisplayedInResultPage(string expCount)
        {
            homePage.VerifySearchResultItemsCount(expCount);
        }
    }
}
