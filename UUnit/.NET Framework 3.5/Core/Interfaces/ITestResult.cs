using System.Collections;
using System.Collections.Generic;
namespace UnityUnit
{
    public interface ITestResult
    {
        /// <summary>
        /// The outcome of this test
        /// </summary>
        TestOutcome Outcome { get; }

        /// <summary>
        /// The failure message
        /// </summary>
        string BecauseMessage { get; }

        /// <summary>
        /// The failure message
        /// </summary>
        string FailMessage { get; }
    }
}