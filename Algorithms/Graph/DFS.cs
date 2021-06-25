using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class GraphDFS
    {
        private readonly int V; // No. of vertices  

        private readonly List<int>[] neighbours;

        // Constructor  
        private GraphDFS(int v)
        {
            V = v;
            neighbours = new List<int>[v];
            for (int i = 0; i < v; ++i)
                neighbours[i] = new List<int>();
        }

        //Function to Add an edge into the graph  
        private void AddEdge(int v, int w)
        {
            neighbours[v].Add(w); // Add w to v's list.  
        }

        // A function used by DFS  
        private void DFS(int v, bool[] visited)
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
        private void Usage()
        {
            char[][] grid = new char[][]
            {
                new char [] { '1','0','0','1' },
                new char [] { '0','0','1','1' },
                new char [] { '0','0','0','0' },
                new char [] { '1','0','1','1' },
            };
            var result = SimpleDFS.NumOfIslands(grid);
            Console.WriteLine(result);
        }

        public static int NumOfIslands(char[][] grid)
        {
            int count = 0;

            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[row].Length; col++)
                {
                    if (grid[row][col] == '1')
                    {
                        DFS(grid, row, col);
                        count++;
                    }
                }
            }

            return count;
        }

        private static void DFS(char[][] grid, int row, int col)
        {
            if (row < 0 || row == grid.Length
                || col < 0 || col == grid[row].Length
                || grid[row][col] == '0')
            {
                return;
            }
            grid[row][col] = '0';


            DFS(grid, row + 1, col);
            DFS(grid, row - 1, col);
            DFS(grid, row, col + 1);
            DFS(grid, row, col - 1);
        }

    }
}
