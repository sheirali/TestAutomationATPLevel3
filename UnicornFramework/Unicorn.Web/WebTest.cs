using System;
using Unicorn.NUnit;

namespace Unicorn.Web
{
    public class WebTest : BaseTest
    {
        public WebTest()
        {
            App = ServiceContainer.Resolve<WebApp>();
        }

        public WebApp App { get; private set; }

        ////public WebApp App => new WebApp();
    }
}
