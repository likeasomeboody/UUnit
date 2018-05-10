using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityUnit.NUnit
{
    public class NUnitTest : ITest
    {
        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public ITestResult Run()
        {
            throw new NotImplementedException();
        }
    }
}
