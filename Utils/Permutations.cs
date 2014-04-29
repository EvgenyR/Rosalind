using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class Permutations
    {
        public static List<string> Dictionary(int length, string abet)
        {
            char[] alphabet = AlphabetFromString(abet);

            List<string> final = new List<string>();

            for (int i = 1; i <= length; i++)
            {
                List<string> result = GetWordsWithRepetition(i, alphabet).ToList();
                final.AddRange(result);
            }
            return final;
        }

        public static IEnumerable<String> GetWordsWithRepetition(Int32 length, char[] alphabet)
        {
            if (length <= 0)
                yield break;

            for (int i = 0; i < alphabet.Length; i++)
            {
                char c = alphabet[i];
                if (length > 1)
                {
                    foreach (String restWord in GetWordsWithRepetition(length - 1, alphabet))
                        yield return c + restWord;
                }
                else
                    yield return "" + c;
            }
        }

        public static char[] AlphabetFromString(string input)
        {
            string[] split = input.Split(' ');
            char[] alphabet = new char[split.Count()];
            for (int i = 0; i < alphabet.Length; i++)
            {
                alphabet[i] = split[i][0];
            }
            return alphabet;
        }
    }
}
