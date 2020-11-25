using DemoPageTests.Pages.Sections;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using Unicorn.Web;
using Unicorn.Web.Pages;

namespace DemoPageTests.Pages
{
    public partial class ShopPage : NavigatablePage
    {
        public ShopPage()
        {
            Url = new Uri("http://demos.bellatrix.solutions/");
        }

        ////public MenuSection MainMenu => new MenuSection(Driver);
        ////public SearchSection SearchProduct => new SearchSection(Driver);
        ////public ViewCartSection ViewCart => new ViewCartSection(Driver);

        public Button AddToCartFalcon9 => ElementCreateService.CreateByCss<Button>("[data-product_id='28']");
        public Button ViewCartButton => ElementCreateService.CreateByCss<Button>("[class*='added_to_cart wc-forward']");

        public override Uri Url { get; set; }

        private Button RocketAddToCart(string rocketName)
        {
            // aria-label="Add “Falcon 9” to your cart"
            string selector = $"[aria-label='Add “{rocketName}” to your cart']";
            Debug.WriteLine($"RocketAddToCart -- CssSelector = {selector}");
            ////var cartButton = FindClickableElement(By.CssSelector(selector));
            var cartButton = ElementCreateService.CreateByCss<Button>("selector");
            return cartButton;
        }

        public void AddFalcon9RocetToCart()
        {
            Open();
            AddToCartFalcon9?.Click();
            ViewCartButton?.Click();
            WaitForPageToLoad();
        }

        public void PurchaseRocket(string rocketName)
        {
            Open();
            RocketAddToCart(rocketName)?.Click();
            ViewCartButton?.Click();
            WaitForPageToLoad(); // Cart page should now be loaded
        }

        public override void WaitForPageToLoad()
        {
             // AddToCartFalcon9.toex
            // TODO:  ToExists
            ////AddToCartFalcon9.ToExists().WaitToBe();
            ////BrowserService.WaitUntilPageLoadsCompletely();
        }
    }
}
