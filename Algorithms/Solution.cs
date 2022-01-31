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



            var points = new int[5][];
            points[0] = new int[2] { 0, 0 };
            points[1] = new int[2] { 2, 2 };
            points[2] = new int[2] { 3, 10 };
            points[3] = new int[2] { 5, 2 };
            points[4] = new int[2] { 7, 0 };
            var res = s.MinCostConnectPoints(points);
            Console.WriteLine(res);

            Console.ReadKey();
        }
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            graph = new Dictionary<int, IList<(int Target, int Cost)>>();
            dist = new Dictionary<int, int>();

        }
        Dictionary<int, IList<(int Target, int Cost)>> graph;
        Dictionary<int, int> dist;

        public int MinCostConnectPoints(int[][] points)
        {
            int total = 0;
            List<int[]> list = new();

            root = new int[points.Length];
            rank = new int[points.Length];

            for (int i = 0; i < root.Length; i++)
            {
                root[i] = i;
                rank[i] = 1;
            }

            for (int i = 0; i < points.Length - 1; i++)
                for (int j = i + 1; j < points.Length; j++)
                    list.Add(new int[] { i, j, Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]) });

            list.Sort((a, b) => a[2].CompareTo(b[2]));

            foreach (var item in list)
                if (Find(item[0]) != Find(item[1]))
                {
                    total += item[2];
                    Union(item[0], item[1]);
                }

            return total;
        }
        private int[] root = null;
        private int[] rank = null;
        private void Union(int x, int y)
        {
            int px = Find(x),
                py = Find(y);

            if (px != py)
            {
                if (rank[px] > rank[py])
                {
                    root[py] = px;
                }
                else if (rank[py] > rank[px])
                {
                    root[px] = py;
                }
                else
                {
                    root[py] = px;
                    rank[px]++;
                }
            }
        }

        private int Find(int x)
        {
            if (x != root[x])
                root[x] = Find(root[x]);

            return root[x];
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

