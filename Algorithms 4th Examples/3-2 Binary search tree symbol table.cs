using System;

namespace Algorithms
{
    public class BST<Key, Value> where Key : IComparable<Key> 
    {
        private Node Root;  //Root of BST

        private class Node
        {
            internal Key Key;    //Key
            internal Value Val;  //associated value
            internal Node Left, Right;   //links to subtrees
            internal int N;  //nodes in subtree

            public Node(Key key, Value val, int N)
            {
                this.Key = key;
                this.Val = val;
                this.N = N;
            }
        }

        public int Size()
        {
            return Size(Root);
        }

        private int Size(Node x)
        {
            if (x == null)
                return 0;
            else
                return x.N;
        }

        public Value Get(Key key)
        {
            return Get(Root, key);
        }

        private Value Get(Node x, Key key)
        {
            //Return value associated with key in the subtree rooted at x
            //return null if key not present in subtree rooted at x
            if (x == null)
                return null;
            int cmp = key.CompareTo(x.Key);
            if (cmp < 0)
                return Get(x.Left, key);
            if (cmp > 0)
                return Get(x.Right, key);
            else
                return x.Val;
        }

        public void Put(Key key, Value val)
        {
            //Search for key, update value if found, grow table if new
            Root = Put(Root, key, val);
        }

        private Node Put(Node x, Key key, Value val)
        {
            //change key's value to val if key in subtree rooted at x
            //otherwise, add new node to subtree associating key with val
            if (x == null)
                return new Node(key, val, 1);

            int cmp = key.CompareTo(x.Key);

            if (cmp < 0)
                x.Left = Put(x.Left, key, val);
            else if (cmp > 0)
                x.Right = Put(x.Right, key, val);
            else
                x.Val = val;

            x.N = Size(x.Left) + Size(x.Right) + 1;

            return x;
        }

        public Key Min()
        {
           return Min(Root).Key;
        }

        private Node Min(Node x)
        {
            if (x.Left == null)
                return x;

            return Min(x.Left);
        }

        public Key Floor(Key key)
        {
            var x = Floor(Root, key);
            if (x == null)
                return null;

            return x.key;
        }

        private Node Floor(Node x, Key key)
        {
            if (x == null)
                return null;

            int cmp = key.CompareTo(x.Key);

            if (cmp == 0)
                return x;
            if (cmp < 0)
                return Floor(x.Left, key);

            Node t = Floor(x.Right, key);

            if (t != null)
                return t;
            else
                return x;
        }

        public Key Select(int k)
        {
            return Select(Root, k).Key;
        }

        private Node Select(Node x, int k)
        {
            //Return Node contanining key of rank k
            if (x == null)
                return null;

            int t = Size(x.Left);

            if (t > k)
                return Select(x.Left, k);
            else if (t < k)
                return Select(x.Right, k - t - 1);
            else
                return x;
        }

        public int Rank(Key key)
        {
            return Rank(key, Root);
        }

        private int Rank(Key key, Node x)
        {
            //Return number of keys less than x.key in the subtree rooted at x.
            if (x == null)
                return null;

            int cmp = key.CompareTo(x.Key);

            if (cmp < 0)
                return Rank(key, x.Left);
            else if (cmp > 0)
                return 1 + Size(x.Left) + Rank(key, x.Right);
            else
                return Size(x.Left);
        }

        public void DeleteMin()
        {
            Root = DeleteMin(root);
        }

        private Node DeleteMin(Node x)
        {
            if (x.Left == null)
                return x.Right;

            x.Left = DeleteMin(x.Left);
            x.N = Size(x.Left) + Size(x.Right) + 1;

            return x;

        }

        public void Delete(Key key)
        {
            Root = Delete(Root, key);
        }

        private Node Delete(Node x, Key key)
        {
            if (x == null)
                return null;

            int cmp = key.CompareTo(x.Key);

            if (cmp < 0)
                x.Left = Delete(x.Left, key);
            else if (cmp > 0)
                x.Right = Delete(x.Right, key);
            else
            {
                if (x.Right == null)
                    return x.Left;
                if (x.Left == null)
                    return x.Right;

                Node t = x;

                x = Min(t.Right);
                x.Right = DeleteMin(t.Right);
                x.Left = t.Left;
            }

            x.N = Size(x.Left) + Size(x.Right) + 1;

            return x;
        }

        private void Print(Node x)
        {
            if (x == null)
                return;
            Print(x.Left);
            Console.WriteLine(x.Key);
            Print(x.Right);
        }

        public IEnumerable<Key> Keys()
        {
            return Keys(Min(), Max());
        }

        public IEnumerable<Key> Keys(Key lo, Key hi)
        {
            var queue = new Queue<Key>();
            Keys(Root, queue, lo, hi);
            return queue;
        }

        private void Keys(Node x, Queue<Key> queue, Key lo, Key hi)
        {
            if (x == null)
                return;

            int cmplo = lo.CompareTo(x.Key);
            int cmphi = hi.CompareTo(x.Key);

            if (cmplo < 0)
                Keys(x.Left, queue, lo, hi);

            if (cmplo <= 0 && cmphi >= 0)
                queue.Enqueue(x.Key);

            if (cmphi > 0)
                Keys(x.Right, queue, lo, hi);
        }
    }
}
