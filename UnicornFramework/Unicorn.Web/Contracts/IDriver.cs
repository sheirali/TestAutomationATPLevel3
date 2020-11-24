using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web
{
    public interface IDriver : INavigationService, ICookieService, IDialogService, IBrowserService, IElementCreateService, IJavaScriptService
    {
    }
}
