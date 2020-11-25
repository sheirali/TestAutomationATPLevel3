using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Unicorn.Plugins;
using Unicorn.Web.Plugins.Browser;
using Unicorn.Web.Services;

namespace Unicorn.FrameworkTests
{
    [SetUpFixture]
    public class TestInitialize
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            ServiceContainer.RegisterType<BaseTestExectionPluginObserver, BrowserLaunchPluginObserver>(Guid.NewGuid().ToString());
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
            var driverFactory = ServiceContainer.Resolve<DriverFactory>();
            driverFactory.Dispose();
        }
    }
}
