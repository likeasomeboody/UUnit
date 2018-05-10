using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

namespace UnityUnit.NUnit
{
    public class NUnitTestFixture : ITestFixture
    {
        #region Properies

        #region Properies.ITestFixture

        public string Name
        {
            get
            {
                return _fixtureType.ToString();
            }
        }

        #endregion

        #region Properies.private

        public List<ITest> Tests
        {
            get
            {
                return _fixtureType.GetMethods()
                    .Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0)
                    .Select(m => (ITest)new NUnitTest())
                    .ToList();
            }
        }

        #endregion

        #endregion

        #region Fields

        private Type _fixtureType;
        private TestFixtureAttribute _testFixtureAttribute;

        #endregion

        #region Methods

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="testFixtureAttribute"></param>
        /// <param name="fixtureType"></param>
        public NUnitTestFixture(TestFixtureAttribute testFixtureAttribute, Type fixtureType)
        {
            _testFixtureAttribute = testFixtureAttribute;
            _fixtureType = fixtureType;
        }

        #region Methods.ITestFixture

        public void Run()
        {
            // run fixture setup
            // run each test
            // run fixture teardown
        }

        private void SetUpFixture()
        {

        }

        private void SetUp()
        {

        }

        private void TearDown()
        {

        }

        private void TearDownFixture()
        {
            var method = 
        }

        #endregion

        #endregion
    }
}
