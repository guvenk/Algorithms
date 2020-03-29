using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    public class HeapNode
    {
        public int Value { get; set; }
        public int Index { get; set; }
    }

    public class MaxHeap
    {
        HeapNode[] arr;
        int count;

        private int GetLeftChild(int pos)
        {
            int l = 2 * pos + 1;
            return l >= count ? -1 : l;
        }

        private int GetRightChild(int pos)
        {
            int r = 2 * pos + 2;
            return r >= count ? -1 : r;
        }

        public void Heapify(List<int> num, int n)
        {
            arr = new HeapNode[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new HeapNode
                {
                    Value = num[i],
                    Index = i
                };
            }
            count = n;

            for (int i = (count - 1) / 2; i >= 0; i--)
            {
                HeapifyDown(i);
            }
        }
        public void HeapifyDown(int pos)
        {
            int l = GetLeftChild(pos);
            int r = GetRightChild(pos);
            int max = pos;
            if (l != -1 && arr[max].Value < arr[l].Value)
                max = l;
            if (r != -1 && arr[max].Value < arr[r].Value)
                max = r;
            if (max != pos)
            {
                HeapNode temp = arr[pos];
                arr[pos] = arr[max];
                arr[max] = temp;
                HeapifyDown(max);
            }
        }
        public HeapNode GetMax()
        {
            return arr[0];
        }

        public void ChangeMax(int newValue)
        {
            HeapNode data = arr[0];
            arr[0].Value = newValue;
            HeapifyDown(0);
        }
    }

    public class Result
    {
        // usage
        public static int minSum(List<int> num, int k)
        {
            MaxHeap heap = new MaxHeap();
            // fill the heap.
            heap.Heapify(num, num.Count);
            HeapNode data;

            for (int i = 0; i < k; i++)
            {
                data = heap.GetMax();
                int newValue = (int)Math.Ceiling(num[data.Index] / 2.0);
                num[data.Index] = newValue;
                heap.ChangeMax(newValue);
            }

            return num.Sum();
        }
    }
}
