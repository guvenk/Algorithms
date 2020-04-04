using System;
using System.Collections.Generic;
using System.Linq;
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

        // ******************* ANOTHER IMPLEMENTATION **********************

        // this one takes not only x but also y coordinate into consideration while printing the result.
        public IList<IList<int>> VerticalTraversal2(TreeNode root)
        {
            var valsDict = new Dictionary<int, List<(int, int)>>();

            AddValue(valsDict, root, 0, 0);

            IList<IList<int>> resultSet = new List<IList<int>>();

            for (int i = 0; i < valsDict.Count; i++)
            {
                resultSet.Add(new List<int>());
            }

            var min = valsDict.Keys.Min();

            foreach (var val in valsDict)
            {
                var index = val.Key + -1 * min;
                resultSet[index] = (((val.Value.OrderBy(v => v.Item1)).OrderByDescending(y => y.Item2)).Select(i => i.Item1)).ToList();
            }

            return resultSet;
        }

        private void AddValue(Dictionary<int, List<(int, int)>> dict, TreeNode node, int x, int y)
        {
            if (node == null)
            {
                return;
            }

            if (!dict.ContainsKey(x))
            {
                dict[x] = new List<(int, int)>();
            }

            dict[x].Add((node.val, y));
            AddValue(dict, node.left, x - 1, y - 1);
            AddValue(dict, node.right, x + 1, y - 1);
        }
    }
}
