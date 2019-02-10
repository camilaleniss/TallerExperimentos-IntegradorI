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

        public void SetUpStage1()
        {
            
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
    }
}
