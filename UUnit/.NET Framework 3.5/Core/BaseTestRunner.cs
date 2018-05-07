using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace UUnit
{
    /// <summary>
    /// Base class for a test runner
    /// </summary>
    public abstract class BaseTestRunner : ITestRunner
    {
        #region Properties

        #region Properties.Public

        /// <summary>
        /// All tests in this runner
        /// </summary>
        public List<ITest> Tests
        {
            get
            {
                List<ITest> allTests = new List<ITest>();
                Fixtures.ForEach((f) => allTests.AddRange(f.Tests));
                return allTests;
            }
        }

        /// <summary>
        /// All fixtures in this runner
        /// </summary>
        public List<ITestFixture> Fixtures
        {
            get
            {
                List<ITestFixture> allFixtures = new List<ITestFixture>();
                _discoverers.ForEach((d) => allFixtures.AddRange(d.Fixtures));
                return allFixtures;
            }
        }

        #endregion

        #region Properties.Protectedx

        /// <summary>
        /// The most recent test results
        /// </summary>
        protected Dictionary<ITest, ITestResult> TestResults
        {
            get;
            private set;
        }

        #endregion

        #endregion

        #region Fields

        private List<ITestDiscoverer> _discoverers = new List<ITestDiscoverer>();
        private List<ITestProcessor> _processors = new List<ITestProcessor>();

        #endregion

        #region Methods

        #region Methods.Protected 

        /// <summary>
        /// Discover tests and add them to the dictionary if they dont exist
        /// </summary>
        public virtual void Discover()
        {
            _discoverers.ForEach((d) => d.Discover());

            foreach(var test in Tests)
            {
                if (!TestResults.ContainsKey(test))
                {
                    TestResults.Add(test, new TestResult(TestOutcome.NotRun, ""));
                }
            }

            foreach(var test in TestResults.Keys)
            {
                if(test == null)
                {
                    TestResults.Remove(test);
                }
            }
        }

        /// <summary>
        /// Add a test discoverer
        /// </summary>
        /// <param name="discoverer"></param>
        public virtual void AddTestDiscoverer(ITestDiscoverer discoverer)
        {
            _discoverers.Add(discoverer);
        }

        /// <summary>
        /// Remove a test discoverer
        /// </summary>
        /// <param name="discoverer"></param>
        /// <returns></returns>
        public virtual bool RemoveTestDiscoverer(ITestDiscoverer discoverer)
        {
            return _discoverers.Remove(discoverer);
        }

        /// <summary>
        /// Add a test processor
        /// </summary>
        /// <param name="discoverer"></param>
        public virtual void AddTestProcessor(ITestProcessor discoverer)
        {
            _processors.Add(discoverer);
        }

        /// <summary>
        /// Remove a test processor
        /// </summary>
        /// <param name="discoverer"></param>
        /// <returns></returns>
        public virtual bool RemoveTestProcessor(ITestProcessor discoverer)
        {
            return _processors.Remove(discoverer);
        }

        /// <summary>
        /// Run all tests
        /// </summary>
        public virtual void RunAllTests()
        {
            RunTestsWithResult(TestOutcome.Failed, TestOutcome.NotRun, TestOutcome.Passed, TestOutcome.Skipped);
        }

        /// <summary>
        /// Run all tests that have the speicified test results
        /// </summary>
        /// <param name="outcomeToRun"></param>
        public virtual void RunTestsWithResult(params TestOutcome[] outcomesToRun)
        {
            Discover();
            var testsToRun = TestResults.Where(k => outcomesToRun.Contains(k.Value.Outcome)).Select(k => k.Key);
            RunTests(testsToRun);
        }

        /// <summary>
        /// Runs a collection of tests
        /// </summary>
        /// <param name="testsToRun"></param>
        public virtual void RunTests(IEnumerable<ITest> testsToRun)
        {
            foreach (var test in Tests)
            {
                RunTest(test);
            }
        }

        /// <summary>
        /// Runs a single test
        /// </summary>
        /// <param name="testToRun"></param>
        public virtual void RunTest(ITest testToRun)
        {
            var result = testToRun.Run();
            TestResults[testToRun] = result;
        }

        #endregion

        #endregion
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