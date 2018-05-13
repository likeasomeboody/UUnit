using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace UnityUnit.NUnitAdapter.Tests
{
    [TestFixture]
    public class NUnitTestTests
    {
        [Test(
            Author = "Luke Sawyers", 
            Description = "NUnit Test should throw an exception " +
            "if a method thats not a test method is passed in.")]
        public void ThrowsExceptionIfContstructedWithNonTestMethod()
        {
            // Arrange
            var asm = Assembly.GetAssembly(this.GetType());
            var testMethodClass = new TestMethods();
            var method = testMethodClass.GetType().GetMethod("NonTestMethod");

            // Act / Assert
            Assert.Throws<Exception>(() =>
            {
                var test = new NUnitTest(method);
            });
        }

        [Test(
            Author = "Luke Sawyers",
            Description = "")]
        public void RunTestRunsPassingTest()
        {

        }

        [Test(
            Author = "Luke Sawyers",
            Description = "")]
        public void RunTestRunsFailingTest()
        {

        }
    }

    public class TestMethods
    {
        public int testInt = 0;

        public void NonTestMethod()
        {

        }

        [Test]
        public void PassingTest()
        {
            testInt = 1;
        }

        [Test]
        public void FailingTest()
        {

        }

        [Ignore("Ignore Test")]
        [Test]
        public void IgnoredTest()
        {
            testInt = 1;
        }
    }
}
