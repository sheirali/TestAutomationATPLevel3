using DesignPatternsTests.Pages.Sections;
using OpenQA.Selenium;
using System.Diagnostics;

namespace DesignPatternsTests.Pages
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

        private IWebElement RocketAddToCart(string rocketName)
        {
            //  aria-label="Add “Falcon 9” to your cart"
            string selector = $"[aria-label='Add “{rocketName}” to your cart']";
            Debug.WriteLine($"RocketAddToCart -- CssSelector = {selector}");
            var cartButton = FindClickableElement(By.CssSelector(selector));
            return cartButton;
        }

        public void AddFalcon9RocetToCart()
        {
            this.Open();
            AddToCartFalcon9?.Click();
            ViewCartButton?.Click();
            this.WaitUntilPageLoadsCompletely();
        }

        public void PurchaseRocket(string rocketName)
        {
            this.Open();
            RocketAddToCart(rocketName)?.Click();
            ViewCartButton?.Click();
            this.WaitUntilPageLoadsCompletely();//Cart page should now be loaded
        }
    }
}
