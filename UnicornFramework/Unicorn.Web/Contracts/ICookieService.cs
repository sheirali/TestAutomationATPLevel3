using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Unicorn.Web
{
    public interface ICookieService
    {
        void DeleteAllCookies();

        void DeleteCookie(Cookie cookie);

        void AddCookie(Cookie cookie);

        ReadOnlyCollection<Cookie> AllCookies { get; }

        void AddCookie(string cookieName, string cookieValue);

        Cookie GetCookie(string cookieName);
    }
}
