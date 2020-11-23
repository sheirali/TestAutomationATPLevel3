using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.WaitStrategies
{
    public abstract class WaitStrategy
    {
        // TODO: complete class WaitStrategy
        protected WaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
        {
            TimeoutInterval = TimeSpan.FromSeconds(timeoutIntervalInSeconds ?? 30);
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
