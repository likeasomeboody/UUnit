using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace UnityUnit.NUnit
{
    /// <summary>
    /// Discovers tests assemblies containing NUnit Tests and makes the available to run
    /// </summary>
    public class NUnitAssemblyTestDiscoverer : ITestDiscoverer
    {
        #region Properties

        /// <summary>
        /// All assemblies to search for test methods in
        /// </summary>
        public List<Assembly> Assemblies { get; private set; } = new List<Assembly>();

        #region Properties.ITestDiscoverer

        public List<ITestFixture> Fixtures { get; private set; } = new List<ITestFixture>();

        #endregion

        #endregion

        #region Methods

        public void AddAssembly(Assembly asm)
        {
            
        }

        #region Methods.ITestDiscoverer

        public void Discover()
        {            
            // get test fixtures from assembly


            // get all tests not already in a test fixture

            var types = asm.GetTypes();
            var testFixtures = types.Where(t => t.GetCustomAttributes(typeof(TestFixtureAttribute), false).Length > 0);
            var
        }

        #endregion

        #endregion
    }
}
