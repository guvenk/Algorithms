using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class GraphBFS
    {
        public Dictionary<int, List<int>> neighbours = new Dictionary<int, List<int>>();

        public void AddEdge(int v, int w)
        {
            if (neighbours.Keys.Contains(v))
                neighbours[v].Add(w);
            else
                neighbours.Add(v, new List<int>() { w });
        }

        public void BFS(int num)
        {
            HashSet<int> visited = new HashSet<int>();
            Queue<int> queue = new Queue<int>();
            visited.Add(num);
            queue.Enqueue(num);

            while (queue.Count != 0)
            {
                num = queue.Dequeue();
                Console.Write(num + " ");

                if (neighbours.Keys.Contains(num))
                {
                    List<int> neighbors = neighbours[num];
                    foreach (var n in neighbors)
                    {
                        if (!visited.Contains(n))
                        {
                            visited.Add(n);
                            queue.Enqueue(n);
                        }
                    }
                }
            }
        }

        void Usage()
        {
            GraphBFS g = new GraphBFS();

            g.AddEdge(1, 4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);

            g.BFS(2);
        }

    }
}
