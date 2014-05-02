using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBook
{
    //Problems from Week 9, 10: How Do We Locate Disease-Causing Mutations?
    public static class Locate
    {
        //1. Trie Construction Problem

        //9. Burrows-Wheeler Transform Construction Problem
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
}
