using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Unicorn.Web.Services
{
    public partial class WebCoreDriver : ICookieService
    {
        public ReadOnlyCollection<Cookie> AllCookies => _driver.Manage().Cookies.AllCookies;

        public void AddCookie(Cookie cookie)
        {
            _driver.Manage().Cookies.AddCookie(cookie);
        }

        public void DeleteAllCookies()
        {
            _driver.Manage().Cookies.DeleteAllCookies();
        }

        public void DeleteCookie(Cookie cookie)
        {
            _driver.Manage().Cookies.DeleteCookie(cookie);
        }
    }
}
