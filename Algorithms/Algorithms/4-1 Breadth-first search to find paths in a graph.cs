using System;

namespace Algorithms
{
    public class BreadthFirstPaths
    {
        private bool[] Marked;  // Is a shortest path to vertex?
        private int[] EdgeTo;
        private readonly int S;

        public BreadthFirstPaths(Graph g, int s)
        {
            Marked = new bool[g.GetV()];
            EdgeTo = new int[g.GetV()];
            this.S = s;
            Bfs(g, s);
        }

        private void Bfs(Graph g, int s)
        {
            var queue = new Queue<int>();
            Marked[s] = true;   // Mark the source

            queue.Enqueue(s);   // Put it on the queue

            while (queue != null)
            {
                int v = queue.Dequeue();    //Remove next vertex from the queue.

                foreach (int w in g.GetAdj(v))
                {
                    if (!Marked[w]) // For every unmarked adjacent vertex 
                    {
                        EdgeTo[w] = v;  // save last edge on a shortest path
                        Marked[w] = true;
                        queue.Enqueue(w);
                    }
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return Marked[v];
        }

        public IEnumerable<int> PathTo(int v)   // Same as DFS
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
