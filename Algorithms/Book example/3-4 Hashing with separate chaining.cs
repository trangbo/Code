using System;

namespace Algorithms
{
    public class SeparateChainingHashST<Key, Value>
    {
        private int N;  //Number of key-value pairs
        private int M;  //hash table size
        private SequentialSearchST<Key, Value>[] St; //array of ST objects

        public SeparateChainingHashST()
        {
            this(997);
            
            // more robust solution is to use array resizing to make sure that
            // the lists are short no matter how many key-value pairs are in the table
        }

        public SeparateChainingHashST(int M)
        {
            this.M = M;
            St = new SequentialSearchST<Key, Value>[M];

            for (int i = 0; i < M; i++)
                St[i] = new SequentialSearchST<Key, Value>();
        }

        private void Resize(int cap)
        {
            var t = new SeparateChainingHashST<Key, Value>(cap);

            for (int i = 0; i < M; i++)
            {
                if (St[i] != null)
                    t.St[i] = St[i];
            }
            St = t.St;
            M = t.M;
        }

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        public Value Get(Key key)
        {
            return St[Hash(key)].Get(key);
        }

        public void Put(Key key, Value val)
        {
            if (N >= M / 2)
                Resize(2 * M);
            // array resizing is optional and not worth your trouble if you have a decent estimate 
            //of the client’s N: just pick a table size M based on the knowledge that search times are
            //proportional to 1 + N / M

            St[Hash(key)].Put(key, val);
        }

        public IEnumerable<Key> Keys()
        {

        }
    }
}
