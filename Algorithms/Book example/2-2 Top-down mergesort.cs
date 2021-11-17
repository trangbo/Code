using System;

namespace Algorithms
{
    public class Merge
    //O(NlgN)
    {
        private static IComparable[] Aux;

        public static void Sort(IComparable[] a)
        {
            Aux = new IComparable[a.Length];
            
        }

        private static void Sort(IComparable[] a, int lo, int hi)
        {
            //Sort a[lo..hi]
            if (hi <= lo) return;

            int mid = lo + (hi - lo) / 2;

            Sort(a, lo, mid);   //Sort left half
            Sort(a, mid + 1, hi);   //Sort right half
            MergeTd(a, lo, mid, hi);  //Merge results
        }

        private static void MergeTd(IComparable[] a, int lo, int mid, int hi)
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
    }
}
