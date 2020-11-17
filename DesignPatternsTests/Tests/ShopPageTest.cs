using DesignPatternsTests.Pages.ShopPage;
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
    [TestClass]
    public class ShopPageTest
    {
        private IWebDriver _driver;
        //need to wait
        private WebDriverWait _waiter;


        [TestInitialize]
        public void TestInit()
        {
            var driverOptions = new ChromeOptions();

            _driver = new ChromeDriver(driverOptions);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            _waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));            
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _driver?.Quit();
        }


        [TestMethod]
        [TestCategory("ShopPage")]
        public void ShopPageModel()
        {
            ShopPage page = new ShopPage(_driver);
            page.AddFalcon9RocetToCart();
        }

    }
}
