
namespace Algorithms
{
    public class Node
    {
        public int val;
        public Node left, right, next;

        public Node(int item)
        {
            val = item;
            left = right = next = null;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
