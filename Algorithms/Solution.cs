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

            var re = s.CanFinish(2, new int[][] {
                new int[] { 0, 1 }
            });

            Console.WriteLine(re);

            Console.WriteLine("Finished");
            Console.ReadKey();
        }

        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            _graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < prerequisites.Length; i++)
            {
                var node = prerequisites[i];
                if (!_graph.ContainsKey(node[0]))
                    _graph.Add(node[0], new List<int>());

                _graph[node[0]].Add(node[1]);

            }

            _visited = new bool[numCourses];
            bool[] path = new bool[numCourses];

            foreach (var node in _graph)
                if (HasCycle(path, node.Key))
                    return false;

            return true;

        }

        private bool[] _visited;
        private Dictionary<int, List<int>> _graph;

        private bool HasCycle(bool[] path, int node)
        {
            if (_visited[node])
                return false;

            if (path[node]) return true;

            if (!_graph.ContainsKey(node)) return false;

            path[node] = true;
            foreach (var neighbor in _graph[node])
                if (HasCycle(path, neighbor)) return true;
            path[node] = false;

            _visited[node] = true;

            return false;
        }


    }

}