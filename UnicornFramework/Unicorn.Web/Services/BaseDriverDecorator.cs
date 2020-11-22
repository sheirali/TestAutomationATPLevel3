using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Unicorn.Web.WaitStrategies;

namespace Unicorn.Web.Services
{
    public partial class BaseDriverDecorator : IDriver
    {
        // TODO: complete class BaseDriverDecorator
        protected readonly WebCoreDriver Driver;

        public BaseDriverDecorator(WebCoreDriver driver)
        {
            Driver = driver;
        }

        public Uri Url => Driver?.Url;

        public ReadOnlyCollection<Cookie> AllCookies => Driver?.AllCookies;

        public void AddCookie(Cookie cookie) => Driver?.AddCookie(cookie);
        public void DeleteAllCookies() => Driver?.DeleteAllCookies();
        public void DeleteCookie(Cookie cookie) => Driver?.DeleteCookie(cookie);
        public object Execute(string script) => Driver?.Execute(script);
        public void GoToUrl(string url) => Driver?.GoToUrl(url);
        public void Handle() => Driver?.Handle();
        public void Quit() => Driver?.Quit();
        public void Start(Browser browser) => Driver?.Start(browser);
        public void Wait(Element element, WaitStrategy waitStrategy) => Driver?.Wait(element, waitStrategy);
        public void WaitForAjax() => Driver?.WaitForAjax();
        public void WaitUntilPageLoadsCompletely() => Driver?.WaitUntilPageLoadsCompletely();
    }
}
