using System;

namespace Algorithms
{
    public class Digraph
    {
        private readonly int V;
        private int E;
        private Bag<int>[] Adj;

        public Digraph(int v)
        {
            this.V = v;
            this.E = 0;
            Adj = new Bag<int>[V];

            for (int i = 0; i < v; i++)
                Adj[i] = new Bag<int>();
        }

        public int GetV()
        {
            return V;
        }

        public int GetE()
        {
            return E;
        }

        public void AddEdge(int v, int w)
        {
            Adj[v].Add(w);
            E++;
        }

        public IEnumerable<int> GetAdj(int v)
        {
            return Adj[v];
        }

        public Digraph Reverse()
        {
            var r = new Digraph(V);
            for (int v = 0; v < V; v++)
                foreach (int w in Adj[v])
                    r.AddEdge(w, v);

            return r;
        }
    }

}