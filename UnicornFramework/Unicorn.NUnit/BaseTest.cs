using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Unicorn.Plugins;

namespace Unicorn.NUnit
{
    [TestFixture]
    public class BaseTest
    {
        private readonly TestExectionSubject _testExecutionSubject = new TestExectionSubject();

        public BaseTest()
        {
            ////InitializeTestExecutionBehaviourObservers();
        }

        public TestContext TestContext { get; set; }

        public string TestName => TestContext.CurrentContext.Test.Name;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            InitializeTestExecutionBehaviourObservers();
            ////var memberInfo = GetCurrentExecutionTestClassType().GetMethod(TestName);
            ////_testExecutionSubject.PreClassInit(memberInfo);
            ////ClassInit();
            ////_testExecutionSubject.PostClassInit(memberInfo);
        }

        [SetUp]
        public void SetUp()
        {
            ////InitializeTestExecutionBehaviourObservers();
            var memberInfo = GetCurrentExecutionTestClassType().GetMethod(TestName);
            _testExecutionSubject.PreTestInit(memberInfo);
            TestInit();
            _testExecutionSubject.PostTestInit(memberInfo);
        }

        [TearDown]
        public void TearDown()
        {
            ////InitializeTestExecutionBehaviourObservers();
            var memberInfo = GetCurrentExecutionTestClassType().GetMethod(TestName);
            var outcome = (TestOutcome)TestContext.CurrentContext.Result.Outcome.Status;
            _testExecutionSubject.PreTestCleanup(outcome, memberInfo);
            TestCleanup();
            _testExecutionSubject.PostTestCleanup(outcome, memberInfo);
        }

        public virtual void ClassInit()
        {
        }

        public virtual void TestInit()
        {
        }

        public virtual void TestCleanup()
        {
        }

        private Type GetCurrentExecutionTestClassType()
        {
            // TODO: fix method GetCurrentExecutionTestClassType()
            ////var classType = Assembly.GetEntryAssembly().GetType(TestContext.CurrentContext.Test.ClassName);
            ////var stackFrame = new StackTrace().GetFrames().FirstOrDefault();
            var classType = GetType().Assembly.GetType(TestContext.CurrentContext.Test.ClassName);
            ////var classType = Assembly.GetExecutingAssembly().GetType(TestContext.CurrentContext.Test.ClassName);
            return classType;
        }

        private void InitializeTestExecutionBehaviourObservers()
        {
            var observers = ServiceContainer.ResolveAll<BaseTestExectionPluginObserver>();
            foreach (var observer in observers)
            {
                _testExecutionSubject.Attach(observer);
            }
        }
    }
}
