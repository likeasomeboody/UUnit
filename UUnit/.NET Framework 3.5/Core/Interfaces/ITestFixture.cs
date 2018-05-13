using System.Collections;
using System.Collections.Generic;

namespace UnityUnit
{
    public interface ITestFixture
    {
        /// <summary>
        /// The name of this test fixture 
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Return tests to be as Test Results without running the tests
        /// </summary>
        List<ITestResult> Discover();

        /// <summary>
        /// Run this fixture and all it's tests
        /// </summary>
        List<ITestResult> Run();
    }
}