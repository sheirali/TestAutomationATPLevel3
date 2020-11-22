using System;
using System.Collections.Generic;
using System.Text;

namespace Unicorn.Plugins
{
    public interface ITestExectionSubject
    {
        void Attach(ITestExectionPluginObserver observer);
        void DeAttach(ITestExectionPluginObserver observer);

        // void DeAttach(ITestExectionPluginObserver observer);
        // void DeAttach(ITestExectionPluginObserver observer);
        // void DeAttach(ITestExectionPluginObserver observer);
    }
}
