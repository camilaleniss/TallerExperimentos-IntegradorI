using System;
using System.Collections.Generic;
using System.Text;

namespace ExperimentsDesign.Model
{
    public interface ISort<T>
    {
        T[] SelectionSort(T[] array);
        T[] InsertionSort(T[] array);

    }
}
