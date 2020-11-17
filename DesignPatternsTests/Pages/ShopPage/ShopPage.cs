using DesignPatternsTests.Pages.Sections.MenuSection;
using DesignPatternsTests.Pages.Sections.SearchSection;
using DesignPatternsTests.Pages.Sections.ViewCartSection;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests.Pages.ShopPage
{
    public partial class ShopPage : BasePage
    {
        public ShopPage(IWebDriver driver) :
            base(driver)
        {
        }

        public override string Url => "http://demos.bellatrix.solutions/";

        public MenuSection MainMenu => new MenuSection(Driver);
        public SearchSection SearchProduct => new SearchSection(Driver);
        public ViewCartSection ViewCart => new ViewCartSection(Driver);

        public IWebElement AddToCartFalcon9 => FindClickableElement(By.CssSelector("[data-product_id='28']"));
        
        public IWebElement ViewCartButton => FindClickableElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public void AddFalcon9RocetToCart()
        {
            this.Open();
            AddToCartFalcon9?.Click();
            ViewCartButton?.Click();
            this.WaitUntilPageLoadsCompletely();
        }
    }
}
