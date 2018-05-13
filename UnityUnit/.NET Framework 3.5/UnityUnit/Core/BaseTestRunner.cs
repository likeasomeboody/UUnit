using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UnityUnit
{
    /// <summary>
    /// Base class for a test runner
    /// </summary>
    public abstract class BaseTestRunner : ITestRunner
    {
        public void AddTestDiscoverer(ITestDiscoverer discoverer)
        {
            throw new System.NotImplementedException();
        }

        public void AddTestProcessor(ITestProcessor discoverer)
        {
            throw new System.NotImplementedException();
        }

        public void Discover()
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveTestDiscoverer(ITestDiscoverer discoverer)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveTestProcessor(ITestProcessor discoverer)
        {
            throw new System.NotImplementedException();
        }

        public void RunAllTests()
        {
            throw new System.NotImplementedException();
        }

        public void RunTest(ITest testToRun)
        {
            throw new System.NotImplementedException();
        }

        public void RunTests(IEnumerable<ITest> testsToRun)
        {
            throw new System.NotImplementedException();
        }

        public void RunTestsWithResult(params TestOutcome[] outcomesToRun)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ITestRunner
    {
        /// <summary>
        /// Discover tests and add them to the dictionary if they dont exist
        /// </summary>
        void Discover();

        /// <summary>
        /// Add a test discoverer
        /// </summary>
        /// <param name="discoverer"></param>
        void AddTestDiscoverer(ITestDiscoverer discoverer);

        /// <summary>
        /// Remove a test discoverer
        /// </summary>
        /// <param name="discoverer"></param>
        /// <returns></returns>
        bool RemoveTestDiscoverer(ITestDiscoverer discoverer);

        /// <summary>
        /// Add a test processor
        /// </summary>
        /// <param name="discoverer"></param>
        void AddTestProcessor(ITestProcessor discoverer);

        /// <summary>
        /// Remove a test processor
        /// </summary>
        /// <param name="discoverer"></param>
        /// <returns></returns>
        bool RemoveTestProcessor(ITestProcessor discoverer);

        /// <summary>
        /// Run all tests
        /// </summary>
        void RunAllTests();

        /// <summary>
        /// Run all tests that have the speicified test results
        /// </summary>
        /// <param name="outcomeToRun"></param>
        void RunTestsWithResult(params TestOutcome[] outcomesToRun);

        /// <summary>
        /// Runs a collection of tests
        /// </summary>
        /// <param name="testsToRun"></param>
        void RunTests(IEnumerable<ITest> testsToRun);

        /// <summary>
        /// Runs a single test
        /// </summary>
        /// <param name="testToRun"></param>
        void RunTest(ITest testToRun);
    }
}