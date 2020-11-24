using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.Configuration
{
    // TODO: complete BrowserSettings
    public class WebSettings
    {
        public TimeoutSettings TimeoutSettings { get; set; }
        public BrowserSettings Chrome { get; set; }
        public BrowserSettings FireFox { get; set; }
        public BrowserSettings Edge { get; set; }

        public BrowserSettings Safari { get; set; }
    }
}
