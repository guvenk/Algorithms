using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class GraphBFS
    {
        public Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

        public void addEdge(int v, int w)
        {
            if (adj.Keys.Contains(v))
                adj[v].Add(w);
            else
                adj.Add(v, new List<int>() { w });
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

                if (adj.Keys.Contains(num))
                {
                    List<int> neighbors = adj[num];
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

            g.addEdge(1, 4);
            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(1, 2);
            g.addEdge(2, 0);
            g.addEdge(2, 3);

            g.BFS(2);
        }

    }
}
