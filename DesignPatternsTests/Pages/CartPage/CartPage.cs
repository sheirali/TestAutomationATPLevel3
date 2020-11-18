using DesignPatternsTests.Pages.Sections;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPatternsTests.Pages
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

        //input-text qty text
        private IWebElement QuantityText => FindElement(By.CssSelector("[class*='input-text qty text']"));

        //name="update_cart"
        private IWebElement UpdateCartButton => FindClickableElement(By.Name("update_cart"));

        private IWebElement CouponCodeText => FindElement(By.Id("coupon_code"));
        private IWebElement ApplyCouponButton => FindClickableElement(By.Name("apply_coupon"));

        //total woocommerce-Price-amount amount
        //  //*[@id="post-6"]/div/div/div[2]/div/table/tbody/tr[4]/td/strong/span/bdi/text()
        private IWebElement TotalText => FindElement(By.XPath("//span[@class='woocommerce-Price-amount amount']/bdi[last()]"));

        //checkout-button button alt wc-forward
        private IWebElement ProceedToCheckoutButton => FindClickableElement(By.XPath("//a[@class='checkout-button button alt wc-forward']"));


        public void Quantity(int amount)
        {
            Debug.WriteLine($"CartPage.Quantity({amount})");

            this.QuantityText.Clear();
            this.QuantityText.SendKeys(amount.ToString());
        }

        public void UpdateCart()
        {
            Debug.WriteLine("CartPage.UpdateCart()");

            this.UpdateCartButton?.Click();
            
            WaitForAjax();
        }

        public void ApplyCoupon(string coupon)
        {
            Debug.WriteLine($"CartPage.ApplyCoupon({coupon})");

            if (string.IsNullOrEmpty(coupon))
            {
                return;
            }

            this.CouponCodeText.Clear();
            this.CouponCodeText.SendKeys(coupon);

            this.ApplyCouponButton?.Click();

            //wait
            WaitForAjax();
        }

        public string GetTotal => this.TotalText.Text;

        public void ProceedToCheckout()
        {
            Debug.WriteLine("CartPage.UpdateCart()");

            this.ProceedToCheckoutButton?.Click();

            this.WaitUntilPageLoadsCompletely();//Checkout page should now be loaded
        }
    }
}
