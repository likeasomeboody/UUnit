using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityUnit
{
    public class AssertionException : Exception
    {
        public string BecauseMessage { get; set; }
        public string FailureMessage { get; set; }

        public AssertionException(string becauseMessage, string failureMessage)
        {
            BecauseMessage = becauseMessage;
            FailureMessage = failureMessage;
        }
        
    }
}
