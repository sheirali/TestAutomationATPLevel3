using DesignPatternsTests.Pages.Sections.BreadcrumbSection;
using DesignPatternsTests.Pages.Sections.MenuSection;
using DesignPatternsTests.Pages.Sections.SearchSection;
using DesignPatternsTests.Pages.Sections.ViewCartSection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests.Pages.CheckoutPage
{
    public partial class CheckoutPage : BasePage
    {
        public CheckoutPage(IWebDriver driver) :
            base(driver)
        {

        }

        public override string Url => "http://demos.bellatrix.solutions/checkout/";

        public MenuSection MainMenu => new MenuSection(Driver);
        public SearchSection SearchProduct => new SearchSection(Driver);
        public ViewCartSection ViewCart => new ViewCartSection(Driver);
        public BreadcrumbSection Breadcrumb => new BreadcrumbSection(Driver);
    }
}
