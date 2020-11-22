using System;
using System.Reflection;

namespace Unicorn.Plugins
{
    public interface ITestExectionPluginObserver
    {
        void PreTestInit(MemberInfo memberInfo);
        void PostTestInit(MemberInfo memberInfo);
        void PreTestCleanup(TestOutcome testOutcome, MemberInfo memberInfo);
        void PostTestCleanup(TestOutcome testOutcome, MemberInfo memberInfo);
        void TestInstantiated(MemberInfo memberInfo);
    }
}
