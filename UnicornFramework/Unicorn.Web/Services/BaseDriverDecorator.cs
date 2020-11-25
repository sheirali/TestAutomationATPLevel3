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
        public void AddCookie(string cookieName, string cookieValue) => Driver?.AddCookie(cookieName, cookieValue);

        public TElement Create<TElement>(FindStrategy findStrategy)
            where TElement : Element
            => Driver?.Create<TElement>(findStrategy);
        public List<TElement> CreateAll<TElement>(FindStrategy findStrategy)
            where TElement : Element
            => Driver?.CreateAll<TElement>(findStrategy);
        public List<TElement> CreateAllByClass<TElement>(string cssClass)
            where TElement : Element
            => Driver?.CreateAllByClass<TElement>(cssClass);
        public List<TElement> CreateAllByCss<TElement>(string css)
            where TElement : Element
            => Driver?.CreateAllByCss<TElement>(css);
        public List<TElement> CreateAllById<TElement>(string id)
            where TElement : Element
            => Driver?.CreateAllById<TElement>(id);
        public List<TElement> CreateAllByLinkText<TElement>(string linkText)
            where TElement : Element
            => Driver?.CreateAllByLinkText<TElement>(linkText);
        public List<TElement> CreateAllByTag<TElement>(string tag)
            where TElement : Element
            => Driver?.CreateAllByTag<TElement>(tag);
        public List<TElement> CreateAllByXPath<TElement>(string xpath)
            where TElement : Element
            => Driver?.CreateAllByXPath<TElement>(xpath);
        public TElement CreateByClass<TElement>(string cssClass)
            where TElement : Element
            => Driver?.CreateByClass<TElement>(cssClass);
        public TElement CreateByCss<TElement>(string css)
            where TElement : Element
            => Driver?.CreateByCss<TElement>(css);
        public TElement CreateById<TElement>(string id)
            where TElement : Element
            => Driver?.CreateById<TElement>(id);
        public TElement CreateByLinkText<TElement>(string linkText)
            where TElement : Element
            => Driver?.CreateByLinkText<TElement>(linkText);
        public TElement CreateByName<TElement>(string controlName)
            where TElement : Element => Driver?.CreateByName<TElement>(controlName);
        public TElement CreateByTag<TElement>(string tag)
            where TElement : Element
            => Driver?.CreateByTag<TElement>(tag);
        public TElement CreateByXPath<TElement>(string xpath)
            where TElement : Element
            => Driver?.CreateByXPath<TElement>(xpath);

        public void DeleteAllCookies() => Driver?.DeleteAllCookies();
        public void DeleteCookie(Cookie cookie) => Driver?.DeleteCookie(cookie);
        public IInteractionsService DoubleClick(Element element) => throw new NotImplementedException();
        public IInteractionsService DragAndDrop(Element sourceElement, Element destinationElement) => throw new NotImplementedException();
        public object Execute(string script) => Driver?.Execute(script);
        public Cookie GetCookie(string cookieName) => throw new NotImplementedException();
        public void GoToUrl(string url) => Driver?.GoToUrl(url);
        public void Handle() => Driver?.Handle();
        public void Handle(Action<IAlert> action = null, DialogButton dialogButton = DialogButton.Ok) => throw new NotImplementedException();
        public IInteractionsService MoveToElement(Element element) => throw new NotImplementedException();
        public void Perform() => throw new NotImplementedException();
        public IInteractionsService Release() => throw new NotImplementedException();

        ////public void Quit() => Driver?.Quit();
        ////public void Start(Browser browser) => Driver?.Start(browser);
        ////public void Wait(Element element, WaitStrategy waitStrategy) => Driver?.Wait(element, waitStrategy);
        public void WaitForAjax() => Driver?.WaitForAjax();
        public void WaitUntilPageLoadsCompletely() => Driver?.WaitUntilPageLoadsCompletely();
    }
}
