using System;

namespace Algorithms
{
    public class BinarySearchST<Key, Value> where Key : IComparable<Key>
    {
        private Key[] Keys;
        private Value[] Vals;
        private int N;

        public BinarySearchST(int capacity)
        {   //See 1.1 for standard array-resizing code
            Keys = new Key[capacity];
            Vals = new Value[capacity];
        }

        public int Size()
        {
            return N;
        }

        public bool IsEmpty()
        {
            return Size() == 0;
        }

        public int Rank(Key key)
        {
            int lo = 0, hi = N - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(Keys[mid]);

                if (cmp < 0)
                    hi = mid - 1;
                else if (cmp > 0)
                    lo = mid + 1;
                else
                    return mid;
            }

            return lo;
        }

        public Value Get(Key key)
        {
            if (IsEmpty())
                return null;

            int i = Rank(key);

            if (i < N && Keys[i].CompareTo(key) == 0)
                return Vals[i];
            else
                return null;
        }

        public void Put(Key key, Value val)
        {
            //Search for key. Update value if found; grow table if new
            int i = Rank(key);

            if (i < N && Keys[i].CompareTo(key) == 0)
            {
                Vals[i] = val;
                return;
            }

            for (int j = N; j > i; j--)
            {
                Keys[j] = Keys[j - 1];
                Vals[j] = Vals[j - 1];
            }

            Keys[i] = key;
            Vals[i] = val;

            N++;
        }
    }
}
