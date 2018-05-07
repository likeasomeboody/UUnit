using System.Collections;
using System.Collections.Generic;

namespace UUnit
{
    /// <summary>
    /// A test
    /// </summary>
    public interface ITest 
    {
        /// <summary>
        /// The name of this test
        /// </summary>
        string Name { get; }

        /// <summary>
        /// A description of this test
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Runs this test
        /// </summary>
        /// <returns></returns>
        ITestResult Run();
    }
}