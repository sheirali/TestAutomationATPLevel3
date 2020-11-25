using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn;
using Unicorn.Web.Pages;
using Unicorn.Web.Services;

namespace Unicorn.Web
{
    public class WebApp : BaseApp
    {
        private IDriver _driver;

        public WebApp()
        {
            ////WebCoreDriver wcDriver = ServiceContainer.Resolve<WebCoreDriver>();
            ////_driver = new LoggingDriverDecorator(wcDriver);
            _driver = ServiceContainer.Resolve<IDriver>();
        }

        public IElementCreateService ElementCreateService => _driver;
        public IBrowserService BrowserService => _driver;
        public INavigationService NavigationService => _driver;
        public ICookieService CookieService => _driver;
        public IDialogService DialogService => _driver;
        public IJavaScriptService JavaScriptService => _driver;
        public IInteractionsService InteractionsService => _driver;

        public void AddBrowserOptions<TOptions>(TOptions customOptions)
            where TOptions : class
        {
            ServiceContainer.RegisterInstance<TOptions>(customOptions, Guid.NewGuid().ToString());
        }

        public TPage Create<TPage>()
            where TPage : Page
        {
            return ServiceContainer.Resolve<TPage>();
        }

        public TPage GoTo<TPage>()
            where TPage : NavigatablePage
        {
            var page = ServiceContainer.Resolve<TPage>();
            page.Open();
            return page;
        }
    }
}
