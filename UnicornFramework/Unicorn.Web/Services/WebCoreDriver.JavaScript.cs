using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.Services
{
    public partial class WebCoreDriver : IJavaScriptService
    {
        public object Execute(string script)
        {
            var js = (IJavaScriptExecutor)_driver;
            return js.ExecuteScript(script);
        }
    }
}
