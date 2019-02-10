using System;
using System.Collections.Generic;
using System.Text;

namespace Experiments.Model
{

    public class Treatment
    {
        public const int SELECTION_SORT = 1;
        public const int INSERTION_SORT = 2;

        public const int INT_32 = 1;
        public const int STRING = 2;
        public const int DOUBLE = 3;
        public const int OBJECT = 4;

        public const int NOT_ORDERED = 1;
        public const int ASCENDING_ORDER = 2;
        public const int DESCENDING_ORDER = 3;

        public static readonly int[] SIZES = new int[] { 100, 1000, 10000 };

        private int algorithm;
        private int datatype;
        private int state;
        private int length;
        private long time;

        private Boolean isDone { get; set; }


        public Treatment(int [] values)
        {
            algorithm = values[0];
            datatype = values[1];
            state = values[2];
            length = values[3];
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
