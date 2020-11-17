using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests.Pages.Sections.SearchSection
{
    public partial class SearchSection : BaseSection
    {
        public SearchSection(IWebDriver driver) :
                base(driver)
        {
        }

        public IWebElement SearchInput => FindElement(By.XPath("//input[@class='search-field'][1]"));
    }
}
