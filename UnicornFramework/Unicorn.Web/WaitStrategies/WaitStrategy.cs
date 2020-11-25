using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.Configuration;

namespace Unicorn
{
    public abstract class WaitStrategy
    {
        private int _DEFAULT_TIMEOUT = 30;
        protected WaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
        {
            ////int timeoutInterval = timeoutIntervalInSeconds ??
            ////    ConfigurationService.GetSection<TimeoutSettings>().ElementToExistTimeout;
            ////TimeoutInterval = TimeSpan.FromSeconds(timeoutInterval);

            TimeoutInterval = TimeSpan.FromSeconds(timeoutIntervalInSeconds ?? _DEFAULT_TIMEOUT);
            SleepInterval = TimeSpan.FromSeconds(sleepIntervalInSeconds ?? 2);
        }

        protected TimeSpan TimeoutInterval { get; set; }
        protected TimeSpan SleepInterval { get; set; }

        public abstract void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by);
        //// waituntil(elementexists(searchcontext, by), driver);

        protected void WaitUntil(Func<ISearchContext, bool> waitCondition, IWebDriver driver)
        {
            var webDriverWait = new WebDriverWait(new SystemClock(), driver, TimeoutInterval, SleepInterval);
            webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            webDriverWait.Until(waitCondition);
        }
    }
}
