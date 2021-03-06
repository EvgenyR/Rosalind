﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Rslnd
{
    public static class SuffixArrays
    {
        public static string SuffixArrayFromString(string input)
        {
            StrComparer cmp = new StrComparer(Encoding.ASCII.GetBytes(input));
            List<int> list = new List<int>();
            for (int i = 0; i < input.Length; i++) list.Add(i);

            list.Sort(cmp);

            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++) result.Append(list[i] + ", ");

            return result.ToString();
        }

        public static List<string> PartialSuffixArrayFromString(string input, int k)
        {
            StrComparer cmp = new StrComparer(Encoding.ASCII.GetBytes(input));
            List<int> list = new List<int>();
            for (int i = 0; i < input.Length; i++) list.Add(i);

            list.Sort(cmp);

            //StringBuilder result = new StringBuilder();
            List<string> result = new List<string>();
            for (int i = 0; i < input.Length; i++)
            {
                if (list[i] % k == 0)
                {
                    result.Add(i.ToString() + "," + list[i]);
                }
            }
            return result;
        }

        public static string BurrowsWheelerTransform(string input)
        {
            int len = input.Length;
            //create as list of indexes
            List<int> list = new List<int>();
            for (int i = 0; i < input.Length; i++) list.Add(i);
            //sort somehow
            BurrowsComparer cmp = new BurrowsComparer(Encoding.ASCII.GetBytes(input));
            list.Sort(cmp);
            //output last symbols
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (list[i] == 0) result.Append(input[len - 1]);
                else result.Append(input[list[i] - 1]);
            }
            return result.ToString();
        }

        public static string ReverseBurrowsWheeler(string input)
        {
            List<KeyValuePair<char, int>> dict = new List<KeyValuePair<char, int>>();

            for(int i = 0; i < input.Length; i++)
            {
                dict.Add(new KeyValuePair<char,int>(input[i], i));
            }

            dict = dict.OrderBy(z => z.Key).ToList();

            int x = dict[0].Value;

            string result = dict[x].Key.ToString();
            for (int i = 1; i < dict.Count; i++)
            {
                x = dict[x].Value;
                result = result + dict[x].Key;
            }

            return result;
        }
    }



    public class BurrowsComparer : IComparer<int>
    {
        private int len;
        private byte[] bText;

        public BurrowsComparer(byte[] input)
        {
            bText = input;
            len = input.Length;
        }

        public int GetIthPosition(int i, int start)
        {
            if (start + i < len) return start + i;
            else return start + i - len;
        }

        public int Compare(int x, int y)
        {
            int counter = 0;
            while (counter < len)
            {
                int xpos = GetIthPosition(counter, x);
                int ypos = GetIthPosition(counter, y);

                if (bText[xpos] > bText[ypos]) return 1;
                else if (bText[xpos] < bText[ypos]) return -1;
                counter++;
            }
            return 0;
        }
    }

    public class StrComparer : IComparer<int>
    {
        private int len;
        private byte[] bText;

        public StrComparer(byte[] input)
        {
            bText = input;
            len = input.Length;
        }

        public int Compare(int x, int y)
        {
            int minLen = Math.Min(len - x, len - y);

            for (int i = 0; i < minLen; i++)
            {
                if (bText[x + i] > bText[y + i]) return 1;
                else if (bText[x + i] < bText[y + i]) return -1;
            }
            return 0;
        }
    }
}
