using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.Configuration;

namespace Unicorn.Web.WaitStrategies
{
    public class ToExistsWaitStrategy : WaitStrategy
    {
        public ToExistsWaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
            : base(timeoutIntervalInSeconds, sleepIntervalInSeconds)
        {
            int timeoutInterval = timeoutIntervalInSeconds ??
                ConfigurationService.GetSection<TimeoutSettings>().ElementToExistTimeout;
            TimeoutInterval = TimeSpan.FromSeconds(timeoutInterval);
        }

        public override void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by)
        {
            WaitUntil(d => DoesElementExits(searchContext, by), driver);
        }

        private bool DoesElementExits(ISearchContext searchContext, By by)
        {
            return searchContext.FindElement(by) != null;
        }

        ////public abstract void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by);
        //// waituntil(elementexists(searchcontext, by), driver);
    }
}
