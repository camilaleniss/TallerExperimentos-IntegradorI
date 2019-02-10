using System;
using System.Collections.Generic;
using Experiments.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ExperimentsTest
{
    [TestClass]
    public class TestTreatment
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

        public List<int> SetUpParameter1()
        {
            return new List<int> { 3, 6, 8, 1, 5, 4, 7 };
        }

        public List<int> SetUpParameter2()
        {
            return new List<int> { 7, 6, 5, 4, 3, 2, 1 };
        }

        public List<int> SetUpParameter3()
        {
            return new List<int>{ 1, 2, 2, 3, 4, 5, 6 };
        }

        [TestMethod]
        public void TestInitArray()
        {
            //Test1
            SetUpStage1();
            Assert.AreEqual(treat.array.Count, 10);
            Assert.IsInstanceOfType(treat.array[0], typeof(Int32));

            //Test2
            SetUpStage2();
            Assert.AreEqual(treat.array.Count, 10);
            Assert.IsInstanceOfType(treat.array[0], typeof(String));

            //Test3
            SetUpStage3();
            Assert.AreEqual(treat.array.Count, 100);
            Assert.IsInstanceOfType(treat.array[0], typeof(Double));
            isOrderedAscendant(treat.array);

            //Test4
            SetUpStage4();
            Assert.AreEqual(treat.array.Count, 1000);
            Assert.IsInstanceOfType(treat.array[0], typeof(Double));
            isOrderedDescendant(treat.array);
        }

        public void isOrderedAscendant(dynamic array)
        {
            dynamic previous = array[0];
            for (int i = 1; i < array.Count; i++)
            {

                Assert.IsTrue(previous.CompareTo(array[i]) <= 0);
                previous = array[i];
            }
        }

        public void isOrderedDescendant(dynamic array)
        {
            dynamic previous = array[0];
            for (int i = 1; i < array.Count; i++)
            {
                Assert.IsTrue(previous.CompareTo(array[i]) >= 0);
                previous = array[i];
            }
        }

        [TestMethod]
        public void TestSorts()
        {
            Treatment trt = new Treatment(new int []{ 1, 1, 1, 1 });

            //Test1
            trt.array = SetUpParameter1();
            trt.SelectionSort();
            isOrderedAscendant(trt.array);

            //Test2
            trt.array = SetUpParameter2();
            trt.SelectionSort();
            isOrderedAscendant(trt.array);

            //Test3
            trt.array = SetUpParameter3();
            trt.SelectionSort();
            isOrderedAscendant(trt.array);

            //Test4
            trt.array = SetUpParameter1();
            trt.InsertionSort();
            isOrderedAscendant(trt.array);

            //Test5
            trt.array = SetUpParameter2();
            trt.InsertionSort();
            isOrderedAscendant(trt.array);

            //Test5
            trt.array = SetUpParameter3();
            trt.InsertionSort();
            isOrderedAscendant(trt.array);

            //Test6

            //Test7
        }

    }
}
