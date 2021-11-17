using System;

namespace Algorithms
{
    public class Edge : IComparable<Edge>
    {
        private readonly int V; // one vertex
        private readonly int W; // the other vertex
        private readonly double Weight; // edge weight

        public Edge(int v, int w, double weight)
        {
            this.V = v;
            this.W = w;
            this.Weight = weight;
        }

        public double GetWeight()
        {
            return Weight;
        }

        public int Either()
        {
            return V;
        }

        public int Other(int vertex)
        {
            if (vertex == V)
                return W;
            else if (vertex == W)
                return V;
            else
                throw new RuntimeArgumentHandle("Inconsistent edge");
        }

        public int CompareTo(Edge that)
        {
            if (this.GetWeight() < that.GetWeight())
                return -1;
            else if (this.GetWeight() > that.GetWeight())
                return +1;
            else
                return 0;
        }

        public string ToString()
        {
            return string.Format();
        }
    }
}
