using System;

namespace Algorithms
{
    public class KosarajuSCC
    {
        private bool[] Marked;  // reached vertices
        private int[] Id;    // component identifiers
        private int Count;  // number of strong components

        public KosarajuSCC(Digraph g)
        {
            Marked = new bool[g.GetV()];
            Id = new int[g.GetV()];
            var order = new DepthFirstOrder(g);

            foreach (int s in order.GetReversePost())
            {
                if (!Marked[s])
                {
                    Dfs(g, s);
                    Count++;
                }
            }
        }

        private void Dfs(Digraph g, int v)
        {
            Marked[v] = true;
            Id[v] = Count;

            foreach (int w in g.GetAdj(v))
                if (!Marked[w])
                    Dfs(g, w);
        }

        public bool StronglyConnected(int v, int w)
        {
            return Id[v] == Id[w];
        }

        public int GetId(int v)
        {
            return Id[v];
        }

        public int GetCount()
        {
            return Count;
        }
    }
}
