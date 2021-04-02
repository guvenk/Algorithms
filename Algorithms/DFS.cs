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

    public class SimpleDFS
    {
        private readonly bool[,] visited;
        private readonly int[,] matrix;
        private readonly int size = 0;

        public SimpleDFS(int matrixSize, int[,] arr)
        {
            size = matrixSize;
            visited = new bool[size, size];
            matrix = arr;
        }
        //USAGE
        //int[,] matrix = new int[,]
        //{
        //    { 1,0,0,1 },
        //    { 0,0,1,1 },
        //    { 0,0,0,0 },
        //    { 1,0,1,1 },
        //};

        //SimpleDFS test = new SimpleDFS(4, matrix);
        //var result = test.NumOfIslands();
        //Console.WriteLine(result);

        public int NumOfIslands()
        {
            int count = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (!visited[row, col] && matrix[row, col] == 1)
                    {
                        DFS(row, col);
                        count++;
                    }
                }
            }

            return count;
        }

        private void DFS(int row, int col)
        {
            visited[row, col] = true;

            var neighbours = GetNeighbours(row, col);
            foreach (var (I, J) in neighbours)
                if (!visited[I, J])
                    DFS(I, J);
        }

        private List<(int I, int J)> GetNeighbours(int i, int j)
        {
            var list = new List<(int I, int J)>();
            // if its inside matrix, not visited and equal to 1
            if (i > 0 && !visited[i - 1, j] && matrix[i - 1, j] == 1)
                list.Add((i - 1, j));

            if (i < size - 1 && !visited[i + 1, j] && matrix[i + 1, j] == 1)
                list.Add((i + 1, j));

            if (j > 0 && !visited[i, j - 1] && matrix[i, j - 1] == 1)
                list.Add((i, j - 1));

            if (j < size - 1 && !visited[i, j + 1] && matrix[i, j + 1] == 1)
                list.Add((i, j + 1));

            return list;
        }
    }
}
