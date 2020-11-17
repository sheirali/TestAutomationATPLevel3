using DesignPatternsTests.Pages.Sections.BreadcrumbSection;
using DesignPatternsTests.Pages.Sections.MenuSection;
using DesignPatternsTests.Pages.Sections.SearchSection;
using DesignPatternsTests.Pages.Sections.ViewCartSection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests.Pages.CartPage
{
    public partial class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) :
            base(driver)
        {

        }

        public override string Url => "http://demos.bellatrix.solutions/cart/";

        public MenuSection MainMenu => new MenuSection(Driver);
        public SearchSection SearchProduct => new SearchSection(Driver);
        public ViewCartSection ViewCart => new ViewCartSection(Driver);
        public BreadcrumbSection Breadcrumb => new BreadcrumbSection(Driver);
    }
}
