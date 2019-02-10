using System;
using Experiments.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExperimentsTest
{
    [TestClass]
    public class UnitTest1
    {

        private Treatment treat;

        public void SetUpStage1()
        {
            treat = new Treatment(new int[] { 1, 1, 1, 1 });
        }

        public void SetUpStage2()
        {
            treat = new Treatment(new int[] { 1, 2, 1, 1 });
        }

        public void SetUpStage3()
        {
            treat = new Treatment(new int[] { 1, 3, 2, 2 });
        }

        public void SetUpStage4()
        {
            treat = new Treatment(new int[] { 1, 3, 3, 3 });
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
