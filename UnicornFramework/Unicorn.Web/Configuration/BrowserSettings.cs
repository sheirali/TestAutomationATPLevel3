using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.Configuration
{
    // TODO: complete BrowserSettings + its Json
    public class BrowserSettings
    {
        ////from json file
        public int PageLoadTimeout { get; set; } = 20;
        public int ScriptTimeout { get; set; } = 30;
    }
}
