using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Unicorn;
using Unicorn.Web.FindStrategies;
using Unicorn.Web.Services;

namespace Unicorn.Web
{
    public abstract class Element : IElementCreateService
    {
        private List<WaitStrategy> _waitStrategies = new List<WaitStrategy>();
        protected IWebDriver Driver;

        public Element()
        {
            Driver = ServiceContainer.Resolve<IWebDriver>();
            _waitStrategies.Add(new ToExistsWaitStrategy());
        }

        public Element(IWebDriver driver, By by, IWebElement wrappedElement)
        {
            Driver = driver;
            By = by;
            ParentElement = wrappedElement;
            _waitStrategies.Add(new ToExistsWaitStrategy());
        }

        public Element(IWebDriver driver, By by)
        {
            Driver = driver;
            By = by;
            _waitStrategies.Add(new ToExistsWaitStrategy());
            ////WrappedElement.GetCssValue() //example call
        }

        public IWebElement WrappedElement => GetAndWaitElement();
        public IWebElement ParentElement { get; set; }

        public Size Size => WrappedElement.Size;
        public Point Location => WrappedElement.Location;

        public IWebElement WaitToBe()
        {
            return GetAndWaitElement();
        }

        private IWebElement GetAndWaitElement()
        {
            IWebElement webElement = default;
            foreach (var strategy in _waitStrategies)
            {
                if (ParentElement != null)
                {
                    strategy.WaitUntil(ParentElement, Driver, By);
                }
                else
                {
                    strategy.WaitUntil(Driver, Driver, By);
                }
            }

            if (ParentElement != null)
            {
                webElement = ParentElement.FindElement(By);
            }
            else
            {
                webElement = Driver.FindElement(By);
            }

            return webElement;
        }

        public By By { get; set; }

        public void EnsureState(WaitStrategy waitStrategy)
        {
            _waitStrategies.Add(waitStrategy);
        }

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

        public TElement CreateByName<TElement>(string controlName)
            where TElement : Element
        {
            return Create<TElement>(new NameFindStrategy(controlName));
        }

        // TODO: implement  List<TElement> CreateXXX methods, maybe List<TElement> => to custom object
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
        {
            var strategy = new ClassFindStrategy(cssClass);
            throw new NotImplementedException();
        }

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
            element.ParentElement = WrappedElement;

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
