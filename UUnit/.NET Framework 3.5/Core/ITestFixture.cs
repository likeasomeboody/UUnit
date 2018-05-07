using System.Collections;
using System.Collections.Generic;

namespace UUnit
{
    public interface ITestFixture
    {
        /// <summary>
        /// All tests in this fixture
        /// </summary>
        /// <returns></returns>
        List<ITest> Tests { get; }

        /// <summary>
        /// Set up for each test
        /// </summary>
        void SetUp();

        /// <summary>
        /// Teardown for each test
        /// </summary>
        void TearDown();

        /// <summary>
        /// Set up for this fixture
        /// </summary>
        void SetUpFixture();

        /// <summary>
        /// Run teardown for this fixture
        /// </summary>
        void TearDownFixture();
    }
}