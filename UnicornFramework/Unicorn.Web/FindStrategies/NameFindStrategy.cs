using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.FindStrategies
{
    public class NameFindStrategy : FindStrategy
    {
        public NameFindStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.Name(Value);
    }
}
