using System;
using System.Collections.Generic;
using System.Text;

namespace Experiments.Model
{

    public class Treatment
    {

        public const int LEN_1 = 100;
        public const int LEN_2 = 1000;
        public const int LEN_3 = 10000;

        private int Algorithm { get; set; }
        private int Datatype {get; set; }
        private int State {get; set; }
        private int Length { get; set; }
        //private T[] Array { get; set; }
        private long Time { get; }

        private Boolean isDone { get; set; }


        public Treatment(int [] values)
        {
            Algorithm = values[0];
            Datatype = values[1];
            State = values[2];
            Length = values[3];
            isDone = false;
        }

        public void initArray()
        {
            
        }

        public long ExecuteTest()
        {
            //Devuelve el tiempo que tardó en ordenar el arreglo
            return 10;
        }

        /*
        private T[] sort (T[] array)
        {
            return new T[2];
        }
        private T[] SelectionSort(T[] array)
        {
            return new T[2];
        }

        private T[] InsertionSort(T[] array)
        {
            return new T[2];
        }
        */
    }
}
