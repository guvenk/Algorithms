using System;
using System.Linq;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    public class Solution
    {
        public static void Main()
        {
            var s = new Solution();



            var points = new int[3][];
            points[0] = new int[3] { 2, 1, 1 };
            points[1] = new int[3] { 2, 3, 1 };
            points[2] = new int[3] { 3, 4, 1 };

            //var res = s.NetworkDelayTime(points, 4, 2);
            //Console.WriteLine(res);

            Console.ReadKey();
        }



        public class FreqStack
        {
            readonly Dictionary<int, int> _freq;
            readonly Dictionary<int, Stack<int>> _group;
            int _maxFreq;

            public FreqStack()
            {
                _freq = new Dictionary<int, int>();
                _group = new Dictionary<int, Stack<int>>();
            }

            public void Push(int val)
            {
                if (!_freq.ContainsKey(val))
                    _freq.Add(val, 0);

                var freq = ++_freq[val];
                _maxFreq = Math.Max(_maxFreq, freq);

                if (!_group.ContainsKey(freq))
                    _group.Add(freq, new Stack<int>());

                _group[freq].Push(val);
            }

            public int Pop()
            {
                int x = _group[_maxFreq].Pop();
                _freq[x]--;

                if (_group[_maxFreq].Count == 0)
                    _maxFreq--;

                return x;
            }
        }
    }
}

