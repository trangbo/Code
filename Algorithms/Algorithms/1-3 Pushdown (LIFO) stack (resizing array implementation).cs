using System;
using System.Collections;

namespace Algorithms
{
    public class ResizingArrayStack<T> : IEnumerable<T>
    {
        private static T[] a = new T[1];
        private static int N = 0;

        public bool IsEmpty() { return N == 0; }
        public int Size() { return N; }

        private void Resize(int max)
        {
            var temp = new T[max];

            for (int i = 0; i < max; i++)
                temp[i] = a[i];

            a = temp;
        }

        public void Push(T item)
        {
            if (N == a.Length) Resize(2 * a.Length);
            a[N++] = item;
        }

        public T Pop()
        {
            T t = a[--N];
            a[N] = default;

            if (N > 0 && N == a.Length / 4) Resize(a.Length / 2);

            return t;
        }

        //When you implement IEnumerable(T), you must also implement IEnumerable and IEnumerator(T).
        public IEnumerator<T> GetEnumerator()
        {
            return new ReverseArrayIEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Implementing IEnumerator(T) requires that you implement IEnumerator and IDisposable.
        private class ReverseArrayIEnumerator : IEnumerator<T>
        {
            private int i = N;

            // Implement the IEnumerator(T).Current publicly, but implement IEnumerator.Current, which is also required, privately.
            public T Current { get { return a[--i]; } }

            object IEnumerator.Current { get { return Current; } }

            // Implement MoveNext and Reset, which are required by IEnumerator.
            public bool MoveNext()
            {
                return i > 0;
            }

            public void Reset() { N = 0; }

            // Implement IDisposable, which is also implemented by IEnumerator(T).
            public void Dispose() { }
        }
    }
}
