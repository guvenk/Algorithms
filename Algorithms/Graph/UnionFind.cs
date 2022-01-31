using System;

namespace Algorithms
{
    // disjoint set
    public class UnionFind
    {
        private readonly int[] root;
        private readonly int[] rank;
        public int GroupCount { get; set; }

        public UnionFind(int size)
        {
            root = new int[size];
            rank = new int[size];
            GroupCount = size;
            for (int i = 0; i < size; i++)
            {
                root[i] = i;
                rank[i] = 1;
            }
        }

        private int Find(int x)
        {
            if (x != root[x])
                root[x] = Find(root[x]);
            return root[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);
            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                    root[rootY] = rootX;
                else if (rank[rootX] < rank[rootY])
                    root[rootX] = rootY;
                else
                {
                    root[rootY] = rootX;
                    rank[rootX] += 1;
                }
                GroupCount--;
            }
        }
    }
}
