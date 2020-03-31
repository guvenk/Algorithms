using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    // Check if removing a given edge disconnects a graph
    // graph.IsBridge(2, 3)
    class FindBridgeNodes
    {
        readonly int V;
        public int FirstVertex { get; internal set; }
        public static Dictionary<int, List<int>> adj = new Dictionary<int, List<int>>();

        public FindBridgeNodes(int v, int firstVertex)
        {
            V = v;
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

        void DFS(int v, bool[] visited)
        {
            visited[v] = true;

            List<int> vList = adj[v];
            foreach (var i in vList)
                if (!visited[i])
                    DFS(i, visited);
        }

        bool IsConnected()
        {
            bool[] visited = new bool[V];

            // Find all reachable vertices from first vertex 
            DFS(FirstVertex, visited);

            // If set of reachable vertices includes all, 
            // return true. 
            for (int i = 1; i < V; i++)
                if (visited[i] == false)
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
