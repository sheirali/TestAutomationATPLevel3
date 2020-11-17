using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests.Pages.Sections.BreadcrumbSection
{
    public partial class BreadcrumbSection : BaseSection
    {
        public BreadcrumbSection(IWebDriver driver) :
                base(driver)
        {
        }
    }
}
