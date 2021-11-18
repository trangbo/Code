using System;

namespace Algorithms
{
    public class DirectedDFS
    {
        private bool[] Marked;

        public DirectedDFS(Digraph g, int s)
        {
            Marked = new bool[g.GetV()];
            Dfs(g, s);
        }

        public DirectedDFS(Digraph g, IEnumerable<int> sources)
        {
            Marked = new bool[g.GetV()];

            foreach (int s in sources)
                if (!Marked[s])
                    Dfs(g, s);
        }

        private void Dfs(Digraph g, int v)
        {
            Marked[v] = true;

            foreach (int w in g.GetAdj(v))
                if (!Marked[w])
                    Dfs(g, w);
        }
        public bool IfMarked(int v)
        {
            return Marked[v];
        }

        public static void Main(string[] args)
        {
            Digraph G = new Digraph(new In(args[0]));
            Bag<Integer> sources = new Bag<Integer>();
            for (int i = 1; i < args.length; i++)
                sources.add(Integer.parseInt(args[i]));
            DirectedDFS reachable = new DirectedDFS(G, sources);
            for (int v = 0; v < G.V(); v++)
                if (reachable.marked(v)) StdOut.print(v + " ");
            StdOut.println();
        }

    }
}
