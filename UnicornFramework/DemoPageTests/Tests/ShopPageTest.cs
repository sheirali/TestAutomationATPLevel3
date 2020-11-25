using DemoPageTests.Pages;
using DemoPageTests.Utils;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DemoPageTests.Tests
{
    ////[TestClass]
    public class ShopPageTest
    {
        ////private IWebDriver _driver;
        //////need to wait
        ////private WebDriverWait _waiter;

        ////[TestInitialize]
        ////public void TestInit()
        ////{
        ////    var driverOptions = new ChromeOptions();

        ////    _driver = new ChromeDriver(driverOptions);
        ////    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

        ////    _waiter = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
        ////}

        ////[TestCleanup]
        ////public void TestCleanup()
        ////{
        ////    _driver?.Quit();
        ////}

        ////[TestMethod]
        ////[TestCategory("ShopPage")]
        ////public void ShopPageModel()
        ////{
        ////    ShopPage page = new ShopPage(_driver);
        ////    page.AddFalcon9RocetToCart();
        ////}

        ////[TestMethod]
        ////[TestCategory("Json")]
        ////public void CreateObjectFromJson()
        ////{
        ////    string exeLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
        ////    Debug.WriteLine(exeLocation);
        ////    string exeFolder = System.IO.Path.GetDirectoryName(exeLocation);
        ////    Debug.WriteLine(exeFolder);
        ////    string pathToJson = System.IO.Path.Combine(exeFolder, @"Tests\BillingUserInfo.json");
        ////    Debug.WriteLine(pathToJson);

        ////    var config = new ConfigurationBuilder()
        ////        .AddJsonFile(pathToJson, optional: false, reloadOnChange: true)
        ////        .Build();
        ////    Assert.IsNotNull(config);

        ////    var billing = config.GetSection("billingDetailItem").Get<BillingDetailItem>();
        ////    Assert.IsNotNull(billing);

        ////    Assert.AreEqual<string>("Fred", billing.FirstName);
        ////}

        ////[TestMethod]
        ////[TestCategory("Workflow")]
        ////public void SingleWorkflow()
        ////{
        ////    PurchaseWorkflow flow = new PurchaseWorkflow(_driver);
        ////    flow.PurchaseRocket("Falcon 9", 3, "happybirthday");
        ////}

        ////[DataTestMethod]
        ////[TestCategory("Workflow")]
        ////[DataRow("Falcon 9", 3, "happybirthday")]
        ////[DataRow("Proton Rocket", 2)]
        ////[DataRow("Proton Rocket", 3)]
        ////[DataRow("Saturn V", 4, "happybirthday")]
        ////[DataRow("Saturn V", 5, "happybirthday")]
        ////////[DataRow("Falcon Heavy", 1)]
        ////public void RepeatedWorkflow(string rocketName, int quantity, string coupon = null)
        ////{
        ////    PurchaseWorkflow flow = new PurchaseWorkflow(_driver);
        ////    flow.PurchaseRocket(rocketName, quantity, coupon);
        ////}

        ////[DataTestMethod]
        ////[TestCategory("ShopPage")]
        ////[DataRow("Falcon 9", 3, "happybirthday")]
        ////[DataRow("Proton Rocket", 2)]
        //////[DataRow("Proton-M", 3)]
        ////[DataRow("Saturn V", 4, "happybirthday")]
        ////[DataRow("Falcon Heavy", 5)]
        ////public void BuyRocket(string rocketName, int quantity, string coupon = null)
        ////{
        ////    Assert.IsNotNull(rocketName);
        ////    Assert.AreNotEqual<int>(0, quantity);

        ////    ShopPage page = new ShopPage(_driver);
        ////    page.PurchaseRocket(rocketName);
        ////}
    }
}
