using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
        public const int INT_64 = 4;

        public const int NOT_ORDERED = 1;
        public const int ASCENDING_ORDER = 2;
        public const int DESCENDING_ORDER = 3;

        public const int MIN_INT = -10000;
        public const int MAX_INT = 10000;

        public const int MAX_STRING_SIZE = 1000;

        public const int REPETITIONS = 10;

        public static readonly int[] SIZES = new int[] { 0, 1000, 2000, 3000};

        public int algorithm { get; }
        public int datatype { get; }
        public int state { get; }
        public int length { get; }
        public dynamic array { get; set; }

        public Boolean isDone { get; set; }

        public Treatment(int[] values)
        {
            algorithm = values[0];
            datatype = values[1];
            state = values[2];
            length = values[3];
            isDone = false;

            InitArray();
            FillArray(new Random());
        }

        public void InitArray()
        {
            switch (datatype)
            {
                case INT_32:
                    array = new List<Int32>();
                    break;

                case STRING:
                    array = new List<String>();
                    break;

                case DOUBLE:
                    array = new List<Double>();
                    break;

                case INT_64:
                    array = new List<Int64>();
                    break;
            }
        }

        private void FillArray(Random random)
        {
            for (int i = 0; i < SIZES[length]; i++)
            {
                switch (datatype)
                {
                    case INT_32:
                        array.Add(random.Next(MAX_INT - MIN_INT) + MIN_INT);
                        break;

                    case STRING:
                        array.Add(GetRandomString(random));
                        break;

                    case DOUBLE:
                        array.Add(random.NextDouble() * (MAX_INT - MIN_INT) + MIN_INT);
                        break;

                    case INT_64:
                        array.Add((long)random.Next(MAX_INT - MIN_INT) + MIN_INT);
                        break;
                }
            }

            switch (state)
            {
                case NOT_ORDERED:
                    break;
                case ASCENDING_ORDER:
                    array.Sort();
                    break;
                case DESCENDING_ORDER:
                    array.Sort();
                    array.Reverse();
                    break;
            }
        }

        private string GetRandomString(Random random)
        {
            char[] chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();
            int size = random.Next(1, MAX_STRING_SIZE);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                int index = random.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }

        public long[] ExecuteTest()
        {
            long[] result = new long[REPETITIONS];
            for (int i = 0; i < REPETITIONS; i++)
            {
                result[i] = DoRepetition();
            }
            isDone = true;
            return result;
        }

        private long DoRepetition()
        {
            Stopwatch sw = Stopwatch.StartNew();
            switch (algorithm)
            {
                case SELECTION_SORT:
                    sw.Start();
                    SelectionSort();
                    sw.Stop();
                    break;
                case INSERTION_SORT:
                    sw.Start();
                    InsertionSort();
                    sw.Stop();
                    break;
            }
            
            double time = sw.Elapsed.TotalMilliseconds;
            return (long)time;
        }

        public void InsertionSort()
        {
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = i; j >= 1 && array[j - 1].CompareTo(array[j]) > 0; j--)
                {
                    if (array[j - 1].CompareTo(array[j]) > 0)
                    {
                        dynamic temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }
        public void SelectionSort()
        {
            int pos_min = 0;
            dynamic temp;

            for (int i = 0; i < array.Count; i++)
            {
                pos_min = i;
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[j].CompareTo(array[i]) < 0)
                    {
                        pos_min = j;
                        if (pos_min != i)
                        {
                            temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
                    }
                }
            }
        }
        public override string ToString()
        {
            string[] sort = new string[] { "", "Selection sort", "Insertion sort" };
            string[] type = new string[] { "", "Int 32", "String", "Double", "Int 64" };
            string[] state = new string[] { "", "Not ordered", "Ascending order", "Descending order" };

            return sort[this.algorithm] + "," + type[this.datatype] + "," + state[this.state] + "," + SIZES[this.length];
        }
    }
}
