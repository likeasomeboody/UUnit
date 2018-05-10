using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityUnit
{
    /// <summary>
    /// Basic UnityUnit Test Assertion methods
    /// </summary>
    public static class Assert
    {   
        /// <summary>
        /// Fails the current test
        /// </summary>
        /// <param name="becauseMessage">Why is this test being run</param>
        /// <param name="failMessageFormat">Custom formatted fail message</param>
        /// <param name="failMessageArgs">Arguments for fail message</param>
        /// <exception cref="AssertionException"/>
        public static void Fail(string becauseMessage = "", string failMessageFormat = "", params object[] failMessageArgs)
        {
            throw new AssertionException(becauseMessage, string.Format("Test Failed " + failMessageFormat, failMessageArgs));
        }

        /// <summary>
        /// Checks the equality of the passed in arguments
        /// </summary>
        /// <param name="becauseMessage">Why is this test being run</param>
        /// <param name="failMessageFormat">Custom formatted fail message</param>
        /// <param name="failMessageArgs">Arguments for fail message</param>
        /// <exception cref="AssertionException"/>
        public static void AreEqual(object expected, object actual, string becauseMessage = "", string failMessageFormat = "", params object[] failMessageArgs)
        {
            if (!(expected.Equals(actual)))
            {
                throw new AssertionException(becauseMessage, string.Format("Test Failed: Expected {0} but was {1}" + failMessageFormat, expected, actual, failMessageArgs));
            }
        }

        /// <summary>
        /// Checks that the type of the object matches the expected type exactly
        /// </summary>
        /// <param name="becauseMessage">Why is this test being run</param>
        /// <param name="failMessageFormat">Custom formatted fail message</param>
        /// <param name="failMessageArgs">Arguments for fail message</param>
        /// <exception cref="AssertionException"/>
        public static void IsType(Type expectedType, object obj, string becauseMessage = "", string failMessageFormat = "", params object[] failMessageArgs)
        {
            if(!(obj.GetType() == expectedType))
            {
                throw new AssertionException(becauseMessage, string.Format("Test Failed " + failMessageFormat, failMessageArgs));
            }
        }
    }
}
