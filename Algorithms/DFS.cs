using System;
using System.Collections.Generic;

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
        void DFS(int v, bool[] visited)
        {
            // Mark the current node as visited 
            // and print it  
            visited[v] = true;
            Console.Write(v + " ");

            // Recur for all the vertices  
            // adjacent to this vertex  
            List<int> neighbourList = neighbours[v];
            foreach (var neighbour in neighbourList)
                if (!visited[neighbour])
                    DFS(neighbour, visited);
        }

        // Driver Code 
        public static void Usage()
        {
            int totalVertice = 4;
            GraphDFS g = new GraphDFS(totalVertice);
            bool[] visited = new bool[totalVertice];

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine("Following is Depth First Traversal " +
                              "(starting from vertex 2)");

            g.DFS(2, visited);

            Console.ReadKey();
        }
    }

    class SimplisticImplementationDFS
    {
        private readonly bool[][] visited;

        public SimplisticImplementationDFS(int size)
        {
            visited = new bool[size][];
        }

        void IsIsland(int i, int j)
        {
            visited[i][j] = true;

            var neighbours = GetNeighbours(i, j);
            foreach (var (I, J) in neighbours)
                if (!visited[I][J])
                    IsIsland(I, J);
        }

        private List<(int I, int J)> GetNeighbours(int i, int j)
        {
            var list = new List<(int I, int J)>();
            if (i != 0)
                list.Add((i - 1, j));

            if (i != visited.Length)
                list.Add((i + 1, j));

            if (j != 0)
                list.Add((i, j - 1));

            if (j != visited.Length)
                list.Add((i, j + 1));

            return list;
        }
    }        
}
