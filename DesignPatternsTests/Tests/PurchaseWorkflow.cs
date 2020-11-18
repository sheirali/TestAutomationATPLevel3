using DesignPatternsTests.Pages;
using DesignPatternsTests.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DesignPatternsTests.Tests
{
    public class PurchaseWorkflow
    {
        private readonly IWebDriver _driver;
        private ShopPage _shopPage;
        private CartPage _cartPage;
        private CheckoutPage _checkoutPage;

        private BillingDetailItem _billinInfo; //just one for testing

        public PurchaseWorkflow(IWebDriver driver)
        {
            _driver = driver;
            _shopPage = new ShopPage(driver);
            _cartPage = new CartPage(driver);
            _checkoutPage = new CheckoutPage(driver);

            CreateBillingInfo();
        }

        private void CreateBillingInfo()
        {
            string exeLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string exeFolder = System.IO.Path.GetDirectoryName(exeLocation);
            string pathToJson = System.IO.Path.Combine(exeFolder, @"Tests\BillingUserInfo.json");

            var config = new ConfigurationBuilder()
                .AddJsonFile(pathToJson, optional: false, reloadOnChange: true)
                .Build();
            Assert.IsNotNull(config);

            _billinInfo = config.GetSection("billingDetailItem").Get<BillingDetailItem>();
        }

        public void PurchaseRocket(string rocketName, int quantity, string coupon = null)
        {
            _shopPage.PurchaseRocket(rocketName);
            
            //on the Cart page
            _cartPage.Quantity(quantity);
            _cartPage.UpdateCart();
            _cartPage.ApplyCoupon(coupon);


            //could do an assert here on total??
            string total = _cartPage.GetTotal;
            Debug.WriteLine($"cart.GetTotal={total}");  //50.00€

            //click the checkout
            _cartPage.ProceedToCheckout();


            //on the Checkout page                       
            _checkoutPage.PopulateBillingInfo(_billinInfo);

            //could do an assert here on total??
            total = _checkoutPage.GetTotal;
            Debug.WriteLine($"checkoutPage.GetTotal={total}");  //150.00€

            _checkoutPage.PlaceOrder();
        }
    }
}
