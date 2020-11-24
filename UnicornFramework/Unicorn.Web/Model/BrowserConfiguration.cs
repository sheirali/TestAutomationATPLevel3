﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.Model
{
    public class BrowserConfiguration
    {
        public BrowserConfiguration(Browser browser, BrowserBehavior browserBehavior)
        {
            Browser = browser;
            BrowserBehavior = browserBehavior;
            ExecutionType = ExecutionType.Regular;
        }

        public Browser Browser { get; set; }

        public BrowserBehavior BrowserBehavior { get; set; }

        public ExecutionType ExecutionType { get; set; }
    }
}
