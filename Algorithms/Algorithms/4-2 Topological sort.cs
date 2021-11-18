using System;

namespace Algorithms
{
    public class Topological
    {
        private IEnumerable<int> Order; // topological order

        public Topological(Digraph g)
        {
            var cycleFinder = new DirectedCycle(g);

            if (!cycleFinder.HasCycle())
            {
                var dfs = new DepthFirstOrder(g);
                Order = dfs.GetReversePost();
            }
        }

        public IEnumerable<int> GetOrder()
        {
            return Order
        }

        public bool IsDAG()
        {
            return Order == null;
        }

        public static void Main(string[] args)
        {
            // SymbolDigraph is same with SymbolGraph, just different name
            string filename = args[0];
            string separator = args[1];
            var sg = new SymbolDigraph(filename, separator);

            var top = new Topological(sg.G());

            foreach (int v in top.Order())
                Console.WriteLine(sg.name(v));
        }
    }
}
