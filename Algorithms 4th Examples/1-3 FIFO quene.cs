using System;
using System.Collections;

namespace Algorithms
{
    public class Quene<T> : IEnumerable<T>
    {
        private static Node First;
        private Node Last;
        private int N;
        private class Node
        {
            internal T Item;
            internal Node Next;

        }

        public bool IsEmpty() { return First == null; }

        public int Size() { return N; }

        public void EnQuene(T item)
        {   //Add item to the end of the list
            var oldLast = Last;
            Last = new Node();
            Last.Item = item;
            Last.Next = null;
            if (IsEmpty()) First = Last;
            else oldLast.Next = Last;
            N++;
        }

        public T DeQuene()
        {   //remove item from the beginning of the list
            var item = First.Item;
            First = First.Next;
            if (IsEmpty()) Last = null;
            N--;
            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListIterator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class ListIterator : IEnumerator<T>
        {
            private Node current = First;

            public T Current { get { return current.Item; } }
            object IEnumerator.Current { get { return current; } }

            public bool MoveNext()
            {
                return current != null;
            }
            public void Reset() { }
            public void Dispose() { }

        }
    }
}
