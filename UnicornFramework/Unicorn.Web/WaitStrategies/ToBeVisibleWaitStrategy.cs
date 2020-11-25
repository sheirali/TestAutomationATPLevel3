using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.Configuration;

namespace Unicorn
{
    public class ToBeVisibleWaitStrategy : WaitStrategy
    {
        public ToBeVisibleWaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
            : base(timeoutIntervalInSeconds, sleepIntervalInSeconds)
        {
            int timeoutInterval = timeoutIntervalInSeconds ??
                ConfigurationService.GetSection<WebSettings>().TimeoutSettings.ElementToBeVisibleTimeout;
            TimeoutInterval = TimeSpan.FromSeconds(timeoutInterval);
        }

        public override void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by)
        {
            WaitUntil(d => IsElementVisible(searchContext, by), driver);
        }

        private bool IsElementVisible(ISearchContext searchContext, By by)
        {
            var elem = searchContext.FindElement(by);
            return elem != null && elem.Displayed;
        }

        ////public abstract void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by);
        //// waituntil(elementexists(searchcontext, by), driver);
    }
}
