using System;

namespace Algorithms
{
    public class Graph
    {
        private readonly int V; // number of vertices
        private int E;  // number of edges
        private Bag<int>[] Adj; // adjacency lists

        public Graph(int v)
        {
            this.V = v;
            Adj = new Bag<int>[v];  // Create array of lists

            for (int i = 0; i < V; i++) // Initialize all lists
                Adj[i] = new Bag<int>();    //to empty 
        }

        public Graph(TextReader input)
        {
            this(input.Read());
            
            int e = input.Read();

            for (int i = 0; i < e; i++)
            {
                // Add an edge
                int v = input.Read();   // Read a vertex
                int w = input.Read();   // read another vertex
                AddEdge(v, w);  // and add edge connecting them
            }
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
            Adj[w].Add(v);
            E++;
        }

        public IEnumerable<int> GetAdj(int v)
        {
            return Adj[v];
        }
        
    }
}
