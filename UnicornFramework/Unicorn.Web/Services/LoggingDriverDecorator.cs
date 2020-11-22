﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Unicorn.Web.WaitStrategies;

namespace Unicorn.Web.Services
{
    public partial class LoggingDriverDecorator : BaseDriverDecorator
    {
        // TODO: complete class LoggingDriverDecorator
        public LoggingDriverDecorator(WebCoreDriver driver)
            : base(driver)
        {
        }

        public List<Element> CreateAllById(string id)
        {
            // TODO: implement CreateAllById
            Console.WriteLine($"CreateAllById({id})");

            // base.CreateAllById(id)
            return null;
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

        public void Quit()
        {
            Console.WriteLine($"Quit()");
            Driver?.Quit();
        }

        public void Start(Browser browser)
        {
            Console.WriteLine($"Start({browser})");
            Driver?.Start(browser);
        }

        public void Wait(Element element, WaitStrategy waitStrategy)
        {
            Console.WriteLine($"Wait({element}, {waitStrategy})");
            Driver?.Wait(element, waitStrategy);
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