using System.Collections;
using System.Collections.Generic;
namespace UUnit
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
        string Message { get; }
    }
}