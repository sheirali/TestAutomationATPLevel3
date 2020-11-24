using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.Configuration;

namespace Unicorn.Web.WaitStrategies
{
    public class ToBeClickableWaitStrategy : WaitStrategy
    {
        public ToBeClickableWaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
            : base(timeoutIntervalInSeconds, sleepIntervalInSeconds)
        {
            int timeoutInterval = timeoutIntervalInSeconds ??
                ConfigurationService.GetSection<WebSettings>().TimeoutSettings.ElementToBeClickableTimeout;
            TimeoutInterval = TimeSpan.FromSeconds(timeoutInterval);
        }

        public override void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by)
        {
            WaitUntil(d => IsElementClickable(searchContext, by), driver);
        }

        private bool IsElementClickable(ISearchContext searchContext, By by)
        {
            var elem = searchContext.FindElement(by);
            return elem != null && elem.Enabled;
        }

        ////public abstract void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by);
        //// waituntil(elementexists(searchcontext, by), driver);
    }
}
