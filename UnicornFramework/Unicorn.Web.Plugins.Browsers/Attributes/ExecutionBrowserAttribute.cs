using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web;
using Unicorn.Web.Model;

namespace Unicorn.Web.Plugins.Browser
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ExecutionBrowserAttribute : Attribute
    {
        public ExecutionBrowserAttribute(BrowserConfiguration browserConfiguration)
        {
            BrowserConfiguration = browserConfiguration;
        }

        public ExecutionBrowserAttribute(Web.Browser browser, BrowserBehavior browserBehavior)
        {
            BrowserConfiguration = new BrowserConfiguration(browser, browserBehavior);
            ////BrowserConfiguration.Browser = browser;
            ////BrowserConfiguration.BrowserBehavior = browserBehavior;
        }

        public BrowserConfiguration BrowserConfiguration { get; set; }
    }
}
