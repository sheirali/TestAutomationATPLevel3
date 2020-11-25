using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Unicorn.Web;
using Unicorn.Web.FindStrategies;

namespace Unicorn.Web.Services
{
    public partial class LoggingDriverDecorator : BaseDriverDecorator
    {
        public LoggingDriverDecorator(IDriver driver)
            : base(driver)
        {
        }

        public List<TElement> CreateAllById<TElement>(string id)
            where TElement : Element
        {
            Console.WriteLine($"CreateAllById({id})");

            return Driver?.CreateAllById<TElement>(id);
        }

        public TElement Create<TElement>(FindStrategy findStrategy)
            where TElement : Element
        {
            Console.WriteLine($"Create({findStrategy})");

            return Driver?.Create<TElement>(findStrategy);
        }

        public Uri Url
        {
            get
            {
                Console.WriteLine($"Get Url:  {Driver?.Url}");
                return Driver?.Url;
            }
        }

        public ReadOnlyCollection<Cookie> AllCookies
        {
            get
            {
                Console.WriteLine($"Get AllCookies:  {Driver?.AllCookies}");
                return Driver?.AllCookies;
            }
        }

        public void AddCookie(Cookie cookie)
        {
            Console.WriteLine($"AddCookie({cookie})");
            Driver?.AddCookie(cookie);
        }

        public void DeleteAllCookies()
        {
            Console.WriteLine($"DeleteAllCookies()");
            Driver?.DeleteAllCookies();
        }

        public void DeleteCookie(Cookie cookie)
        {
            Console.WriteLine($"DeleteCookie({cookie})");
            Driver?.DeleteCookie(cookie);
        }

        public object Execute(string script)
        {
            Console.WriteLine($"Execute({script})");
            return Driver?.Execute(script);
        }

        public void GoToUrl(string url)
        {
            Console.WriteLine($"GoToUrl({url})");
            Driver?.GoToUrl(url);
        }

        public void Handle()
        {
            Console.WriteLine($"Handle()");
            Driver?.Handle();
        }

        public void WaitForAjax()
        {
            Console.WriteLine($"WaitForAjax()");
            Driver?.WaitForAjax();
        }

        public void WaitUntilPageLoadsCompletely()
        {
            Console.WriteLine($"WaitUntilPageLoadsCompletely()");
            Driver?.WaitUntilPageLoadsCompletely();
        }
    }
}