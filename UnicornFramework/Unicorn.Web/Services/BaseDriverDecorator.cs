using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Unicorn.Web.FindStrategies;
using Unicorn.Web.WaitStrategies;

namespace Unicorn.Web.Services
{
    public partial class BaseDriverDecorator : IDriver
    {
        protected readonly IDriver Driver;

        public BaseDriverDecorator(IDriver driver)
        {
            Driver = driver;
        }

        public Uri Url => Driver?.Url;

        public ReadOnlyCollection<Cookie> AllCookies => Driver?.AllCookies;

        public void AddCookie(Cookie cookie) => Driver?.AddCookie(cookie);

        public Element Create(FindStrategy findStrategy) => Driver?.Create(findStrategy);

        public List<Element> CreateAll(FindStrategy findStrategy)
        {
            return Driver?.CreateAll(findStrategy);
        }

        public List<Element> CreateAllByClass(string cssClass)
        {
            return Driver?.CreateAllByClass(cssClass);
        }

        public List<Element> CreateAllByCss(string css)
        {
            return Driver?.CreateAllByCss(css);
        }

        public List<Element> CreateAllById(string id)
        {
            return Driver?.CreateAllById(id);
        }

        public List<Element> CreateAllByLinkText(string linkText)
        {
            return Driver?.CreateAllByLinkText(linkText);
        }

        public List<Element> CreateAllByTag(string tag)
        {
            return Driver?.CreateAllByTag(tag);
        }

        public List<Element> CreateAllByXPath(string xpath)
        {
            return Driver?.CreateAllByXPath(xpath);
        }

        public Element CreateByClass(string cssClass)
        {
            return Driver?.CreateByClass(cssClass);
        }

        public Element CreateByCss(string css)
        {
            return Driver?.CreateByCss(css);
        }

        public Element CreateById(string id)
        {
            return Driver?.CreateById(id);
        }

        public Element CreateByLinkText(string linkText)
        {
            return Driver?.CreateByLinkText(linkText);
        }

        public Element CreateByTag(string tag)
        {
            return Driver?.CreateByTag(tag);
        }

        public Element CreateByXPath(string xpath)
        {
            return Driver?.CreateByXPath(xpath);
        }

        public void DeleteAllCookies() => Driver?.DeleteAllCookies();
        public void DeleteCookie(Cookie cookie) => Driver?.DeleteCookie(cookie);
        public object Execute(string script) => Driver?.Execute(script);
        public void GoToUrl(string url) => Driver?.GoToUrl(url);
        public void Handle() => Driver?.Handle();
        public void Handle(Action<IAlert> action = null, DialogButton dialogButton = DialogButton.Ok) => throw new NotImplementedException();

        ////public void Quit() => Driver?.Quit();
        ////public void Start(Browser browser) => Driver?.Start(browser);
        public void Wait(Element element, WaitStrategy waitStrategy) => Driver?.Wait(element, waitStrategy);
        public void WaitForAjax() => Driver?.WaitForAjax();
        public void WaitUntilPageLoadsCompletely() => Driver?.WaitUntilPageLoadsCompletely();
    }
}
