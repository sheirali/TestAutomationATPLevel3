using DemoPageTests.Pages.Sections;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Unicorn.Web;
using Unicorn.Web.Pages;

namespace DemoPageTests.Pages
{
    public partial class CartPage : NavigatablePage
    {
        public CartPage()
        {
            Url = new Uri("http://demos.bellatrix.solutions/cart/");
        }

        ////public override string Url => "http://demos.bellatrix.solutions/cart/";
        ////public MenuSection MainMenu => new MenuSection(Driver);
        ////public SearchSection SearchProduct => new SearchSection(Driver);
        ////public ViewCartSection ViewCart => new ViewCartSection(Driver);
        ////public BreadcrumbSection Breadcrumb => new BreadcrumbSection(Driver);

        private TextField QuantityText => ElementCreateService.CreateByCss<TextField>("[class*='input-text qty text']");
        private TextField CouponCodeText => ElementCreateService.CreateById<TextField>("coupon_code");
        private TextField TotalText => ElementCreateService.CreateByXPath<TextField>("//span[@class='woocommerce-Price-amount amount']/bdi[last()]");

        public Button UpdateCartButton => ElementCreateService.CreateByName<Button>("update_cart");
        public Button ApplyCouponButton => ElementCreateService.CreateByName<Button>("apply_coupon");
        public Button ProceedToCheckoutButton => ElementCreateService.CreateByXPath<Button>("//a[@class='checkout-button button alt wc-forward']");

        public void Quantity(int amount)
        {
            Debug.WriteLine($"CartPage.Quantity({amount})");
            QuantityText.TypeText(amount.ToString());
        }

        public void UpdateCart()
        {
            Debug.WriteLine("CartPage.UpdateCart()");
            UpdateCartButton?.Click();
            WaitForAjax();
        }

        public void ApplyCoupon(string coupon)
        {
            Debug.WriteLine($"CartPage.ApplyCoupon({coupon})");

            if (string.IsNullOrEmpty(coupon))
            {
                return;
            }

            CouponCodeText.TypeText(coupon);

            ApplyCouponButton?.Click();

            WaitForAjax();
        }

        public string GetTotal => TotalText.InnerText;

        public override Uri Url { get; set; }

        public void ProceedToCheckout()
        {
            Debug.WriteLine("CartPage.UpdateCart()");

            ProceedToCheckoutButton?.Click();

            WaitForPageToLoad(); // Checkout page should now be loaded
        }

        public override void WaitForPageToLoad()
        {
            BrowserService.WaitUntilPageLoadsCompletely();
        }

        public void WaitForAjax()
        {
            BrowserService.WaitForAjax();
        }
    }
}
