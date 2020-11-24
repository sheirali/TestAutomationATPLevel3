using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.Configuration;

namespace Unicorn.Web.Services
{
    public partial class WebCoreDriver : IDriver
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _webDriverWait;

        public WebCoreDriver()
        {
            // TODO:  had to add this parameter-less constructo so that  WebApp(){ServiceContainer.Resolve<WebCoreDriver>()} works
            // but then _driver is null :-(
        }

        public WebCoreDriver(IWebDriver wrappedDriver)
        {
            _driver = wrappedDriver;
            var timeoutSettings = ConfigurationService.GetSection<WebSettings>().TimeoutSettings;
            _webDriverWait = new WebDriverWait(wrappedDriver, TimeSpan.FromSeconds(timeoutSettings.WaitForAjaxTimeout));
        }

        protected IWebDriver Driver => _driver;
    }
}
