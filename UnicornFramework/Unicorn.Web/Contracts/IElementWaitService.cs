using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Web.WaitStrategies;

namespace Unicorn.Web
{
    public interface IElementWaitService
    {
        // TODO: complete IElementWaitService and its implementation
        void Wait(Element element, WaitStrategy waitStrategy);
    }
}
