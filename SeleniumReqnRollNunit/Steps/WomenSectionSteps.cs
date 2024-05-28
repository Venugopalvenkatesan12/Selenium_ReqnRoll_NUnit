using OpenQA.Selenium;
using Reqnroll;
using SeleniumReqnRollNunit.Pages;

namespace SeleniumReqnRollNunit.Steps
{
    [Binding]
    public class WomenSectionSteps(IWebDriver driver)
    {
        private readonly WomenSectionPage womenSectionPage = new(driver);

        [When(@"I Click on Women tab")]
        public void GivenIClickOnWomenTab()
        {
            womenSectionPage.ClickOnWomenSection();
        }

        [Then(@"Verify Category title '(.*)'")]
        public void VerifyCategoryTitle(string secTitle)
        {
            womenSectionPage.VerifyCategoryTitle(secTitle);
        }

        [Then(@"Verify '(.*)' categories displayed for Women section")]
        public void ThenVerifyTwoCategoriesDisplayedWomenSection(string count)
        {
            womenSectionPage.VerifySubCategoriesCount(count);
        }
    }
}
