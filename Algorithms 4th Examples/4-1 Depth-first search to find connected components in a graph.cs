using System;

namespace Algorithms
{
    public class CC
    {
        private bool[] Marked;
        private int[] Id;
        private int count;

        public CC(Graph g)
        {
            Marked = new bool[g.GetV()];
            Id = new int[g.GetV()];

            for (int s = 0; s < g.GetV(); s++)
            {
                if (!Marked[s])
                {
                    Dfs(g, s);
                    count++;
                }
            }
        }

        private void Dfs(Graph g, int v)
        {
            Marked[v] = true;
            Id[v] = count;

            foreach (int w in g.GetAdj(v))
            {
                if (!Marked[w])
                    Dfs(g, w);
            }
        }

        public bool Connected(int v, int w)
        {
            return Id[v] == Id[w];
        }

        public int GetId(int v)
        {
            return Id[v];
        }

        public int GetCount()
        {
            return count;
        }
    }
}
