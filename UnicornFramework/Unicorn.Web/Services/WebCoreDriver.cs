using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.Configuration;

namespace Unicorn.Web.Services
{
    public partial class WebCoreDriver
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _webDriverWait;

        protected WebCoreDriver(IWebDriver wrappedDriver)
        {
            _driver = wrappedDriver;
            var timeoutSettings = ConfigurationService.GetSection<TimeoutSettings>();
            _webDriverWait = new WebDriverWait(wrappedDriver, TimeSpan.FromSeconds(timeoutSettings.WaitForAjaxTimeout));
        }

        protected IWebDriver Driver => _driver;
    }
}
