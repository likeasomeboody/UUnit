using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnityUnit.Tests
{
    [TestFixture]
    public class BaseTestRunnerTests
    {
        [Test(Author = "Luke Sawyers", Description = "The test runner runs a single test and returns the expected pass result", TestOf = typeof(BaseTestRunner))]
        public void TestRunner_RunsPassingTest()
        {

        }

        [Test(Author = "Luke Sawyers", Description = "The test runner runs a single test and returns the expected fail result", TestOf = typeof(BaseTestRunner))]
        public void TestRunner_RunsFailingTest()
        {

        }
    }
}
