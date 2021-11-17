using System;

namespace Algorithms
{
    public class Cycle
    {
        private bool[] Marked;
        private bool HasCycle;

        public Cycle(Graph g)
        {
            Marked = new bool[g.GetV()];

            for (int s = 0; s < g.GetV(); s++)
            {
                if (!Marked[s])
                    Dfs(g, s, s);
            }
        }

        private void Dfs(Graph g, int v, int u)
        {
            Marked[v] = true;

            foreach (int w in g.GetAdj(v))
            {
                if (!Marked[w])
                    Dfs(g, w, v);
                else if (w != u)
                    HasCycle = true;
            }
        }
    }
}
