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
        public void TestInitArray()
        {
            //Test1
            SetUpStage1();
            treat.InitArray();
            Assert.AreEqual(treat.array.length, 10);
            Assert.IsInstanceOfType(treat.array, Int32);

            //Test2
            SetUpStage2();
            treat.InitArray();
            Assert.AreEqual(treat.array.length, 10);
            Assert.IsInstanceOfType(treat.array, String);

            //Test3
            SetUpStage3();
            treat.InitArray();
            Assert.AreEqual(treat.array.length, 100);
            Assert.IsInstanceOfType(treat.array, Double);
            isOrderedAscendant(treat.array);

            //Test4
            SetUpStage4();
            Assert.AreEqual(treat.array.length, 1000);
            Assert.IsInstanceOfType(treat.array, Double);
            isOrderedDescendant(treat.array);
        }

        public void isOrderedAscendant(double [] array)
        {
            double previous = array[0];
            for (int i=1; i<array.Length; i++)
            {
                Assert.True(previous <= array[i]);
                previous = array[i];
            }
        }

        public void isOrderedDescendant(double[] array)
        {
            double previous = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                Assert.True(previous >= array[i]);
                previous = array[i];
            }
        }
    }
}
