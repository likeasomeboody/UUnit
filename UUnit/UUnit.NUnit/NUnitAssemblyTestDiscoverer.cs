using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace UnityUnit.NUnitAdapter
{
    /// <summary>
    /// Discovers tests assemblies containing NUnit Tests and makes the available to run
    /// </summary>
    public class NUnitAssemblyTestDiscoverer : ITestDiscoverer
    {

        public List<Assembly> Assemblies { get; private set; } = new List<Assembly>();

        public List<ITestFixture> Discover()
        {
            // get all non static types in assemblies
            var allTypes = new List<Type>();
            Assemblies.ForEach(asm => allTypes.AddRange(asm.GetTypes()));

            // get test fixtures from assembly
            var testFixtureTypes = allTypes.Where(t => 
                t.GetCustomAttributes(typeof(TestFixtureAttribute), false).Length > 0).ToList();

            // for all remaining types, check if they contian any tests and make them into a fixture
            var remainingTypes = allTypes.Where(t => !testFixtureTypes.Contains(t));

            var typesContainingTests = remainingTypes.Where(t => t.GetMethods()
                .Select(m => m.GetCustomAttributes(typeof(TestAttribute), false)).Count() > 0);

            testFixtureTypes.AddRange(typesContainingTests);

            // Create test fixtures and return
            var testFixtures = new List<ITestFixture>();
            testFixtureTypes.ForEach(t => testFixtures.Add(new NUnitTestFixture(t)));

            return testFixtures;
        }
    }
}
