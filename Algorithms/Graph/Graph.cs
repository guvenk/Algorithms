using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph
{
    public class Graph
    {
        private Dictionary<int, List<int>> _neighbors;

        bool IsCyclic(int node, bool[] visited, int parent)
        {
            // for undirected
            visited[node] = true;

            foreach (int neighbor in _neighbors[node])
            {
                if (!visited[neighbor])
                {
                    if (IsCyclic(neighbor, visited, node))
                        return true;
                }
                else if (neighbor != parent) // we have seen a node which we visited before and its not where we just came from (which is parent)
                {
                    return true;
                }
            }

            return false;
        }

        public void BuildGraph(int[][] edges)
        {
            // for undirected
            _neighbors = new Dictionary<int, List<int>>();

            for (int i = 0; i < edges.Length; i++)
            {
                if (!_neighbors.ContainsKey(edges[i][0]))
                    _neighbors.Add(edges[i][0], new List<int>());

                if (!_neighbors.ContainsKey(edges[i][1]))
                    _neighbors.Add(edges[i][1], new List<int>());

                _neighbors[edges[i][0]].Add(edges[i][1]);
                _neighbors[edges[i][1]].Add(edges[i][0]);
            }

        }
    }
}
