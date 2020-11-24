using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web
{
    public class Label : Element
    {
        public string InnerText => WrappedElement.Text;
        public bool IsDisabled => !WrappedElement.Enabled;

        ////public void TypeText(string text)
        ////{
        ////    WrappedElement.Clear();
        ////    WrappedElement.SendKeys(text);
        ////}
    }
}
