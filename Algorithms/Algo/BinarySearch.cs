using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class BinarySearch
    {
        public static string BinarySearchProblem()
        {
            int[] arr = Utils.Helper.ParseDelimitedStringToIntArray("10 20 30 40 50", ' ');
            int[] vals = Utils.Helper.ParseDelimitedStringToIntArray("40 10 35 15 40 20", ' ');

            string result = string.Empty;

            foreach (int val in vals)
            {
                int test = Array.BinarySearch(arr, val);
                if (test < 0)
                {
                    result = result + "-1 ";
                }
                else
                {
                    result = result + (test + 1).ToString() + " ";
                }
            }

            return result;
        }
    }
}
