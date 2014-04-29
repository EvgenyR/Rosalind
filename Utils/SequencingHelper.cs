using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class SequencingHelper
    {
        public static List<int> SortByFrequency(List<int> source)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();

            foreach (int val in source)
            {
                if (freq.ContainsKey(val))
                {
                    freq[val]++;
                }
                else
                {
                    freq.Add(val, 1);
                }
            }

            Dictionary<int, int> sorted = freq.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            List<int> result = new List<int>();

            foreach (KeyValuePair<int, int> kvp in sorted)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    result.Add(kvp.Key);
                }
            }
            return result;
        }
    }
}
