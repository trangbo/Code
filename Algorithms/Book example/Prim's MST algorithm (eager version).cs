using System;


namespace Algorithms
{
    public class PrimMST
    {
        private Edge[] EdgeTo;  // shortest edge from tree vertex
        private double[] DistTo;    // distTo[w] = edgeTo[w].weight()
        private bool[] Marked;  // true if v on tree
        private IndexMinPQ<double> Pq;  // eligible crossing edges

        public PrimMST(EdgeWeightedGraph g)
        {
            EdgeTo = new Edge[g.GetV()];
            DistTo = new double[g.GetV()];
            Marked = new bool[g.GetV()];

            for (int v = 0; v < g.GetV(); v++)
                DistTo[v] = double.PositiveInfinity;

            Pq = new IndexMinPQ<double>(g.GetV());

            DistTo[0] = 0.0;

            Pq.insert(0, 0.0);  // Initialize Pq with 0, weight 0

            while (!Pq.IsEmpty())
                Visit(g, Pq.delMin());  // Add closest vertex to tree
        }

        private void Visit(EdgeWeightedGraph g, int v)
        {
            // Add v to tree; update data structures
            Marked[v] = true;
            
            foreach (Edge e in g.GetAdj(v))
            {
                int w = e.Other(v);

                if (Marked[w])  // v-w is ineligible
                    continue;

                if (e.GetWeight() < DistTo[w])
                {
                    EdgeTo[w] = e;
                    DistTo[w] = e.GetWeight();

                    if (Pq.contains(w))
                        Pq.change(w, DistTo[w]);
                    else
                        Pq.insert(w, DistTo[w]);
                }
            }
        }
    }
}
