using System;

namespace Algorithms
{
    public class MergeBU
    //Bottom-up mergesort uses between ½ N lg N and N lg N compares
    //and at most 6N lg N array accesses to sort an array of length N
    {
        private static IComparable[] Aux;   //auxiliary array for me

        private static void Merge(IComparable[] a, int lo, int mid, int hi)
        {
            //Merge a[lo..mid] with a[mid+1..hi]
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
            //Copy a[lo..hi] to aux[lo..hi]
            {
                Aux[k] = a[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                    a[k] = Aux[j++];
                else if (j > hi)
                    a[k] = Aux[i++];
                else if (Less(Aux[j], Aux[i]))
                    a[k] = Aux[j++];
                else
                    a[k] = Aux[i++];
            }
        }

        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        public static void Sort(IComparable[] a)
        {
            //Do lgN passes of pairwise merges
            int n = a.Length;
            Aux = new IComparable[n];

            for (int sz = 1; sz < n; sz = sz + sz)  //sz: subarray size
            {
                for (int lo = 0; lo < n - sz; lo += sz + sz)    //lo: subarray size
                {
                    Merge(a, lo, lo + sz - 1, Math.Min(lo + sz + sz - 1, n - 1));
                }
            }
        }
    }
}
