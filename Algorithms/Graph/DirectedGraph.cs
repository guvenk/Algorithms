using System;
using System.Collections.Generic;

namespace Algorithms.Graph
{
    public class DirectedGraph
    {
        private Dictionary<int, List<int>> adj;
        bool[] visited;
        private int numOfNodes = 0;
        // Recursive
        public bool HasCycle(int node, bool[] path)
        {
            if (visited[node])
                return false;

            if (path[node]) 
                return true;

            if (adj.ContainsKey(node))
            {
                path[node] = true;
                foreach (var neighbor in adj[node])
                    if (HasCycle(neighbor, path))
                        return true;
                path[node] = false;
            }

            visited[node] = true;

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
                }
            }

            return seen.Count != numOfNodes;
        }
    }
}
