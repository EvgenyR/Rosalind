using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class DegreeArray
    {
        public static void DegreeArrayProblem()
        {
            List<string> input = Utils.Helper.ParseTextFileToStrings();
            //List<KeyValuePair<int, int>> output = new List<KeyValuePair<int, int>>();
            Dictionary<int, int> output = new Dictionary<int, int>();
            int[] arr = new int[input.Count() * 2];
            int i = 0;
            foreach (string s in input)
            {
                string[] sArr = s.Split(' ');
                arr[i] = Int32.Parse(sArr[0]);
                i++;
                arr[i] = Int32.Parse(sArr[1]);
                i++;
            }
            Array.Sort(arr);
            foreach (int item in arr)
            {
                if (output.ContainsKey(item))
                {
                    output[item]++;
                }
                else
                {
                    output.Add(item, 1);
                }
            }

            string result = string.Empty;

            foreach (KeyValuePair<int, int> kvp in output)
            {
                result = result + kvp.Value.ToString() + " ";
            }

            int z = 0;
        }
        
    }
}
