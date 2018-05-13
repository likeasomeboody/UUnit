using System.Collections;
using System.Collections.Generic;
namespace UnityUnit
{
    public interface ITestResult
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
        /// The outcome of this test
        /// </summary>
        TestOutcome Outcome { get; }

        /// <summary>
        /// Why this test is run
        /// </summary>
        string Because { get; }

        /// <summary>
        /// Message generated from running the test
        /// </summary>
        string Message { get; }
    }
}