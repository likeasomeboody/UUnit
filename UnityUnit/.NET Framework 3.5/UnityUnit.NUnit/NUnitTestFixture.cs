using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace UnityUnit.NUnitAdapter
{
    /// <summary>
    /// Adapter class for an NUnit Test fixture
    /// Responsible for running and reporting of all tests within the test fixture. 
    /// </summary>
    public class NUnitTestFixture : ITestFixture
    {
        public string Name
        {
            get
            {
                return _fixtureType.ToString();
            }
        }

        private Type _fixtureType;
        private TestFixtureAttribute _testFixtureAttribute;

        private object _fixtureObject;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="testFixtureAttribute"></param>
        /// <param name="fixtureType"></param>
        public NUnitTestFixture(Type fixtureType)
        {
            var testAttributes = fixtureType.GetCustomAttributes(false);
            if (testAttributes.Length > 0)
            {
                _testFixtureAttribute = testAttributes.OfType<TestFixtureAttribute>().FirstOrDefault();
            }
            else
            {
                throw new Exception("The method provided does not have the Nunit TestAttribute");
            }

            _fixtureType = fixtureType;

        }

        /// <summary>
        /// Return tests to be as Test Results without running the tests
        /// </summary>
        public List<ITestResult> Discover()
        {
            // get the tests
            var tests = _fixtureType.GetMethods()
                    .Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0)
                    .Select(m => (ITest)new NUnitTest(m))
                    .ToList();

            List<ITestResult> results = new List<ITestResult>();

            // create a test result for each of the tests
            foreach (var test in tests)
            {
                var result = new TestResult(test.Name, test.Description, TestOutcome.NotRun, "");
                results.Add(result);
            }

            // dispose of the object
            _fixtureObject = null;

            return results;
        }

        /// <summary>
        /// Run all tests in this fixture
        /// </summary>
        /// <returns>The results of all the tests run</returns>
        public List<ITestResult> Run()
        {
            // get the tests
            var tests = _fixtureType.GetMethods()
                    .Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0)
                    .Select(m => (ITest)new NUnitTest(m))
                    .ToList();
            
            // create an instance of the object
            _fixtureObject = Activator.CreateInstance(_fixtureType);

            // get the setup method
            var setUpTest = _fixtureType.GetMethods()
                   .Where(m => m.GetCustomAttributes(typeof(SetUpAttribute), false).Length > 0)
                   .FirstOrDefault();

            // get the teardown method
            var tearDownTest = _fixtureType.GetMethods()
                   .Where(m => m.GetCustomAttributes(typeof(TearDownAttribute), false).Length > 0)
                   .FirstOrDefault();

            // invoke the setup fixture method 
            var setUpFixture = _fixtureType.GetMethods()
                   .Where(m => m.GetCustomAttributes(typeof(SetUpFixtureAttribute), false).Length > 0)
                   .FirstOrDefault();
            setUpFixture?.Invoke(_fixtureObject, null);

            List<ITestResult> results = new List<ITestResult>();

            // run the tests
            foreach (var test in tests)
            {
                setUpTest?.Invoke(_fixtureObject, null);

                var testResult = test.Run(_fixtureObject);
                results.Add(testResult);

                tearDownTest?.Invoke(_fixtureObject, null);
            }

            // dispose of the object
            _fixtureObject = null;

            return results;
        }
    }
}
