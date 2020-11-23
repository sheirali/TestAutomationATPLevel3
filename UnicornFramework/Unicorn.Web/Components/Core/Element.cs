using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.FindStrategies;

namespace Unicorn.Web
{
    public abstract class Element : IElementCreateService
    {
        protected IWebDriver Driver;

        public Element()
        {
            Driver = ServiceContainer.Resolve<IWebDriver>();
        }

        public Element(IWebDriver driver, By by, IWebElement wrappedElement)
        {
            Driver = driver;
            By = by;
            WrappedElement = wrappedElement;
        }

        public Element(IWebDriver driver, By by)
        {
            Driver = driver;
            By = by;
        }

        public IWebElement WrappedElement { get; set; }
        public By By { get; set; }

        public TElement CreateById<TElement>(string id)
            where TElement : Element
        {
            TElement elment = Create<TElement>(new IdFindStrategy(id));
            return elment;
        }

        public TElement CreateByXPath<TElement>(string xpath)
            where TElement : Element
        {
            return Create<TElement>(new XPathFindStrategy(xpath));
        }

        public TElement CreateByTag<TElement>(string tag)
            where TElement : Element
        {
            return Create<TElement>(new TagFindStrategy(tag));
        }

        public TElement CreateByClass<TElement>(string cssClass)
            where TElement : Element
        {
            return Create<TElement>(new ClassFindStrategy(cssClass));
        }

        public TElement CreateByCss<TElement>(string css)
            where TElement : Element
        {
            return Create<TElement>(new CssFindStrategy(css));
        }

        public TElement CreateByLinkText<TElement>(string linkText)
            where TElement : Element
        {
            return Create<TElement>(new LinkTextFindStrategy(linkText));
        }

        public List<TElement> CreateAllById<TElement>(string id)
            where TElement : Element
            => throw new NotImplementedException();
        public List<TElement> CreateAllByXPath<TElement>(string xpath)
            where TElement : Element
            => throw new NotImplementedException();
        public List<TElement> CreateAllByTag<TElement>(string tag)
            where TElement : Element
            => throw new NotImplementedException();
        public List<TElement> CreateAllByClass<TElement>(string cssClass)
            where TElement : Element
            => throw new NotImplementedException();
        public List<TElement> CreateAllByCss<TElement>(string css)
            where TElement : Element
            => throw new NotImplementedException();
        public List<TElement> CreateAllByLinkText<TElement>(string linkText)
            where TElement : Element
            => throw new NotImplementedException();
        public List<TElement> CreateAll<TElement>(FindStrategy findStrategy)
            where TElement : Element
            => throw new NotImplementedException();

        public TElement Create<TElement>(FindStrategy findStrategy)
            where TElement : Element
        {
            TElement element = Activator.CreateInstance<TElement>();
            element.By = findStrategy.Convert();
            element.WrappedElement = WrappedElement;

            return element;
        }
        ////public abstract string Text { get; }
        ////public abstract bool? Enabled { get; }
        ////public abstract bool? Displayed { get; }
        ////public abstract void TypeText(string text);
        ////public abstract void Click();
        ////public abstract string GetAttribute(string attributeName);
    }
}
