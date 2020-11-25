using System;
using System.Reflection;
using Unicorn.Plugins;
using Unicorn.Web.Model;
using Unicorn.Web.Services;

namespace Unicorn.Web.Plugins.Browser
{
    public class BrowserLaunchPluginObserver : BaseTestExectionPluginObserver
    {
        private readonly DriverFactory _driverFactory;
        private BrowserConfiguration _currentBrowserConfiguration;
        private BrowserConfiguration _previousBrowserConfiguration;

        public BrowserLaunchPluginObserver(TestExectionSubject testExectionSubject)
            : base(testExectionSubject)
        {
            ////_driverFactory = new DriverFactory();
            _driverFactory = ServiceContainer.Resolve<DriverFactory>();
            ServiceContainer.RegisterInstance(_driverFactory);
        }

        public override void PreTestInit(MemberInfo memberInfo)
        {
            _currentBrowserConfiguration = GetBrowserConfiguration(memberInfo);
            bool shouldRestartBrowser = ShouldRestartBrowser(_currentBrowserConfiguration);
            if (shouldRestartBrowser)
            {
                RestartBrowser();
            }

            _previousBrowserConfiguration = _currentBrowserConfiguration;
        }

        private void RestartBrowser()
        {
            _driverFactory.Dispose();
            _driverFactory.Start(_currentBrowserConfiguration);

            // TODO:; resolve WebCoreDriver
            ////WebCoreDriver wcDriver = ServiceContainer.Resolve<WebCoreDriver>();
            ////_driver = new LoggingDriverDecorator(wcDriver);
        }

        private bool ShouldRestartBrowser(BrowserConfiguration browserConfiguration)
        {
            if (_previousBrowserConfiguration == null)
            {
                return true;
            }

            bool shouldRestartBrowser = browserConfiguration.BrowserBehavior == BrowserBehavior.RestartEveryTime
                ||
                browserConfiguration.BrowserBehavior == BrowserBehavior.RestartOnFail;

            return shouldRestartBrowser;
        }

        ////public override void PostTestInit(MemberInfo memberInfo)
        ////{
        ////    _previousBrowserConfiguration = GetBrowserConfiguration(memberInfo);
        ////}

        public override void PostTestCleanup(TestOutcome testOutcome, MemberInfo memberInfo)
        {
            if (_currentBrowserConfiguration.BrowserBehavior == BrowserBehavior.RestartOnFail
                && testOutcome == TestOutcome.Failed)
            {
                RestartBrowser();
            }
        }

        private BrowserConfiguration GetBrowserConfiguration(MemberInfo memberInfo)
        {
            var classBrowser = GetExecutionBrowserClassLevel(memberInfo.DeclaringType);
            var methodBrowser = GetExecutionBrowserMethodLevel(memberInfo);

            BrowserConfiguration browserConfiguration = methodBrowser != null ? methodBrowser : classBrowser;
            return browserConfiguration;
        }

        private BrowserConfiguration GetExecutionBrowserMethodLevel(MemberInfo testMethod)
        {
            var executionBrowserAttribute = testMethod.GetCustomAttribute<ExecutionBrowserAttribute>(true);
            return executionBrowserAttribute?.BrowserConfiguration;
        }

        private BrowserConfiguration GetExecutionBrowserClassLevel(Type testClass)
        {
            var executionBrowserAttribute = testClass.GetCustomAttribute<ExecutionBrowserAttribute>(true);
            return executionBrowserAttribute?.BrowserConfiguration;
        }
    }
}
