using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class FragileHelper
    {
        public static List<int> ListFromString(string input)
        {
            List<int> result = new List<int>();
            input = input.Replace("(", "").Replace(")", "");
            string[] split = input.Split(' ');
            foreach (string s in split)
            {
                if (s.Substring(0, 1) == "+") result.Add(Int32.Parse(s.Substring(1, s.Length - 1)));
                else result.Add(0 - Int32.Parse(s.Substring(1, s.Length - 1)));
            }
            return result;
        }

        public static string StringFromList(List<int> input)
        {
            string result = "(";
            foreach (int i in input)
            {
                if (i > 0) result = result + "+" + i.ToString() + " ";
                else result = result + i.ToString() + " ";
            }
            return result.Trim() + ")";
        }


        public static List<int> KSortingReversal(List<int> input, int k)
        {
            int end = k;
            bool endReached = false;
            while (!endReached)
            {
                if (Math.Abs(input[end]) != k + 1)
                {
                    end++;
                }
                else
                {
                    endReached = true;
                }
            }

            //reverse flip from k to end

            List<int> result = new List<int>(input);
            int j = end;
            for (int i = k; i <= end; i++)
            {
                result[i] = input[j] * -1;
                j--;
            }

            return result;
        }

        public static List<int> ReversalFlipping(List<int> input, int i)
        {
            input[i] = input[i] * -1;
            return input;
        }

        public static List<string> BetterInputFromInput(string input)
        {
            List<string> betterInput = new List<string>();

            string str = input.Replace(")(", ")|(");
            string[] strs = str.Split('|');
            foreach (string spl in strs)
            {
                betterInput.Add(spl);
            }
            return betterInput;
        }

        public static List<KeyValuePair<int, int>> GraphFromString(string inputList)
        {
            List<KeyValuePair<int, int>> result = new List<KeyValuePair<int, int>>();

            List<int> ints = ListFromString(inputList);

            for (int i = 0; i <= ints.Count() - 2; i++)
            {
                int key = ints[i];
                int value = ints[i + 1] * -1;
                result.Add(new KeyValuePair<int, int>(key, value));
            }
            result.Add(new KeyValuePair<int, int>(ints[ints.Count() - 1], ints[0] * -1));
            return result;
        }

        public static void StringFromGraph(List<KeyValuePair<int, int>> input)
        {
            List<string> result = new List<string>();
            foreach (KeyValuePair<int, int> kvp in input)
            {
                result.Add(kvp.Key.ToString() + ", " + kvp.Value.ToString());
            }
            Helper.WriteStringsToTextFile(result);
        }
    }
}
