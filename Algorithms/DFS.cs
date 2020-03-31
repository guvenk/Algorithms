using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class GraphDFS
    {
        private readonly int V; // No. of vertices  

        private readonly List<int>[] neighbours;

        // Constructor  
        GraphDFS(int v)
        {
            V = v;
            neighbours = new List<int>[v];
            for (int i = 0; i < v; ++i)
                neighbours[i] = new List<int>();
        }

        //Function to Add an edge into the graph  
        void AddEdge(int v, int w)
        {
            neighbours[v].Add(w); // Add w to v's list.  
        }

        // A function used by DFS  
        void DFSUtil(int v, bool[] visited)
        {
            // Mark the current node as visited 
            // and print it  
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices  
            // adjacent to this vertex  
            List<int> vList = neighbours[v];
            foreach (var n in vList)
            {
                if (!visited[n])
                    DFSUtil(n, visited);
            }
        }

        // Driver Code 
        public static void Usage()
        {
            int totalVertice = 4;
            GraphDFS g = new GraphDFS(totalVertice);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Following is Depth First Traversal " +
                              "(starting from vertex 2)");

            bool[] visited = new bool[totalVertice];

            g.DFSUtil(2, visited);

            Console.ReadKey();
        }
    }
}
