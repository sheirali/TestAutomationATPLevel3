using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web
{
    public interface IBrowserService
    {
        void WaitForAjax();

        void WaitUntilPageLoadsCompletely();

        // TODO:  does Start/Quit go here??
        void Start(Browser browser);

        void Quit();
    }
}
