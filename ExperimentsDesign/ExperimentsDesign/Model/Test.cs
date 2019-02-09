using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsDesign.Model
{
    public const int LEN1 = 10;
    public const int LEN2 = 100;
    public const int LEN3 = 1000;

    public class Test<T>
    {
        private int Algorithm { get; set; }
        private int Datatype {get; set; }
        private int State {get; set; }
        private int Length { get; set; }
        private T[] Array { get; set; }
        private long Time { get; }


        public Test(int [] values)
        {
            Algorithm = values[0];
            Datatype = values[1];
            State = values[2];
            Length = values[3];
        }

        public void initArray()
        {
            
        }

        public long ExecuteTest()
        {
            return 10;
        }

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

    }
}
