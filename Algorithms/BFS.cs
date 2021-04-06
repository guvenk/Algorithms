using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class BFS
    {
        // Time Complexity: O(n^2) in worst case. For a skewed tree, printGivenLevel() takes O(n) time where n is the number of nodes in the skewed tree.So time complexity of printLevelOrder() is O(n) + O(n-1) + O(n-2) + .. + O(1) which is O(n^2). 
        // Space Complexity: O(n) in worst case. 
        private static void Usage()
        {
            BFS tree = new BFS();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            tree.PrintLevelOrder();
        }

        public Node root;
        public void PrintLevelOrder()
        {
            int rootHeight = GetHeight(root);

            for (int i = 1; i <= rootHeight; i++)
                PrintGivenLevel(root, i);
        }

        public void PrintGivenLevel(Node root,
                                           int level)
        {
            if (root == null)
                return;
            if (level == 1)
                Console.Write(root.data + " ");
            else if (level > 1)
            {
                PrintGivenLevel(root.left, level - 1);
                PrintGivenLevel(root.right, level - 1);
            }
        }
        public int GetHeight(Node root)
        {
            if (root == null)
                return 0;
            else
            {
                int lheight = GetHeight(root.left);
                int rheight = GetHeight(root.right);

                if (lheight > rheight)
                    return (lheight + 1);
                else
                    return (rheight + 1);
            }
        }


    }
    public class GraphBFS
    {
        //Time Complexity: O(n) where n is number of nodes in the binary tree
        //Space Complexity: O(n) where n is number of nodes in the binary tree

        public Dictionary<int, List<int>> neighbours = new Dictionary<int, List<int>>();

        public void AddEdge(int v, int w)
        {
            if (neighbours.Keys.Contains(v))
                neighbours[v].Add(w);
            else
                neighbours.Add(v, new List<int>() { w });
        }

        public void BFS(int num)
        {
            HashSet<int> visited = new HashSet<int> { num };

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(num);

            while (queue.Count != 0)
            {
                num = queue.Dequeue();
                Console.Write(num + " ");

                // check if it has neighbours
                if (neighbours.Keys.Contains(num))
                {
                    List<int> neighbors = neighbours[num];
                    foreach (var n in neighbors)
                    {
                        if (!visited.Contains(n))
                        {
                            visited.Add(n);
                            queue.Enqueue(n);
                        }
                    }
                }
            }
        }

        void Usage()
        {
            GraphBFS g = new GraphBFS();

            g.AddEdge(1, 4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);

            g.BFS(2);
        }

    }
}
