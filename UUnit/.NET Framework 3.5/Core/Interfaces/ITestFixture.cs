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
        /// Run this fixture and all it's tests
        /// </summary>
        void Run();
    }
}