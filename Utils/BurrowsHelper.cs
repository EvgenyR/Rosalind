using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class BurrowsHelper
    {
        public static int OrderOfChar(List<char> chars, int pos, char ch)
        {
            int count = 0;
            for (int i = 0; i <= pos; i++)
            {
                if (chars[i] == ch) count++;
            }
            return count;
        }

        public static int GetCharPosByOrder(List<char> chars, int pos, char ch)
        {
            int count = 1;
            for (int i = 0; i < chars.Count; i++)
            {
                if (chars[i] == ch)
                {
                    if (count == pos) return i;
                    else count++;
                }
            }
            throw new Exception("You're dumb");
        }

        public static int FirstOccurrenceOfSymbol(char ch, string s)
        {
            return s.IndexOf(ch);
        }

        public static int CountSymbol(char ch, int i, string s)
        {
            int count = 0;
            for (int j = 0; j < i; j++)
            {
                if (s[j] == ch) count++;
            }
            return count;
        }
    }
}
