using System;

namespace Algorithms
{
    public class EdgeWeightedGraph
    {
        private readonly int V; // number of vertices
        private int E;  // number of edges
        private Bag<Edge>[] Adj;    // adjacency lists

        public EdgeWeightedGraph(int v)
        {
            this.V = v;
            this.E = 0;
            Adj = new Bag<Edge>[v];

            for (int i = 0; i < v; i++)
                Adj[i] = new Bag<Edge>();
        }

        public EdgeWeightedGraph(In in) //Graph input

        public int GetV()
        {
            return V;
        }

        public int GetE()
        {
            return E;
        }

        public void AddEdge(Edge e)
        {
            int v = e.Either(), w = e.Other(v);
            Adj[v].Add(e);
            Adj[w].Add(e);
            E++;
        }

        public IEnumerable<Edge> GetAdj(int v)
        {
            return Adj[v];
        }

        public IEnumerable<Edge> Edges()
        {
            var b = new Bag<Edge>();

            for (int v = 0; v < V; v++)
                foreach (Edge e in Adj[v])
                    if (e.Other(v) > v)
                        b.Add(e);

            return b;
        }
    }
}
