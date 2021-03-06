﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public class MinHeap<T> where T : IComparable
    {
        public List<T> elements = new List<T>();

        public T GetRoot() { return elements[0]; }

        public void Add(T item)
        {
            elements.Add(item);
            HeapifyUp(elements.Count - 1);
        }

        public void ReplaceMin(T x)
        {
            elements[0] = x;
            HeapifyDown(0);
        }

        public T PopMin()
        {
            T item = elements[0];
            elements[0] = elements[^1];
            elements.RemoveAt(elements.Count - 1);

            HeapifyDown(0);
            return item;
        }

        public void HeapifyUp(int index)
        {
            var parent = GetParent(index);
            if (parent >= 0 && elements[index].CompareTo(elements[parent]) < 0)
            {
                Swap(index, parent);

                HeapifyUp(parent);
            }
        }

        private void Swap(int i, int j)
        {
            var temp = elements[i];
            elements[i] = elements[j];
            elements[j] = temp;
        }

        public void HeapifyDown(int index)
        {
            var smallest = index;
            var left = GetLeft(index);
            var right = GetRight(index);

            if (left < elements.Count && elements[left].CompareTo(elements[index]) < 0)
                smallest = left;

            if (right < elements.Count && elements[right].CompareTo(elements[smallest]) < 0)
                smallest = right;

            if (smallest != index)
            {
                Swap(index, smallest);

                HeapifyDown(smallest);
            }
        }

        private int GetParent(int index)
        {
            if (index <= 0)
                return -1;
            return (index - 1) / 2;
        }

        private int GetLeft(int index) => 2 * index + 1;

        private int GetRight(int index) => 2 * index + 2;
    }
}
