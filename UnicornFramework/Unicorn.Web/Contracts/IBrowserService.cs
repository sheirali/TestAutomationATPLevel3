using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web
{
    public interface IBrowserService
    {
        void WaitForAjax();

        void WaitUntilPageLoadsCompletely();

        // TODO:  we will put them in the DriverFactory class.
        ////void Start(Browser browser);

        ////void Quit();
    }
}
