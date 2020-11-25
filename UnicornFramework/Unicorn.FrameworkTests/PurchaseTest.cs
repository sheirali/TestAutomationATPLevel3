using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Unicorn.Web;
using Unicorn.Web.Plugins.Browser;

namespace Unicorn.FrameworkTests
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
        public void CreateTestPurchase()
        {
            App.NavigationService.GoToUrl("http://demos.bellatrix.solutions/");
            ////Button button = App.ElementCreateService.CreateById<Button>("myID").ToExists().ToBeClickable();
            Assert.Pass();
        }
    }
}