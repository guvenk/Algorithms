using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class Solution
    {
        public static void Main()
        {
            var s = new Solution();

            //var result = s.GenerateTrees(3);

            //Console.WriteLine(result);


            Console.ReadKey();
        }

        public void GetAll(ref int num)
        {
            num = 50;
        }

        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new List<TreeNode>();
            return Generate(1, n);
        }

        private IList<TreeNode> Generate(int start, int end)
        {
            var all = new List<TreeNode>();
            if (start > end)
            {
                all.Add(null);
                return all;
            }

            // pick up a root
            for (int i = start; i <= end; i++)
            {
                // all possible left subtrees if i is choosen to be a root
                var leftTrees = Generate(start, i - 1);

                // all possible right subtrees if i is choosen to be a root
                var rightTrees = Generate(i + 1, end);

                // connect left and right trees to the root i
                foreach (TreeNode l in leftTrees)
                {
                    foreach (TreeNode r in rightTrees)
                    {
                        var curr = new TreeNode(i)
                        {
                            left = l,
                            right = r
                        };
                        all.Add(curr);
                    }
                }
            }

            return all;
        }
    }
}
