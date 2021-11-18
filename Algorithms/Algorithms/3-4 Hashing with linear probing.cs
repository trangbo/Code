using System;

namespace Algorithms
{
    public class LinearProbingHashST<Key, Value>
    {
        private int N;  // number of key-value pairs in the table
        private int M = 16; // size of linear-probing table
        private Key[] Keys;
        private Value[] Vals;

        public LinearProbingHashST()
        {
            Keys = new Key[M];
            Vals = new Value[M];
        }

        public LinearProbingHashST(int m)
        {
            Keys = new Key[m];
            Vals = new Value[m];
        }

        private int Hash(Key key)
        {
            return (key.GetHashCode() & 0x7fffffff) % M;
        }

        private void Resize(int cap)
        {
            var t = new LinearProbingHashST<Key, Value>(cap);
            
            for (int i = 0; i < M; i++)
            {
                if (Keys[i] != null)
                    t.Put(Keys[i], Vals[i]);
            }

            Keys = t.Keys;
            Vals = t.Vals;
            M = t.M;
        }

        public void Put(Key key, Value val)
        {
            if (N >= M / 2)
                Resize(2 * M);  // double M

            int i;
            
            for (i = Hash(key); Keys[i] != null; i = (i + 1) % M)
            {
                if (Keys[i].Equals(key))
                {
                    Vals[i] = val;
                    return;
                }      
            }

            Keys[i] = key;
            Vals[i] = val;
            N++;
        }

        public Value Get(Key key)
        {
            for (int i = Hash(key); Keys[i] != null; i = (i + 1) % M)
            {
                if (Keys[i].Equals(key))
                    return Vals[i];
            }

            return null;
        }

        public void Delete(Key key)
        {
            if (!Contains(key))
                return;

            int i = Hash(key);

            while (!key.Equals(Keys[i]))
                i = (i + 1) % M;

            Keys[i] = null;
            Vals[i] = null;
            i = (i + 1) % M;

            while (Keys[i] != null)
            {
                Key keyToReDo = Keys[i];
                Value valToReDo = Vals[i];
                Keys[i] = null;
                Vals[i] = null;
                N--;

                Put(keyToReDo, valToReDo);
                i = (i + 1) % M;
            }

            if (N > 0 && N <= M / 8) 
                Resize(M / 2);
        }
    }
}
