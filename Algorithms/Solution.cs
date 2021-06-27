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

            int[][] abc = new int[][] {
                new int[]{ 1, 0 },
                new int[]{ 2, 0 },
                new int[]{ 3, 1 },
                new int[]{ 3, 2 }
            };

            //FreqStack freqStack = new FreqStack();
            //freqStack.Push(5); // The stack is [5]
            //freqStack.Push(7); // The stack is [5,7]
            //freqStack.Push(5); // The stack is [5,7,5]
            //freqStack.Push(7); // The stack is [5,7,5,7]
            //freqStack.Push(4); // The stack is [5,7,5,7,4]
            //freqStack.Push(5); // The stack is [5,7,5,7,4,5]
            //var re = freqStack.Pop();   // return 5, as 5 is the most frequent. The stack becomes [5,7,5,7,4].
            //Console.WriteLine(re);
            //re = freqStack.Pop();   // return 7, as 5 and 7 is the most frequent, but 7 is closest to the top. The stack becomes [5,7,5,4].
            //Console.WriteLine(re);
            //re = freqStack.Pop();   // return 5, as 5 is the most frequent. The stack becomes [5,7,4].
            //Console.WriteLine(re);
            //re = freqStack.Pop();   // return 4, as 4, 5 and 7 is the most frequent, but 4 is closest to the top. The stack becomes [5,7].
            //Console.WriteLine(re);

            //re = freqStack.Pop();
            //Console.WriteLine(re);

            //re = freqStack.Pop();
            //Console.WriteLine(re);

            int[] input = new[] { 1, 0, 0, 1, 0, 0, 1, 0 };
            int[] vs = s.PrisonAfterNDays(input, 1000000000);
            Console.WriteLine(vs);
            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        //  Input: s = "ababcbacadefegdehijhklij"
        //  Output: [9,7,8]
        //  The partition is "ababcbaca", "defegde", "hijhklij".
        public IList<int> PartitionLabels(string s)
        {
            int[] last = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                last[s[i] - 'a'] = i;
            }

            var list = new List<int>();
            int j = 0, anchor = 0;

            for (int i = 0; i < s.Length; i++)
            {
                j = Math.Max(j, last[s[i] - 'a']);
                if (i == j)
                {
                    list.Add(i - anchor + 1);
                    anchor = i + 1;
                }
            }

            return list;

        }

        //Day 0: [0, 1, 0, 1, 1, 0, 0, 1]
        //Day 1: [0, 1, 1, 0, 0, 0, 0, 0]
        //Day 2: [0, 0, 0, 0, 1, 1, 1, 0]
        //Day 3: [0, 1, 1, 0, 0, 1, 0, 0]
        //Day 4: [0, 0, 0, 0, 0, 1, 0, 0]
        //Day 5: [0, 1, 1, 1, 0, 1, 0, 0]
        //Day 6: [0, 0, 1, 0, 1, 1, 0, 0]
        //Day 7: [0, 0, 1, 1, 0, 0, 0, 0]
        public int[] PrisonAfterNDays(int[] cells, int n)
        {
            bool isFastForwarded = false;
            var dict = new Dictionary<string, int>();

            var temp = new int[cells.Length];
            cells.CopyTo(temp, 0);

            while (n > 0)
            {
                if (!isFastForwarded)
                {
                    string state = string.Join("", cells);
                    if (dict.ContainsKey(state))
                    {
                        n %= dict[state] - n;
                        isFastForwarded = true;
                    }
                    else
                        dict.Add(state, n);
                }
                if (n > 0)
                {
                    n--;
                    NextDay(cells, temp);
                }
            }

            return cells;
        }

        private static void NextDay(int[] cells, int[] temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                if (i > 0 && i < temp.Length - 1 && cells[i - 1] == cells[i + 1])
                    temp[i] = 1;
                else
                    temp[i] = 0;
            }
            temp.CopyTo(cells, 0);
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