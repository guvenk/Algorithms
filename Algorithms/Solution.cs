using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class Solution
    {
        public static void Main()
        {
            var tree = new Node(1)
            {
                left = new Node(2)
                {
                    left = new Node(4),
                    right = new Node(5)
                },
                right = new Node(3)
                {
                    left = new Node(6),
                    right = new Node(7)
                }
            };

            var sol = new Solution();
            //sol.BFSTree(tree);

            //var bfs = new BFS { Root = tree };
            //bfs.PrintLevelOrder();



            Console.ReadKey();
        }


        public Node Connect(Node root)
        {
            if (root is null)
                return null;
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var size = q.Count;
                for (int i = 0; i < size; i++)
                {
                    var node = q.Dequeue();

                    if (i < size - 1)
                        node.next = q.Peek();

                    if (node.left != null)
                        q.Enqueue(node.left);
                    if (node.right != null)
                        q.Enqueue(node.right);
                }
            }

            return root;
        }

    }
}
