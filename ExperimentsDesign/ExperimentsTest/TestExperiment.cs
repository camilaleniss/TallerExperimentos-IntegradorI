using System;
using Experiments.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExperimentsTest
{
    [TestClass]
    public class TestExperiment
    {
        private Experiment experiment;

        public TestExperiment()
        {
            experiment = new Experiment();
        }

        public int[,] SetUpParameter1()
        {
            experiment = new Experiment();
            int[,] matrix = new int[4, 4];
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j=0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 1;
                }
            }
            return matrix;
        }

        public int[,] SetUpParameter2()
        {
            experiment = new Experiment();
            int[,] matrix = new int[2, 4];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[0, i] = 1;
            }
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                matrix[1, i] = 2;
            }
            return matrix;
        }

        public int[,] SetUpParameter3()
        {
            experiment = new Experiment();
            int[,] matrix = new int[1, 4];
            matrix[0, 0] = 1;
            matrix[0, 1] = 2;
            matrix[0, 2] = 3;
            matrix[0, 3] = 1; 
            return matrix;
        }

        public int[,] SetUpParameter4()
        {
            experiment = new Experiment();
            int[,] matrix = new int[100, 4];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 1;
                }
            }
            return matrix;
        }

        [TestMethod]
        public void TestInitMatrixTests()
        {
            int[,] matrix = experiment.InitMatrixTests();

            //First column
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (i < 36)
                {
                    Assert.AreEqual(matrix[i, 0] , 1);
                }
                else
                {
                    Assert.AreEqual(matrix[i, 0] , 2);
                }
            }

            //Second column
            int num = 1;
            int row = 0;
            for (int i = 0; i < 2; i++)
            {
                num = 1;
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        Assert.AreEqual(matrix[row, 1] , num);
                        row++;
                    }
                    num++;
                }
            }

            //Third column
            num = 1;
            row = 0;
            for (int i = 0; i < 8; i++)
            {
                num = 1;
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Assert.AreEqual(matrix[row, 2] , num);
                        row++;
                    }
                    num++;
                }
            }

            //Fourth column
            num = 1;
            row = 0;
            for (int i = 0; i < 24; i++)
            {
                num = 1;
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(matrix[row, 3] , num);
                    row++;
                    num++;
                }
            }
        }

        [TestMethod]
        public void TestCreateTreatments()
        {
            int[,] matrix;
            //Test 1
            matrix = SetUpParameter1();
            experiment.CreateTreatments(matrix);
            Assert.AreEqual(experiment.treatments.Count, 4);
            for (int i = 0; i<experiment.treatments.Count; i++)
            {
                Assert.AreEqual(experiment.treatments[i].algorithm, 1);
                Assert.AreEqual(experiment.treatments[i].datatype, 1);
                Assert.AreEqual(experiment.treatments[i].state, 1);
                Assert.AreEqual(experiment.treatments[i].length, 1);
                Assert.IsFalse(experiment.treatments[i].isDone);
            }

            //Test 2
            matrix = SetUpParameter2();
            experiment.CreateTreatments(matrix);
            Assert.AreEqual(experiment.treatments.Count, 2);
            for (int i = 0; i < experiment.treatments.Count; i++)
            {
                if (i < 1)
                {
                    Assert.AreEqual(experiment.treatments[0].algorithm, 1);
                    Assert.AreEqual(experiment.treatments[0].datatype, 1);
                    Assert.AreEqual(experiment.treatments[0].state, 1);
                    Assert.AreEqual(experiment.treatments[0].length, 1);
                    Assert.IsFalse(experiment.treatments[0].isDone);
                }
                else
                {
                    Assert.AreEqual(experiment.treatments[1].algorithm, 2);
                    Assert.AreEqual(experiment.treatments[1].datatype, 2);
                    Assert.AreEqual(experiment.treatments[1].state, 2);
                    Assert.AreEqual(experiment.treatments[1].length, 2);
                    Assert.IsFalse(experiment.treatments[1].isDone);
                }
                
            }

            //Test 3
            matrix = SetUpParameter3();
            experiment.CreateTreatments(matrix);
            Assert.AreEqual(experiment.treatments.Count, 1);
            Assert.AreEqual(experiment.treatments[0].algorithm, 1);
            Assert.AreEqual(experiment.treatments[0].datatype, 2);
            Assert.AreEqual(experiment.treatments[0].state, 3);
            Assert.AreEqual(experiment.treatments[0].length, 1);
            Assert.IsFalse(experiment.treatments[0].isDone);

            //Test 4
            matrix = SetUpParameter4();
            experiment.CreateTreatments(matrix);
            Assert.AreEqual(experiment.treatments.Count, 100);
        }

    }

}
