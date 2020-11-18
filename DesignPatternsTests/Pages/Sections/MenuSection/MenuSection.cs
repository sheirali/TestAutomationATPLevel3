using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests.Pages.Sections
{
    public partial class MenuSection : BaseSection
    {
        public MenuSection(IWebDriver driver) :
                base(driver)
        {
        }

        public IWebElement Home => FindElement(By.XPath("//a[contains(text(), 'Home')][1]"));

        public IWebElement Blog => FindElement(By.XPath("//a[contains(text(), 'Blog')][1]"));

        public IWebElement Cart => FindElement(By.XPath("//a[contains(text(), 'Cart')][1]"));
        public IWebElement Checkout => FindElement(By.XPath("//a[contains(text(), 'Checkout')][1]"));
        public IWebElement MyAccount => FindElement(By.XPath("//a[contains(text(), 'My account')][1]"));
        public IWebElement Promotions => FindElement(By.XPath("//a[contains(text(), 'Promotions')][1]"));
    }
}
