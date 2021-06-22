using System.Collections.Generic;

namespace Algorithms
{
    public class FastList<T>
    {
        private readonly List<T> _list;

        public FastList() => _list = new List<T>();

        public void Add(T item)
        {
            int insertIndex = _list.BinarySearch(item);
            if (insertIndex < 0) insertIndex = ~insertIndex;
            _list.Insert(insertIndex, item);
        }

        public T this[int index] => _list[index];

        public bool Remove(T item)
        {
            int index = _list.BinarySearch(item);
            if (index < 0) return false;
            _list.RemoveAt(index);
            return true;
        }

        // GETS the middle number or the average of 2 numbers in the middle
        public double Median(FastList<int> list)
        {
            int n = _list.Count;
            double median = (list[n / 2] + list[(n - 1) / 2]) / 2.0;
            return median;
        }
    }

    // USAGE 
    //MySortedList<int> list = new MySortedList<int>();
    //list.Add(16);
    //list.Add(4);
    //list.Add(166755);
    //list.Add(8);
    //list.Add(6);
    //list.Add(134546);
    //list.Add(5);
    //list.Add(1345);
    //list.Add(1345);
    //list.Add(1345);

    //  double median = MySortedList<int>.Median(list);
    //      Console.WriteLine(median);

    //  for (int i = 0; i<list.Count; i++)
    //      Console.Write(list[i] + " ");

}
