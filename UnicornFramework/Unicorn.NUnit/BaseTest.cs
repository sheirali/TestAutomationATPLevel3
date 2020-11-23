﻿using System;
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
        }

        public TestContext TestContext { get; set; }

        public string TestName => TestContext.CurrentContext.Test.FullName;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var memberInfo = GetType().GetMethod(TestName);
            _testExecutionSubject.PreClassInit(memberInfo);
            ClassInit();
            _testExecutionSubject.PostClassInit(memberInfo);
        }

        [SetUp]
        public void SetUp()
        {
            var memberInfo = GetType().GetMethod(TestName);
            _testExecutionSubject.PreTestInit(memberInfo);
            TestInit();
            _testExecutionSubject.PostTestInit(memberInfo);
        }

        [TearDown]
        public void TearDown()
        {
            var memberInfo = GetType().GetMethod(TestName);
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
    }
}