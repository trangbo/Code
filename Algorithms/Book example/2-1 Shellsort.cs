using System;

namespace Algorithms
{
    public class Shellsort
    {
        public static void Sort(IComparable[] a)
            //The number of compares used by shellsort with the increments 1, 4, 
//  13, 40, 121, 364, . . . is bounded by a small multiple of N times the number of increments used.
        {
            //sort a[] into increasinng order
            int n = a.Length;
            int h = 1;

            while (h < n/3) h = 3*h+ 1; //1, 4, 13, 40, 121, 364, 1093...

            while (h >= 1)
            {
                //h-sort the array
                for (int i = h; i < n; i++)
                {
                    //Insert a [i] among a[i-h], a[i-2*h], a[i-3*h]...
                    for (int j = i; j >= h && Less(a[j], a[j-h]); j -= h)
                    {
                        Exch(a, j, j - h);
                    }
                }
                h = h / 3;
            }
        } 

        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) <= 0;
        }

        private static void Exch(IComparable[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = a[i];
        }
    }
}
