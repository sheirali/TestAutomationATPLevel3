using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Web.Services
{
    public partial class WebCoreDriver : IDialogService
    {
        public void Handle(Action<IAlert> action = null, DialogButton dialogButton = DialogButton.Ok)
        {
            var alert = _driver.SwitchTo().Alert();
            action?.Invoke(alert);

            ////dialogButton == DialogButton.Ok ? alert.Accept() : alert.Dismiss();

            if (dialogButton == DialogButton.Ok)
            {
                alert.Accept();
            }
            else
            {
                alert.Dismiss();
            }

            _driver.SwitchTo().DefaultContent();
        }
    }
}
