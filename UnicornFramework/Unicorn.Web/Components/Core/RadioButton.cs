using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web
{
    public class RadioButton : Element
    {
        public bool IsChecked => WrappedElement.Selected;
        public string Value => WrappedElement.GetAttribute("value");

        public bool IsDisabled => !WrappedElement.Enabled;

        public void Click()
        {
            WrappedElement.Click();
        }
    }
}
