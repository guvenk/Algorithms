using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    // https://www.geeksforgeeks.org/bridge-in-a-graph/
    // Check if removing a given edge disconnects a graph
    // https://www.geeksforgeeks.org/check-removing-given-edge-disconnects-given-graph/
    // graph.IsBridge(2, 3)
    internal class FindBridgeNodes
    {
        public int FirstVertex { get; internal set; }
        public static Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

        public FindBridgeNodes(int firstVertex)
        {
            FirstVertex = firstVertex;
        }

        public void AddEdge(int v, int w)
        {
            if (adj.Keys.Contains(v))
                adj[v].Add(w);
            else
                adj.Add(v, new List<int>() { w });

            if (adj.Keys.Contains(w))
                adj[w].Add(v);
            else
                adj.Add(w, new List<int>() { v });
        }

        public void RemoveEdge(int v, int w)
        {
            adj[v].Remove(w);
            adj[w].Remove(v);
        }

        private void DFS(int v, Dictionary<int, bool> visited)
        {
            visited[v] = true;

            List<int> vList = adj[v];
            foreach (var i in vList)
                if (!visited[i])
                    DFS(i, visited);
        }

        private bool IsConnected()
        {
            Dictionary<int, bool> visited = new Dictionary<int, bool>();
            foreach (var item in adj)
                visited.Add(item.Key, false);

            // Find all reachable vertices from first vertex 
            DFS(FirstVertex, visited);

            // If set of reachable vertices includes all, 
            // return true. 
            foreach (var i in visited)
                if (i.Value == false)
                    return false;

            return true;
        }

        public bool IsBridge(int u, int v)
        {
            // Remove edge from undirected graph
            RemoveEdge(u, v);

            bool res = IsConnected();

            // Adding the edge back 
            AddEdge(u, v);

            // Return true if graph becomes disconnected 
            // after removing the edge. 
            return !res;
        }
    }
}
