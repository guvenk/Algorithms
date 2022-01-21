using System;
using System.Text;
using System.Collections.Generic;

namespace Algorithms
{
    public class MinHeap
    {
        public List<int> items = new();

        public int GetRoot() => items[0];

        public void Add(int item)
        {
            items.Add(item);
            HeapifyUp(items.Count - 1);
        }

        public void ReplaceMin(int x)
        {
            items[0] = x;
            HeapifyDown();
        }

        public int PopMin()
        {
            int item = items[0];
            items[0] = items[^1];
            items.RemoveAt(items.Count - 1);
            HeapifyDown();

            return item;
        }

        public void HeapifyUp(int index)
        {
            var parent = GetParent(index);
            if (parent >= 0 && items[index].CompareTo(items[parent]) < 0)
            {
                Swap(index, parent);
                HeapifyUp(parent);
            }
        }

        public void HeapifyDown()
        {
            int index = 0;
            while (GetLeft(index) < items.Count)
            {
                var smallerChildIndex = GetLeft(index);
                var right = GetRight(index);

                if (right < items.Count && items[right].CompareTo(items[smallerChildIndex]) < 0)
                    smallerChildIndex = right;

                if (items[smallerChildIndex] < items[index])
                {
                    Swap(index, smallerChildIndex);
                    index = smallerChildIndex;
                }
            }
        }

        private void Swap(int i, int j)
        {
            var temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        private static int GetParent(int index)
        {
            if (index <= 0) return -1;
            return (index - 1) / 2;
        }

        private static int GetLeft(int index) => 2 * index + 1;

        private static int GetRight(int index) => 2 * index + 2;
    }
}
