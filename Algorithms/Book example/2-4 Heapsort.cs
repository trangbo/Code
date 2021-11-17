using System;

namespace Algorithms
{
    public class Heapsort
    {
        private static void Exch(IComparable[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = a[i];
        }

        private static bool Less(IComparable[] a, int i, int j)
        {
            return i.CompareTo(j) < 0;
        }

        private static void Sink(IComparable[] a, int k, int n)
        {
            while (2 * k <= n)
            {
                int j = 2 * k;

                if (j < n && Less(a, j, j + 1))
                    j++;
                if (!Less(a, k, j))
                    break;

                Exch(a, k, j);

                k = j;
            }
        }

        public static void Sort(IComparable[] a)
        {
            int n = a.Length;

            for (int k = n / 2; k >= 1; k--)
                Sink(a, k, n);

            while (n > 1)
            {
                Exch(a, 1, n--);
                Sink(a, 1, n);
            }
        }
    }
}
