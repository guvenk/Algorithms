using System.Collections.Generic;

namespace Algorithms.Graph
{
    public class UndirectedGraph
    {
        private Dictionary<int, List<int>> adj;
        private bool[] visited;
        private int numOfNodes = 0;

        // Recursive
        private bool HasCycle(int node, int parent)
        {
            visited[node] = true;

            foreach (int neighbor in adj[node])
            {
                if (!visited[neighbor])
                {
                    if (HasCycle(neighbor, node))
                        return true;
                }
                else if (neighbor != parent) // we have seen a node which we visited before and its not where we just came from (which is parent)
                    return true;
            }

            return false;
        }

        // Iterative
        public bool HasCycle(int startNode)
        {
            var stack = new Stack<int>();
            stack.Push(startNode);
            // Use a set to keep track of already seen nodes to
            // avoid infinite looping. 
            var seen = new HashSet<int>();
            seen.Add(startNode);

            // While there are nodes remaining on the stack...
            while (stack.Count > 0)
            {
                int node = stack.Pop(); // Take one off to visit.
                                        // Check for unseen neighbours of this node:
                foreach (var neighbour in adj[node])
                {
                    if (seen.Contains(neighbour))
                        return true; // Already seen this node.

                    // Otherwise, put this neighbour onto stack
                    // and record that it has been seen.
                    stack.Push(neighbour);
                    seen.Add(neighbour);
                    adj[neighbour].Remove(node);
                }
            }

            return seen.Count != numOfNodes;
        }

        public void BuildGraph(int[][] edges)
        {
            adj = new Dictionary<int, List<int>>();
            visited = new bool[edges.Length];

            for (int i = 0; i < edges.Length; i++)
            {
                if (!adj.ContainsKey(edges[i][0]))
                    adj.Add(edges[i][0], new List<int>());

                if (!adj.ContainsKey(edges[i][1]))
                    adj.Add(edges[i][1], new List<int>());

                adj[edges[i][0]].Add(edges[i][1]);
                adj[edges[i][1]].Add(edges[i][0]);
            }
        }
    }
}
