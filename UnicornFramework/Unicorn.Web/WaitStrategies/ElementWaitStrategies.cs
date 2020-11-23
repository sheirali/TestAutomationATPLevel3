using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web;
using Unicorn.Web.Configuration;
using Unicorn.Web.WaitStrategies;

namespace Unicorn
{
    public static class ElementWaitStrategies
    {
        public static TElement ToExists<TElement>(this TElement element,
            int? timeoutIntervalInSeconds = null,
            int? sleepIntervalInSeconds = null)
            where TElement : Element
        {
            var strategy = new ToExistsWaitStrategy(timeoutIntervalInSeconds, sleepIntervalInSeconds);
            element.EnsureState(strategy);
            return element;
        }

        public static TElement ToBeVisible<TElement>(this TElement element,
            int? timeoutIntervalInSeconds = null,
            int? sleepIntervalInSeconds = null)
            where TElement : Element
        {
            var strategy = new ToBeVisibleWaitStrategy(timeoutIntervalInSeconds, sleepIntervalInSeconds);
            element.EnsureState(strategy);
            return element;
        }

        public static TElement ToBeClickable<TElement>(this TElement element,
            int? timeoutIntervalInSeconds = null,
            int? sleepIntervalInSeconds = null)
            where TElement : Element
        {
            var strategy = new ToBeClickableWaitStrategy(timeoutIntervalInSeconds, sleepIntervalInSeconds);
            element.EnsureState(strategy);
            return element;
        }
    }
}
