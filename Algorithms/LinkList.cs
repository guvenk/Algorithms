using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class LinkList
    {
        public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            var vA = new HashSet<ListNode>();
            var vB = new HashSet<ListNode>();

            while (headA != null || headB != null)
            {
                if (headA != null && headB != null && headA == headB)
                    return headA;
                if (vA.Contains(headB))
                    return headB;
                if (vB.Contains(headA))
                    return headA;

                if (headA != null)
                {
                    vA.Add(headA);
                    headA = headA.next;
                }

                if (headB != null)
                {
                    vB.Add(headB);
                    headB = headB.next;
                }
            }

            return null;
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists == null || lists.Length == 0)
                return null;

            return Merge(lists, 0, lists.Length - 1);

            // print result
            //while (res != null)
            //{
            //    Console.Write(res.val + " ");
            //    res = res.next;
            //}
        }

        public ListNode Merge(ListNode[] lists, int i, int j)
        {
            if (j == i)
                return lists[i];
            else
            {
                int mid = i + (j - i) / 2;

                var left = Merge(lists, i, mid);
                var right = Merge(lists, mid + 1, j);

                return MergeTwoLists(left, right);
            }
        }

        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            var curr = new ListNode(0);
            var dummy = curr;
            while (l1 != null && l2 != null)
            {
                if (l1.val >= l2.val)
                {
                    curr.next = l2;
                    l2 = l2.next;
                }
                else if (l2.val > l1.val)
                {
                    curr.next = l1;
                    l1 = l1.next;
                }
                curr = curr.next;
            }

            curr.next = l2 is null ? l1 : l2;

            return dummy.next;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var a = ReverseList(l1);
            var b = ReverseList(l2);

            var c = ReverseList(AddTwoNumbersEasy(a, b));

            return c;
        }

        public static ListNode AddTwoNumbersEasy(ListNode l1, ListNode l2)
        {
            ListNode dummyHead = new ListNode(0);
            var hand = 0;
            var curr = dummyHead;

            while (l1 != null || l2 != null)
            {
                int x = (l1 != null) ? l1.val : 0;
                int y = (l2 != null) ? l2.val : 0;
                int sum = hand + x + y;
                hand = sum / 10;

                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
            }
            if (hand > 0)
            {
                curr.next = new ListNode(hand);
            }

            return dummyHead.next;
        }

        public static ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            while (head != null)
            {
                var temp = head.next;
                head.next = prev;
                prev = head;
                head = temp;
            }
            return prev;
        }

        public static bool HasCycle(ListNode head)
        {
            if (head is null) return false;
            var p1 = head;
            var p2 = head;

            while (p1.next != null && p2.next != null && p2.next.next != null)
            {
                p1 = p1.next;
                p2 = p2.next.next;

                if (p1 == p2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
