using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests.Pages.Sections
{
    public partial class BreadcrumbSection : BaseSection
    {
        public BreadcrumbSection(IWebDriver driver) :
                base(driver)
        {
        }
    }
}
