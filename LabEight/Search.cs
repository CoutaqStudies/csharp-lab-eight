using System;
using System.Collections.Generic;
using System.Data;

namespace LabEight
{
    public class Search
    {
        public static int LinearSearch(int[] array, int searchFor)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == searchFor)
                    return i;
                return -1;
        }
        public static int BinarySearch(int[] array, int searchFor)
        {
            if (searchFor > array[array.Length-1])
                return -1;
            int l = 0, r = array.Length-1;
            do
            {
                int m = (l + r) / 2;
                if (array[m] < searchFor)
                    l = m + 1;
                else if(array[m]>searchFor)
                    r = m - 1;
                else
                    return m;
            } while (l <= r);
            return -1;
        }
        public static int InterpolationSearch(int[] array, int searchFor)
        {
            int l = 0, r = array.Length - 1;

            if (array[l] == searchFor)
                return l;
            if (array[r] == searchFor)
                return r;

            while (r >= l)
            {
                double numerator = (searchFor - array[l]);
                double denominator = (array[r] - array[l]);
                double ratio = numerator / denominator;
                double m = l + ((r-l)*ratio);
                int mid = (int)(m);
                if (array[mid] < searchFor)
                    l = mid + 1;
                else if (array[mid] > searchFor)
                    r = mid - 1;
                else
                    return mid;
            }
            return -1;
        }
    }
}