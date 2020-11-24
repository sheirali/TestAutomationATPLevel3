using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.Model;

namespace Unicorn.Web.Plugins.Browser
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class GridAttribute : ExecutionBrowserAttribute
    {
        public GridAttribute(Web.Browser browser, BrowserBehavior browserBehavior, string browserVersion, PlatformType platformType)
            : base(browser, browserBehavior)
        {
            BrowserConfiguration.ExecutionType = ExecutionType.Grid;
            BrowserVersion = browserVersion;
            PlatformType = platformType;
        }

        public string BrowserVersion { get; set; }

        public PlatformType PlatformType { get; set; }
    }
}
