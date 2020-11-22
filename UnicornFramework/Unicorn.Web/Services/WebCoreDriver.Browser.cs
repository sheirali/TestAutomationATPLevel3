using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.Services
{
    public partial class WebCoreDriver : IBrowserService
    {
        public void Quit()
        {
            _driver?.Quit();
        }

        public void Start(Browser browser)
        {
            // TODO: implement Start gutz
            switch (browser)
            {
                case Browser.Chrome:
                    // _driver = new ChromeDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Firefox:
                    // _webDriver = new FirefoxDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Edge:
                    // _webDriver = new EdgeDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Opera:
                    // _webDriver = new OperaDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Safari:
                    // _webDriver = new SafariDriver(Environment.CurrentDirectory);
                    break;
                case Browser.InternetExplorer:
                    // _webDriver = new InternetExplorerDriver(Environment.CurrentDirectory);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
                    break;
            }

            // _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            // _elementFinderService = new ElementFinderService(_webDriver, _webDriver);
        }

        public void WaitForAjax()
        {
            var js = (IJavaScriptService)_driver;
            _webDriverWait.Until(wd => js.Execute("return jQuery.active").ToString() == "0");
        }

        public void WaitUntilPageLoadsCompletely()
        {
            var js = (IJavaScriptService)_driver;
            _webDriverWait.Until(wd => js.Execute("return document.readyState").ToString() == "complete");
        }
    }
}
