using System;

namespace Algorithms
{
    public class BinarySearch<T> where T : IComparable<T>
    {
        public static int FindIndex(T[] sortedData, T item)
        {
            int left = 0, right = sortedData.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (item.CompareTo(sortedData[middle]) > 0) left = middle + 1;
                else if (item.CompareTo(sortedData[middle]) < 0) right = middle - 1;
                else return middle;
            }

            return -1;
        }
    }
}
