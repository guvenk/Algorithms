using System;

namespace Algorithms
{
    public class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void printLevelOrder()
        {
            int h = height(root);
            int i;
            for (i = 1; i <= h; i++)
                printGivenLevel(root, i);
        }

        void printGivenLevel(Node root, int level)
        {
            if (root == null)
                return;
            if (level == 1)
                Console.Write(root.data + " ");
            else if (level > 1)
            {
                printGivenLevel(root.left, level - 1);
                printGivenLevel(root.right, level - 1);
            }
        }

        int height(Node root)
        {
            if (root == null)
                return 0;
            else
            {
                int lheight = height(root.left);
                int rheight = height(root.right);

                return Math.Max(lheight, rheight) + 1;
            }
        }

        void Usage()
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(1);
            tree.root.left = new Node(2);
            tree.root.right = new Node(3);
            tree.root.left.left = new Node(4);
            tree.root.left.right = new Node(5);

            Console.WriteLine("Level order traversal of binary tree is: ");
            tree.printLevelOrder();
        }
    }

}
