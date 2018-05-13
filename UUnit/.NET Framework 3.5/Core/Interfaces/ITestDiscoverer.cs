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
        /// Return test fixtures to be run
        /// </summary>
        List<ITestFixture> Discover();
    }
}