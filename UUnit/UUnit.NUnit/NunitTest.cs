using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace UnityUnit.NUnitAdapter
{
    /// <summary>
    /// An adapter class for a NUnit Test.
    /// Responsible for the running and reporting of a single NUnit Test
    /// </summary>
    public class NUnitTest : ITest
    {
        public string Name => string.Format("{0}.{1}", _testMethod.DeclaringType, _testMethod.Name);

        public string Description => _testAttribute.Description;

        private MethodBase _testMethod;
        private TestAttribute _testAttribute;
        private IgnoreAttribute _ignoreAttribute;
        private RepeatAttribute _repeatAttribute;
       
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="testMethod"></param>
        /// <exception cref="Exception"/>
        public NUnitTest(MethodBase testMethod)
        {
            var testAttributes = testMethod.GetCustomAttributes(false);
            if (testAttributes.Length > 0)
            {
                _testAttribute = testAttributes.OfType<TestAttribute>().FirstOrDefault();
            }
            else
            {
                throw new Exception("The method provided does not have the Nunit TestAttribute");
            }

            _ignoreAttribute = testAttributes.OfType<IgnoreAttribute>().FirstOrDefault();
            _repeatAttribute = testAttributes.OfType<RepeatAttribute>().FirstOrDefault();

            _testMethod = testMethod;
        }

        /// <summary>
        /// Run the test
        /// </summary>
        /// <returns></returns>
        public ITestResult Run(object testObject)
        {
            var result = new TestResult();
            result.Name = Name;
            result.Description = Description;

            // ignore the test if this attribute is present
            if (_ignoreAttribute != null)
            {
                result.Outcome = TestOutcome.Skipped;
                result.Message = string.Format("Test Ignored {0}", _ignoreAttribute.GetType().
                    GetField("_reason").GetValue(_ignoreAttribute));
                return result;
            }

            // acquire the repeat value from the repeat value if present
            int repeat = 1;
            if (_repeatAttribute != null)
            {
                repeat = (int)_repeatAttribute.GetType().GetField("_count").GetValue(_repeatAttribute);
            }

            // roof the repeat value
            if(repeat < 1)
            {
                repeat = 1;
            }

            // run the test method, handle any exceptions
            try
            {
                for (int i = 0; i < repeat; i++)
                {
                    _testMethod.Invoke(testObject, null);
                }
            }
            catch(NUnit.Framework.AssertionException e)
            {
                result.Outcome = TestOutcome.Failed;
                result.Message = e.Message;
            }
            catch(Exception e)
            {
                result.Outcome = TestOutcome.Error;
                result.Message = e.Message;
            }

            result.Outcome = TestOutcome.Passed;
            result.Message = "Test passed";

            return result;
        }
    }
}
