using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class BST
    {
        private Node root;
        public Queue<Node> queue;

        public BST()
        {
            root = null;
        }

        // ------
        public BST(Node root)
        {
            queue = new Queue<Node>();
            InorderRecursive(root);
        }

        public Node Next() => queue.Dequeue();

        public bool HasNext() => queue.Count > 0;
        // ------

        public void Insert(int key)
        {
            root = InsertRecursive(root, key);
        }

        private Node InsertRecursive(Node root, int key)
        {

            /* If the tree is empty, return a new node */
            if (root == null)
            {
                root = new Node(key);
                return root;
            }

            /* Otherwise, recur down the tree */
            if (key < root.val)
                root.left = InsertRecursive(root.left, key);
            else if (key > root.val)
                root.right = InsertRecursive(root.right, key);

            /* return the (unchanged) node pointer */
            return root;
        }

        public void Inorder()
        {
            InorderRecursive(root);
        }

        private void InorderRecursive(Node node)
        {
            if (node != null)
            {
                InorderRecursive(node.left);
                queue.Enqueue(node);
                //Console.WriteLine(node.key);
                InorderRecursive(node.right);
            }
        }

        public static void USAGE()
        {
            BST tree = new BST();

            /* Let us create following BST 
                  50 
               /     \ 
              30      70 
             /  \    /  \ 
           20   40  60   80 */
            tree.Insert(50);
            tree.Insert(30);
            tree.Insert(20);
            tree.Insert(40);
            tree.Insert(70);
            tree.Insert(60);
            tree.Insert(80);

            // print inorder traversal of the BST 
            tree.Inorder();
        }
    }
}
