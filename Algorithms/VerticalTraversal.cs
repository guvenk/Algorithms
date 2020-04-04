using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class VerticalTraversalClass
    {
        public static void Print()
        {
            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.right.left = new TreeNode(6);
            root.right.right = new TreeNode(7);
            root.right.left.right = new TreeNode(8);
            root.right.right.right = new TreeNode(9);
            Console.WriteLine("Vertical Order traversal is");
            PrintVerticalOrder(root);
        }

        static void PrintVerticalOrder(TreeNode root)
        {
            SortedDictionary<int, List<int>> verticalOrders = new SortedDictionary<int, List<int>>();
            int hd = 0;
            GetVerticalOrder(root, hd, verticalOrders);
            foreach (var list in verticalOrders)
            {
                foreach (var item in list.Value)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
        }

        static void GetVerticalOrder(TreeNode root, int horDist, SortedDictionary<int, List<int>> dictionary)
        {
            // Base case 
            if (root == null)
                return;

            if (dictionary.ContainsKey(horDist))
                dictionary[horDist].Add(root.val);
            else
            {
                dictionary.Add(horDist, new List<int> { root.val });

            }

            // Store current node in dictionary

            // Store nodes in left subtree 
            GetVerticalOrder(root.left, horDist - 1, dictionary);

            // Store nodes in right subtree 
            GetVerticalOrder(root.right, horDist + 1, dictionary);
        }

        public IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            SortedDictionary<int, List<int>> verticalOrders = new SortedDictionary<int, List<int>>();
            int horizontalDist = 0;

            GetVerticalOrder(root, horizontalDist, verticalOrders);
            var result = new List<IList<int>>();
            foreach (var item in verticalOrders)
            {
                item.Value.Sort();
                result.Add(item.Value);
            }

            return result;
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            // Constructor 
            public TreeNode(int data)
            {
                val = data;
                left = null;
                right = null;
            }
        }
    }
}
