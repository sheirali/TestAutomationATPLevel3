using System;
using System.Collections.Generic;
using System.Text;
using Unicorn;

namespace Unicorn.Web
{
    public class WebApp : BaseApp
    {
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
