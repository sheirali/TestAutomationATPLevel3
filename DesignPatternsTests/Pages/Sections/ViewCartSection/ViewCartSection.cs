using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests.Pages.Sections.ViewCartSection
{
    public partial class ViewCartSection : BaseSection
    {
        public ViewCartSection(IWebDriver driver) :
                base(driver)
        {
        }
    }
}
