using System;


namespace Algorithms
{
    public class Abstract_in_place_merge
    {
        public static void Merge(IComparable[] a, int lo, int mid, int hi)
        {
            //Merge a[lo..mid] with a[mid+1..hi]
            int i = lo, j = mid + 1;

            for (int k = lo; k <= hi; k++)
                //Copy a[lo..hi] to aux[lo..hi]
            {
                aux[K] = a[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                    a[k] = aux[j++];
                else if (j > hi)
                    a[k] = aux[i++];
                else if (Less(aux[j], aux[i]))
                    a[k] = aux[j++];
                else
                    a[k] = aux[i++];
            }
        }

        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }
    }
}
