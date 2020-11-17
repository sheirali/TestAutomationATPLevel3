using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests.Pages.Sections
{
    public abstract class BaseSection
    {
        protected IWebDriver Driver;
        protected WebDriverWait DriverWait;

        public BaseSection(IWebDriver driver)
        {
            Driver = driver;
            // wait 30 seconds.
            DriverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        }

        public IWebElement FindElement(By by)
        {
            IWebElement el = DriverWait.Until(ExpectedConditions.ElementExists(by));
            return el;
        }
    }
}
