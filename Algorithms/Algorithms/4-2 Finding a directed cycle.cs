using System;

namespace Algorithms
{
    public class DirectedCycle
    {
        private bool[] Marked;
        private int[] EdgeTo;
        private Stack<int> Cycle;   //Vertics on a cycle (if one exists)
        private bool[] OnStack; // vertics on recursive call stack

        public DirectedCycle(Digraph g)
        {
            OnStack = new bool[g.GetV()];
            EdgeTo = new int[g.GetV()];
            Marked = new bool[g.GetV()];

            for (int v = 0; v < g.GetV(); v++)
                if (!Marked[v])
                    Dfs(g, v);
        }

        private void Dfs(Digraph g, int v)
        {
            OnStack[v] = true;
            Marked[v] = true;

            foreach (int w in g.GetAdj(v))
            {
                if (this.HasCycle())
                    return;
                else if (!Marked[w])
                {
                    EdgeTo[w] = v;
                    Dfs(g, w);
                }
                else if (OnStack[w])
                {
                    Cycle = new Stack<int>();

                    for (int x = v; x != w; x = EdgeTo[x])
                        Cycle.Push(x);

                    Cycle.Push(w);
                    Cycle.Push(v);
                }
            }

            OnStack[v] = false;
        }

        public bool HasCycle()
        {
            return Cycle != null;
        }

        public IEnumerable<int> GetCycle()
        {
            return Cycle;
        }
    }
}
