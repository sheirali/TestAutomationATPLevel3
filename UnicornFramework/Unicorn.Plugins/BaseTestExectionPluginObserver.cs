using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Unicorn.Plugins
{
    public class BaseTestExectionPluginObserver
    {
        private readonly TestExectionSubject _testExectionSubject;

        public BaseTestExectionPluginObserver(TestExectionSubject testExectionSubject)
        {
            _testExectionSubject = testExectionSubject;
            _testExectionSubject.Attach(this);
        }

        public virtual void PostTestCleanup(TestOutcome testOutcome, MemberInfo memberInfo)
        {
        }

        public virtual void PostTestInit(MemberInfo memberInfo)
        {
        }

        public virtual void PreTestCleanup(TestOutcome testOutcome, MemberInfo memberInfo)
        {
        }

        public virtual void PreClassInit(MethodInfo memberInfo)
        {
        }

        public virtual void PostClassInit(MethodInfo memberInfo)
        {
        }

        public virtual void PreTestInit(MemberInfo memberInfo)
        {
        }

        public virtual void TestInstantiated(MemberInfo memberInfo)
        {
        }
    }
}
