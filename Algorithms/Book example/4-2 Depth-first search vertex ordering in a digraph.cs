using System;

namespace Algorithms
{
    public class DepthFirstOrder
    {
        private bool[] Marked;
        private Quene<int> Pre; // vertices in preorder
        private Quene<int> Post;  // vertices on postorder
        private Stack<int> ReversePost; // vertices in reverse postorder

        public DepthFirstOrder(Digraph g)
        {
            Pre = new Quene<int>();
            Post = new Quene<int>();
            ReversePost = new Stack<int>();
            Marked = new bool[g.GetV()];

            for (int v = 0; v < g.GetV(); v++)
                if (!Marked[v])
                    Dfs(g, v);
        }

        private void Dfs(Digraph g, int v)
        {
            Pre.EnQuene(v);
            Marked[v] = true;

            foreach (int w in g.GetAdj(v))
                if (!Marked[w])
                    Dfs(g, w);

            Post.EnQuene(v);
            ReversePost.Push(v);
        }

        public IEnumerable<int> GetPre()
        {
            return Pre;
        }

        public IEnumerable<int> GetPost()
        {
            return Post;
        }

        public IEnumerable<int> GetReversePost()
        {
            return ReversePost;
        }
    }
}
