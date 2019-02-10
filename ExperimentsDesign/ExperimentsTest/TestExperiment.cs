using System;
using Experiments.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExperimentsTest
{
    [TestClass]
    public class UnitTest1
    {
        private Experiment exp;

        private void SetupScenario1()
        {
            exp = new Experiment();
        }

        [TestMethod]
        public void TestGetNextTreatment()
        {
            SetupScenario1();
        }
    }
}
