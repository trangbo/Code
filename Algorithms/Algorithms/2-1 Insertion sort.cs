using System;

namespace Algorithms
{
    public class Insertion_sort
    //The running times of insertion sort and selection sort are quadratic
    //and within a small constant factor of one another for randomly ordered arrays of
    //distinct values.
    {
        public static void Sort(IComparable[] a)
        {
            //Sort a[] into increasing order
            int n = a.Length;

            for (int i = 1; i < n; i++)
            {
                //Insert a[i] among a[i-1], a[i-2], a[i-3]...
                //uses N^2/4 compares for a randomly orders
                //worst case is N^2/2
                //best case is N-1
                for (int j = i; j > 0 && Less(a[j], a[j-1]); j--)
                {
                    //uses N^2/4 exchanges for a randomly orders
                    //worst case is N^2/2
                    //best case is 0
                    Exch(a, j, j-1);
                }
            }
        }

        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        } 

        private static void Exch(IComparable[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
