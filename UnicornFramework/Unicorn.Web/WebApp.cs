using System;
using System.Collections.Generic;
using System.Text;
using Unicorn;
using Unicorn.Web.Services;

namespace Unicorn.Web
{
    public class WebApp : BaseApp
    {
        private IDriver _driver;

        public WebApp()
        {
            var webCoreDriver = ServiceContainer.Resolve<WebCoreDriver>();
            _driver = new LoggingDriverDecorator(webCoreDriver);
        }

        public IElementCreateService ElementCreateService => _driver;
        public IBrowserService BrowserService => _driver;
        public INavigationService NavigationService => _driver;
        public ICookieService CookieService => _driver;
        public IDialogService DialogService => _driver;
        public IJavaScriptService JavaScriptService => _driver;
        public IInteractionsService InteractionsService => _driver;

        public void AddBrowserOptions<TOptions>()
            where TOptions : class
        {
        }

        public TPage Create<TPage>()
            where TPage : class
        {
            return default;
        }

        public TPage GoTo<TPage>()
            where TPage : class
        {
            return default;
        }
    }
}
