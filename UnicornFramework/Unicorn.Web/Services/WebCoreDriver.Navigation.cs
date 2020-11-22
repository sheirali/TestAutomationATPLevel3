using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.Services
{
    public partial class WebCoreDriver : INavigationService
    {
        public Uri Url => new Uri(_driver.Url);

        public void GoToUrl(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }
    }
}
