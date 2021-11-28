using System;

namespace Algorithms
{
    public class TwoColor
    {
        private bool[] Marked;
        private bool[] Color;
        private bool IsTwoColorable = true;

        public TwoColor(Graph g)
        {
            Marked = new bool[g.GetV()];
            Color = new bool[g.GetV()];

            for (int s = 0; s < g.GetV(); s++)
            {
                if (!Marked[s])
                    Dfs(g, s);
            }
        }

        private void Dfs(Graph g, int v)
        {
            Marked[v] = true;

            foreach (int w in g.GetAdj(v))
            {
                if (!Marked[w])
                {
                    Color[w] = !Color[v];
                    Dfs(g, w);
                }
                else if (Color[w] == Color[v])
                    IsTwoColorable = false;
            }
        }
    }
}
