using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Experiments.Model
{
    public class Experiment
    {
        public static readonly int[] LEVELS = new int[] { 2, 4, 3, 3 };

        private List<Treatment> treatments { get; set; }

        public Experiment()
        {
            treatments = new List<Treatment>();
            InitTests();
        }


        public void InitTests()
        {
            int[,] matrix = InitMatrixTests();
            CreateTreatments(matrix);
        }

        private int[] GetNextTreatment(int[] treatment)
        {
            int sum = 1;
            for (int i = treatment.Length - 1; i >= 0; i--)
            {
                if (treatment[i] == LEVELS[i] && sum == 1)
                {
                    sum = 1;
                    treatment[i] = 1;
                }
                else
                {
                    treatment[i] += sum;
                    sum = 0;
                }
            }

            return treatment;
        }

        /// <summary>
        /// Initializes the treatements matrix as shown in the report of Experiments Design 
        /// </summary>
        /// <returns></returns>
        public int[,] InitMatrixTests()
        {
            int rows = 1;
            foreach (int level in LEVELS)
            {
                rows *= level;
            }

            int columns = LEVELS.Length;

            int[,] matrix = new int[rows, columns];

            int[] treatment = new int[columns];
            for (int i = 0; i < treatment.Length; i++)
            {
                treatment[i] = 1;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = treatment[j];
                }
                treatment = GetNextTreatment(treatment);
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
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    array[j] = matrix[i, j];
                }
                Treatment treatment = new Treatment(array);
                treatments.Add(treatment);
            }
        }

        public void WriteCSV()
        {
            try
            {

                StreamWriter sw = new StreamWriter("..\\..\\results.csv", false);
                sw.WriteLine("Sorting algorithm,Data type,Values state,Array size,Time (ms)");
                foreach (Treatment treatment in treatments)
                {
                    sw.WriteLine(treatment.ToString() + "," + treatment.ExecuteTest());
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

    }
}
