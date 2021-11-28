using System;

namespace Algorithms
{
    public class LazyPrimMST
    {
        private bool[] Marked;  // MST vertices
        private Quene<Edge> Mst;    // MST edges
        private MinPQ<Edge> Pq; //Crossing (and ineligible) edges

        public LazyPrimMST(EdgeWeightedGraph g)
        {
            Pq = new MinPQ<Edge>();
            Marked = new bool[g.GetV()];
            Mst = new Quene<Edge>();

            Visit(g, 0); // assumes g is connected 

            while (!Pq.IsEmpty())
            {
                Edge e = Pq.DelMin();   // Get lowest-weight
                int v = e.Either(), w = e.Other(v); // edge from Pq

                if (Marked[v] && Marked[w])
                    continue;   // skip if ineligible

                Mst.EnQuene(e);

                if (!Marked[v])
                    Visit(g, v);

                if (!Marked[w])
                    Visit(g, w);
            }
        }

        private void Visit(EdgeWeightedGraph g, int v)
        {
            // Mark v and add to Pq all edges from v to unmarked vertices
            Marked[v] = true;

            foreach (Edge e in g.GetAdj(v))
                if (!Marked[e.Other(v)])
                    Pq.Insert(e);
        }

        public IEnumerable<Edge> GetEdges()
        {
            return Mst;
        }

        public double Weight()
    }
}
