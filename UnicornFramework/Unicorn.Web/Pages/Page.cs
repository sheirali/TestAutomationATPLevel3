using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.Pages
{
    public abstract class Page
    {
        public Page()
        {
            var driver = ServiceContainer.Resolve<IDriver>();
            ElementCreateService = driver;
            BrowserService = driver;
        }

        public IElementCreateService ElementCreateService { get; set; }
        public IBrowserService BrowserService { get; set; }
    }
}
