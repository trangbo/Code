using System;

namespace Algorithms
{
    public class Selection_sort
    //The running times of insertion sort and selection sort are quadratic
    //and within a small constant factor of one another for randomly ordered arrays of
    //distinct values.
    {
        public static void Sort(IComparable[] a)
        {
            //Sort a[] to increasing order
            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                //Exchange a[i] with smallest entry in a[i+1...n]
                int min = i;
                //N^2/2 to compare
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j].CompareTo(a[min]) < 0) 
                        min = j;
                }
                //N to compare
                Exch(a, i, min);
            }
        }
        
        private static void Exch(IComparable[] a, int i, int j)
        {
            var t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
