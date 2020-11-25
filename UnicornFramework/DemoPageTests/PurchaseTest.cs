using DemoPageTests.Pages;
using DemoPageTests.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Diagnostics;
using Unicorn.Web;
using Unicorn.Web.Plugins.Browser;

namespace DemoPageTests
{
    [TestFixture]
    [ExecutionBrowser(Browser.Chrome, BrowserBehavior.RestartEveryTime)]
    public class PurchaseTest : WebTest
    {
        public override void ClassInit()
        {
            Console.WriteLine("PurchaseTest.ClassInit");

            // example of adding options
            ChromeOptions options = new ();
            options.PageLoadStrategy = PageLoadStrategy.Eager;
            App.AddBrowserOptions(options);
        }

        public override void TestInit()
        {
            Console.WriteLine("PurchaseTest.TestInit");
        }

        public override void TestCleanup()
        {
            Console.WriteLine("PurchaseTest.TestCleanup");
        }

        [Test]
        public void AppNavigationService()
        {
            App.NavigationService.GoToUrl("http://demos.bellatrix.solutions/");
            ////Button button = App.ElementCreateService.CreateById<Button>("myID").ToExists().ToBeClickable();
            Assert.Pass();
        }

        [Test]
        public void ShopPageModel()
        {
            ////ShopPage page = new ShopPage();
            ShopPage page = App.Create<ShopPage>();
            page.AddFalcon9RocetToCart();
        }

        [Test]
        public void CreateObjectFromJson()
        {
            string exeLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            Debug.WriteLine(exeLocation);
            string exeFolder = System.IO.Path.GetDirectoryName(exeLocation);
            Debug.WriteLine(exeFolder);
            string pathToJson = System.IO.Path.Combine(exeFolder, @"Tests\BillingUserInfo.json");
            Debug.WriteLine(pathToJson);

            var config = new ConfigurationBuilder()
                .AddJsonFile(pathToJson, optional: false, reloadOnChange: true)
                .Build();
            Assert.IsNotNull(config);

            var billing = config.GetSection("billingDetailItem").Get<BillingDetailItem>();
            Assert.IsNotNull(billing);

            Assert.AreEqual("Fred", billing.FirstName);
        }
    }
}