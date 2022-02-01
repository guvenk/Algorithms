using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class Dijkstra
    {
        // find shortest distance to other nodes from node k
        // n is number of nodes
        // times[0] = node A
        // times[1] = node B
        // times[2] = Distance
        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            var graph = new Dictionary<int, List<int[]>>();
            foreach (var edge in times)
            {
                if (!graph.ContainsKey(edge[0]))
                    graph.Add(edge[0], new List<int[]>());
                graph[edge[0]].Add(new int[] { edge[1], edge[2] });
            }
            var heap = new SortedList<int, int>(new CustomComparer());
            heap.Add(0, k);

            var dist = new Dictionary<int, int>();

            while (heap.Count > 0)
            {
                (int d, int node) = heap.First();
                heap.RemoveAt(0);

                if (dist.ContainsKey(node))
                    continue;

                dist.Add(node, d);
                if (graph.ContainsKey(node))
                {
                    foreach (var edge in graph[node])
                    {
                        int neighbor = edge[0];
                        int d2 = edge[1];
                        if (!dist.ContainsKey(neighbor))
                            heap.Add(d + d2, neighbor);
                    }
                }
            }

            if (dist.Count != n)
                return -1;

            return dist.Values.Max();
        }

        public class CustomComparer : IComparer<int>
        {
            public int Compare(int x, int y) => x < y ? -1 : 1;
        }
    }
}
