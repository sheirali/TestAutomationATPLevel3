using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Unicorn.Plugins
{
    public class TestExectionSubject
    {
        private readonly List<BaseTestExectionPluginObserver> _testExecutionPlugins;

        public TestExectionSubject()
        {
            _testExecutionPlugins = new List<BaseTestExectionPluginObserver>();
        }

        public void Attach(BaseTestExectionPluginObserver observer)
        {
            _testExecutionPlugins.Add(observer);
        }

        public void Detach(BaseTestExectionPluginObserver observer)
        {
            _testExecutionPlugins.Remove(observer);
        }

        public void PreClassInit(MethodInfo memberInfo)
        {
            _testExecutionPlugins.ForEach(p => p.PreClassInit(memberInfo));
        }

        public void PostClassInit(MethodInfo memberInfo)
        {
            _testExecutionPlugins.ForEach(p => p.PostClassInit(memberInfo));
        }

        public void PreTestInit(MethodInfo memberInfo)
        {
            _testExecutionPlugins.ForEach(p => p.PreTestInit(memberInfo));
        }

        public void PostTestInit(MethodInfo memberInfo)
        {
            _testExecutionPlugins.ForEach(p => p.PostTestInit(memberInfo));
        }

        public void PreTestCleanup(TestOutcome testOutcome, MethodInfo memberInfo)
        {
            _testExecutionPlugins.ForEach(p => p.PreTestCleanup(testOutcome, memberInfo));
        }

        public void PostTestCleanup(TestOutcome testOutcome, MethodInfo memberInfo)
        {
            _testExecutionPlugins.ForEach(p => p.PostTestCleanup(testOutcome, memberInfo));
        }
    }
}
