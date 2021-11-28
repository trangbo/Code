using System;

namespace Algorithms
{
    public class DepthFirstPaths
    {
        private bool[] Marked;  // Has dfs() called for this vertex?
        private int[] EdgeTo;   // last vertex on known path to this vertex
        private readonly int S;

        public DepthFirstPaths(Graph g, int s)
        {
            Marked = new bool[g.GetV()];
            EdgeTo = new int[g.GetV()];
            this.S = s;
            Dfs(g, s);
        }

        private void Dfs(Graph g, int v)
        {
            Marked[v] = true;

            foreach (int w in g.GetAdj(v))
            {
                if (!Marked[w])
                {
                    EdgeTo[w] = v;
                    Dfs(g, w);
                }  
            }
        }

        public bool HasPathTo(int v)
        {
            return Marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
                return null;

            var path = new Stack<int>();

            for (int x = v; x != S; x = EdgeTo[x])
                path.Push(x);

            path.Push(S);

            return path;
        }
    }
}
