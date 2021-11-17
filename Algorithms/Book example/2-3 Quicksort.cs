using System;

namespace Algorithms
{
    public class Quicksort
    //Quicksort uses ~ 2N ln N compares (and one-sixth that many exchanges) on the average to sort an array of length N with distinct keys.
    // Quicksort uses ~ N 2/2 compares in the worst case, but random shuffling protects against this case.
    {
        public static void Sort(IComparable[] a)
        {
            Shuffle(a);
            Sort(a, 0, a.Length - 1);
        }

        private static void Sort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;

            //The optimum value of the cutoff M is system-dependent, but any value between 5 and 
            //15 is likely to work well in most situations
            if (hi <= lo + M)
            {
                Insertion_sort.Sort(a, lo, hi);

                return;
            }

            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1); //Sort left part a[lo .. j-1]
            Sort(a, j + 1, hi); //Sort right part a[j+1 .. hi]
        }
        
        //Quick3way
        private static void Quick3waySort(IComparable[] a, int lo, int hi)
        {
            if (hi <= lo) return;

            int lt = lo, i = lo + 1, gt = hi;
            var v = a[lo];

            while (i <= gt)
            {
                int cmp = a[i].CompareTo(v);

                if (cmp < 0)
                    Exch(a, lt++, i++);
                else if (cmp > 0)
                    Exch(a, i, gt--);
                else
                    i++;
            }   //Now a[lo..lt-1] < v = a[lt..gt] < a[gt+1..hi]

            Quick3waySort(a, lo, lt - 1);
            Quick3waySort(a, gt + 1, hi);
        }

     /**
     * Rearranges the elements of the specified array in uniformly random order.
     *
     * @param  a the array to shuffle
     * @throws IllegalArgumentException if {@code a} is {@code null}
     */
        private static void Shuffle(IComparable[] a)
        {
            if (a == null)
            {
                throw new ArgumentNullException(nameof(a));
            }

            int n = a.Length;
            var rdm = new Random();

            for (int i = 0; i < n; i++)
            {
                int r = i + rdm.Next(n - i);     // between i and n-1
                var temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        private static int Partition(IComparable[] a, int lo, int hi)
        {
            //Partition into a[lo..i-1], a[i], a[i+1..hi]
            int i = lo, j = hi + 1;
            var v = a[lo];

            while (true)
            {
                //Scan right, scan left, check for scan complete, and exchange
                while (Less(a[++i], v))
                    if (i == hi) 
                        break;
                while (Less(v, a[--j]))
                    if (j == lo) 
                        break;
                if (i >= j)
                    break;
                Exch(a, i, j);
            }

            Exch(a, lo, j); //Put v = a[j] into position

            return j;   //with a[lo..j-1] <= a[j] <= a[j+1..hi]
        }

        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        private static void Exch(IComparable[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = a[i];
        }
    }
}
