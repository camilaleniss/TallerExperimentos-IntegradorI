using Experiments.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments
{
    public class Program
    {
        private static Experiment exp;
        public static void Main(string[] args)
        {
            exp = new Experiment();
            int[,] matrix = exp.InitMatrixTests();
            string ruta = "..\\..\\respond.txt";
            writeRespuesta(matrix, ruta);
            exp.WriteCSV();
        }

        

        public static void writeRespuesta(int[,] matrix, string ruta)
        {
            try
            {
                StreamWriter sw = new StreamWriter(ruta, false);
                for (int f = 0; f < matrix.GetLength(0); f++)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        sw.Write(matrix[f, c] + " ");
                    }
                    sw.WriteLine("");
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
