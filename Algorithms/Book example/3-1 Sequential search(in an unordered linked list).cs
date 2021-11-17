using System;

namespace Algorithms
{
    public class SequentialSearchST<Key, Value>
    {
        private Node First;
        private class Node
        {
            internal Key Keyy;
            internal Value Val;
            internal Node Next;

            public Node(Key key, Value val, Node next)
            {
                this.Keyy = key;
                this.Val = val;
                this.Next = next;
            }
        }

        public Value Get(Key key)
        {
            //Search for key, return associated value
            for (Node x = First; x != null; x = x.Next)
            {
                if (key.Equals(x.Keyy))
                    return x.Val;
            }

            return null;
        }

        public void Put(Key key, Value val)
        {
            //Search for key, update value if found; grow table if new
            for (Node x = First; x != null; x = x.Next)
            {
                if (key.Equals(x.Keyy))
                {
                    x.Val = val;

                    return;
                }
            }

            First = new Node(key, val, First);
        }
    }
}
