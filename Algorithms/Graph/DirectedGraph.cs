using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graph
{
    public class DirectedGraph
    {
        private Dictionary<int, List<int>> _neighbors;

        private bool HasCycle(int node, bool[] path, bool[] visited)
        {
            if (visited[node])
                return false;

            if (path[node]) return true;

            if (!_neighbors.ContainsKey(node)) return false;

            path[node] = true;
            foreach (var neighbor in _neighbors[node])
                if (HasCycle(neighbor, path, visited)) return true;
            path[node] = false;

            visited[node] = true;

            return false;
        }
    }
}
