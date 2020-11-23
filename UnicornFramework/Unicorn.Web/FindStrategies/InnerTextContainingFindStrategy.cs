using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.FindStrategies
{
    public class InnerTextContainingFindStrategy : FindStrategy
    {
        public InnerTextContainingFindStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.XPath($"//*[contains(text(), '{Value}')]");
    }
}
