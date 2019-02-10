﻿using System;
using System.Collections;
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
        public const int INT_64 = 4;

        public const int NOT_ORDERED = 1;
        public const int ASCENDING_ORDER = 2;
        public const int DESCENDING_ORDER = 3;

        public const int MIN_INT = -10000;
        public const int MAX_INT = 10000;

        public const int MAX_STRING_SIZE = 1000;

        public static readonly int[] SIZES = new int[] {0, 100, 1000, 10000 };

        private int algorithm;
        private int datatype;
        private int state;
        private int length;
        private long time;

        private IList array;


        public Treatment(int [] values)
        {
            algorithm = values[0];
            datatype = values[1];
            state = values[2];
            length = values[3];

            InitArray();
            FillArray(new Random());
        }

        private void InitArray()
        {
            switch(datatype)
            {
                case INT_32:
                    array = new int[SIZES[length]];
                    break;

                case STRING:
                    array = new string[SIZES[length]];
                    break;

                case DOUBLE:
                    array = new double[SIZES[length]];
                    break;

                case INT_64:
                    array = new long[SIZES[length]];
                    break;
            }            
        }

        private void FillArray(Random random)
        {
            for (int i = 0; i < array.Count; i++)
            {
                switch (datatype)
                {
                    case INT_32:
                        array[i] = random.Next(MIN_INT, MAX_INT);
                        break;

                    case STRING:
                        array[i] = GetRandomString(random);
                        break;

                    case DOUBLE:
                        array[i] = random.NextDouble() * (MAX_INT - MIN_INT) + MIN_INT;
                        break;

                    case INT_64:
                        array[i] = (long)random.Next(MIN_INT, MAX_INT);
                        break;
                }
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
