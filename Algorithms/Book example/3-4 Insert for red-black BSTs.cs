using System;

namespace Algorithms
{
    public class RedBlackBST<Key, Value> where Key : IComparable<Key>
    {
        private Node Root;
        private static readonly bool RED = true;
        private static readonly bool BLACK = false;
        private class Node
        {
            internal Key Key;    //Key
            internal Value Val;  //associated data
            internal Node Left, Right;   //Subtrees
            internal int N;  //# nodes in this subtree
            internal bool Color; // color of the link from parent to this node
        
            internal Node(Key key, Value val, int n, bool color)
            {
                this.Key = key;
                this.Val = val;
                this.N = n;
                this.Color = color;
            }
        }

        private bool IsRed(Node h)
        {
            if (h == null)
                return false;

            return h.Color == RED;
        }

        private bool IsEmpty()
        {
            return Root.N == 0;
        }

        private Node Balance(Node h)
        {
            if (IsRed(h.Right))
                h = RotateLeft(h);

            return h;
        }

        private int Size(Node h)
        {
            if (h == null)
                return 0;
            else
                return h.N;
        }

        private Node RotateLeft(Node h)
        {
            Node x = h.Right;
            h.Right = x.Left;
            x.Left = h;
            x.Color = h.Color;
            h.Color = RED;
            x.N = h.N;
            h.N = 1 + Size(h.Left) + Size(h.Right);

            return x;
        }

        private Node RotateRight(Node h)
        {
            Node x = h.Left;
            h.Left = x.Right;
            x.Right = h;
            x.Color = h.Color;
            h.Color = RED;
            x.N = h.N;
            h.N = 1 + Size(h.Left) + Size(h.Right);

            return x;
        }

        private void FlipColors(Node h)
        {
            h.Color = RED;
            h.Left.Color = BLACK;
            h.Right.Color = BLACK;
        }

        public void Put(Key key, Value val)
        {
            //Search for key. Update value if found; grow table if new.
            Root = Put(Root, key, val);
            Root.Color = BLACK;
        }

        private Node Put(Node h, Key key, Value val)
        {
            if (h == null) //Do standard insert, with red link to parent.
                return new Node(key, val, 1, RED);

            /*  If use top-down 2-3 tree, move FlipColors here
             * 
              if (IsRed(h.Left) && IsRed(h.Right))
                FlipColors(h);
             * 
             * 
             * 
             * 
             */

            int cmp = key.CompareTo(h.Key);

            if (cmp < 0)
                h.Left = Put(h.Left, key, val);
            else if (cmp > 0)
                h.Right = Put(h.Right, key, val);
            else
                h.Val = val;

            if (IsRed(h.Right) && !IsRed(h.Left))
                h = RotateLeft(h);
            if (IsRed(h.Left) && IsRed(h.Left.Left))
                h = RotateRight(h);
            if (IsRed(h.Left) && IsRed(h.Right))
                FlipColors(h);

            h.N = 1 + Size(h.Left) + Size(h.Right);

            return h;
        }

        private Node MoveRedLeft(Node h)
        {
            // Assuming that h is red and both h.left and h.left.left
            // are black, make h.left or one of its children red
            FlipColors(h);

            if (IsRed(h.Right.Left))
            {
                h.Right = RotateRight(h.Right);
                h = RotateLeft(h);
            }

            return h;
        }

        private Node MoveRedRight(Node h)
        {
            // Assuming that h is red and both h.right and h.right.left
            // are black, make h.right or one of its children red
            FlipColors(h);

            if (!IsRed(h.Left.Left))
                h = RotateRight(h);

            return h;
        }

        public void DeleteMin()
        {
            if (!IsRed(Root.Left) && !IsRed(Root.Right))
                Root.Color = RED;

            Root = DeleteMin(Root);

            if (!IsEmpty())
                Root.Color = BLACK;
        }

        private Node DeleteMin(Node h)
        {
            if (h.Left == null)
                return null;

            if (!IsRed(h.Left) && !IsRed(h.Left.Left))
                h = MoveRedLeft(h);

            h.Left = DeleteMin(h.Left);

            return Balance(h);
        }

        public void DeleteMax()
        {
            if (!IsRed(Root.Left) && !IsRed(Root.Right))
                Root.Color = RED;

            Root = DeleteMax(Root);

            if (!IsEmpty())
                Root.Color = BLACK;
        }

        private Node DeleteMax(Node h)
        {
            if (IsRed(h.Left))
                h = RotateRight(h);

            if (h.Right == null)
                return null;

            if (!IsRed(h.Right) && !IsRed(h.Right.Left))
                h = MoveRedRight(h);

            h.Right = DeleteMax(h.Right);

            return Balance(h);
        }

        public void Delete(Key key)
        {
            if (!IsRed(Root.Left) && !IsRed(Root.Right))
                Root.Color = RED;

            Root = Delete(Root, key);

            if (!IsEmpty())
                Root.Color = BLACK;
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

        private Node Min(Node x)
        {
            if (x.Left == null)
                return x;

            return Min(x.Left);
        }

        private Node Delete(Node h, Key key)
        {
            if (key.CompareTo(h.Key) < 0)
            {
                if (!IsRed(h.Left) && !IsRed(h.Left.Left))
                    h = MoveRedLeft(h);

                h.Left = Delete(h.Left, key);
            }
            else
            {
                if (IsRed(h.Left))
                    h = RotateRight(h);

                if (key.CompareTo(h.Key) == 0 && (h.Right == null))
                    return null;

                if (!IsRed(h.Right) && !IsRed(h.Right.Left))
                    h = MoveRedRight(h);

                if (key.CompareTo(h.Key) == 0)
                {
                    h.Val = Get(h.Right, Min(h.Right).Key);
                    h.Key = Min(h.Right).Key;
                    h.Right = DeleteMin(h.Right);
                }
                else
                    h.Right = Delete(h.Right, key);
            }

            return Balance(h);
        }
    }
}
