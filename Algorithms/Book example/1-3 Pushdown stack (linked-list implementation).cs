using System;
using System.Collections;

namespace Algorithms
{
    public class Stack<T> : IEnumerable<T>
    {
        private static Node First; //top of stack(nost recently added node)
        private int N;  //number of items
        private class Node
        {
            internal T Item;
            internal Node Next;
        }

        public bool IsEmpty() { return First == null; }
        
        public int Size() { return N; }

        public void Push(T item)
        {
            var oldFirst = First;
            First = new Node();
            First.Item = item;
            First.Next = oldFirst;
            N++;
        }

        public T Pop()
        {
            T item = First.Item;
            First = First.Next;
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
            public T Current { get { return current.Item; }  }

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
