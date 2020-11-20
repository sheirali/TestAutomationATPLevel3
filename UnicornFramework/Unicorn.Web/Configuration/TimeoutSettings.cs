using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.Configuration
{
    public class TimeoutSettings
    {
        // comes from service from parsing the testFrameworkSettings.$(Configuration).json
        public int WaitForAjaxTimeout { get; set; } = 30;
        public int SleepInterval { get; set; } = 1;
        public int ElementToBeVisibleTimeout { get; set; } = 30;
        public int ElementToExistTimeout { get; set; } = 30;
        public int ElementToNotExistTimeout { get; set; } = 30;
        public int ElementToBeClickableTimeout { get; set; } = 30;
        public int ElementNotToBeVisibleTimeout { get; set; } = 30;
        public int ElementToHaveContentTimeout { get; set; } = 15;
    }
}
