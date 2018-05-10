using System.Collections;
using System.Collections.Generic;

namespace UnityUnit
{
    /// <summary>
    /// An interface for an object that can discover test fixtures
    /// </summary>
    public interface ITestDiscoverer
    {
        /// <summary>
        /// Fixtures that have been discovered
        /// </summary>
        List<ITestFixture> Fixtures { get; }

        /// <summary>
        /// Discover test fixtures
        /// </summary>
        void Discover();
    }
}