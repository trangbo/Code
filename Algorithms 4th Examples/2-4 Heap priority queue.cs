using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class MaxPQ<Key> where Key : IComparable<Key>
    {
        private Key[] Pq;   //heap-ordered complete binary tree
        private int N = 0;  //in Pq[1..N] with Pq[0] unused

        public MaxPQ(int maxN)
        {
            Pq = new Key[maxN + 1];
        }

        public bool IsEmpty()
        {
            return N == 0;
        }

        public int Size()
        {
            return N;
        }

        public void Insert(Key v)
        {
            if (N == Pq.Length) 
                Resize(2 * Pq.Length);    //Resize to avoid overload
            
            Pq[++N] = v;

            Swim(N);
        }

        public Key delMax()
        {
            var max = Pq[1];    //Retrieve max key from top

            Exch(1, N--);   //Exchange with last item

            Pq[N + 1] = default; //Avoid loitering

            Sink(1);

            if (N > 0 && N == Pq.Length / 4)
                Resize(Pq.Length / 2); //Resize to reduce size

            return max;
        }

        private bool Less(int i, int j)
        {
            return Pq[i].CompareTo(Pq[j]) < 0;
        }

        private void Exch(int i, int j)
        {
            var t = Pq[i];
            Pq[i] = Pq[j];
            Pq[j] = Pq[i];
        }

        private void Swim(int k)
        {
            while (k > 1 && Less(k/2, k))
            {
                Exch(k / 2, k);
                k = k / 2;
            }
        }

        private void Sink(int k)
        {
            while (2*k <= N)
            {
                int j = 2 * k;

                if (j < N && Less(j, j + 1))
                    j++;
                if (!Less(k, j))
                    break;

                Exch(k, j);

                k = j;
            }
        }

        private void Resize(int max)
        {
            var temp = new Key[max];

            for (int i = 0; i < max; i++)
                temp[i] = Pq[i];

            Pq = temp;
        }
    }
}
