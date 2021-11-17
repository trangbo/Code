using System;
using System.Collections;

namespace Algorithms
{
    public class Bag<T> : IEnumerable<T>
    {
        private static Node First;
        private int N;
        private class Node
        {
            internal T Item;
            internal Node Next;
        }

        public bool IsEmpty()
        {
            return First == null;
        }

        public int Size()
        {
            return N;
        }

        public void Add(T item)
        {
            var oldFirst = First;
            First = new Node();
            First.Item = item;
            First.Next = oldFirst;
            N++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListIterator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        private class ListIterator : IEnumerator<T>
        {
            private Node current = First;
            public T Current { get { return current.Item; } }

            object IEnumerator.Current { get { return Current; } }

            public bool MoveNext()
            {
                return current != null;
            }

            public void Reset() { }

            public void Dispose() { }
        }
    }
}
