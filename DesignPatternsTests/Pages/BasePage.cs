using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace DesignPatternsTests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait DriverWait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            // wait 30 seconds.
            DriverWait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        }

        public virtual string Url => string.Empty;

        public virtual void Open(string part = "")
        {
            if (string.IsNullOrEmpty(Url))
            {
                throw new ArgumentException("The main URL cannot be null or empty.");
            }

            Driver.Navigate().GoToUrl(string.Concat(Url, part));

            //maximize
            Driver.Manage().Window.Maximize();

            //wait till page completely loads??
            this.WaitUntilPageLoadsCompletely();
        }

        public IWebElement FindElement(By by)
        {
            IWebElement el = DriverWait.Until(ExpectedConditions.ElementExists(by));
            return el;
        }

        public IWebElement FindClickableElement(By by)
        {
            IWebElement el = DriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
            return el;
        }

        public void WaitForAjax()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            DriverWait.Until(wd => jse.ExecuteScript("return jQuery.active").ToString() == "0");
        }

        public void WaitUntilPageLoadsCompletely()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)Driver;
            DriverWait.Until(wd => jse.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}