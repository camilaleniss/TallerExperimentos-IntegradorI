using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsDesign.Model
{
    public class Experiment
    {
        private List<Treatment> treatments { get; set;}

        public Experiment()
        {
            treatments = new List<Treatment>();
        }

        public void ExecuteExperiment()
        {

        }

        public void InitTests()
        {
            int [,] matrix = InitMatrixTests();
            CreateTreatments(matrix);
        }
        /// <summary>
        /// Initializes the treatements matrix as shown in the report of Experiments Design 
        /// </summary>
        /// <returns></returns>
        public int[,] InitMatrixTests()
        {
            int[,] matrix = new int[72,4];
            //First column
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i,0] = (i < 36) ? 1 : 2;
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
                        matrix[row,1] = num;
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
                        matrix[row,2] = num;
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
                    matrix[row,3] = num;
                    row++;
                    num++;
                }
            }
            return matrix;
        }
        /// <summary>
        /// Creates 72 Treatments where the values of each treatments are a row of the matrix
        /// </summary>
        /// <param name="matrix"></param>
        public void CreateTreatments(int[,] matrix)
        {
            int[] array = new int[4];
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                for (int j=0; j<4; j++)
                {
                    array[j] = matrix[i, j];
                }
                Treatment treatment = new Treatment(array);
                treatments.Add(treatment);
            }
        }

        public void ExecuteTreatment(Treatment test)
        {
            long time = test.ExecuteTest();
        }

        public void WriteCVS()
        {

        }




        
    }
}
