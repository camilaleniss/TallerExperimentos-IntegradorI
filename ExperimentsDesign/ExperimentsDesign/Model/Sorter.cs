using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsDesign.Model
{
    class Sorter<T> : ISort<T>
    {
        public Sorter()
        {
        }

        public T[] InsertionSort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                //Corregir comparación
                for (int j=i; j>0 && array[j-1]>array[j]; j--)
                {
                    T temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }
            }
            return array;
        }

        public T[] SelectionSort(T[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                T menor = array[i];
                int which = i;
                for (int j =i+1; j < array.Length; j++)
                {
                    //Corregir comparación
                    if (array[j] < menor)
                    {
                        menor = array[j];
                        which = j;
                    }
                }
                T temp = array[i];
                array[i] = menor;
                array[which] = temp;
            }
            return array;
        }
        
    }
}
