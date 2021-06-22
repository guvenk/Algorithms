using System.Collections.Generic;

namespace Algorithms
{
    public class ListWithFastAdding
    {
        List<int> _nums = new List<int>();

        // adds in log n time
        public void AddNum(int num)
        {
            int position = _nums.BinarySearch(num);

            if (position < 0)
                position = ~position;

            _nums.Insert(position, num);
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
