using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace TextBook
{
    // Problems from week 1: Where in the Genome Does DNA Replication Begin?
    public static class WeekOne
    {
        // 1. Frequent word problem
        public static void FrequentWord()
        {
            string s = "ACGTTGCATGTCGCATGATGCATGAGAGCT";
            int i = 4;
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for (int j = 0; j < s.Length - i; j++)
            {
                string temp = s.Substring(j, i);
                if (dict.ContainsKey(temp)) dict[temp]++;
                else dict.Add(temp, 1);
            }

            int max = 0;

            foreach (KeyValuePair<string, int> kvp in dict)
            {
                if (kvp.Value > max) max = kvp.Value;
            }

            string result = string.Empty;

            foreach (KeyValuePair<string, int> kvp in dict)
            {
                if (kvp.Value == max) result = result + kvp.Key + " ";
            }
        }

        //2. Reverse complement problem
        public static string ReverseComplement(string s)
        {
            string result = string.Empty;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                char ch = s[i];
                switch (ch)
                {
                    case 'A':
                        result += 'T';
                        break;
                    case 'T':
                        result += 'A';
                        break;
                    case 'C':
                        result += 'G';
                        break;
                    case 'G':
                        result += 'C';
                        break;
                }
            }

            return result;
        }

        //3. Pattern matching problem
        //Usage: WeekOne.FindAllOccurences("GATATATGCATATACTT", "ATAT");
        public static void FindAllOccurences(string s, string t)
        {
            string result = string.Empty;
            for (int i = 0; i < s.Length - t.Length; i++)
            {
                string test = s.Substring(i, t.Length);
                if (test == t) result = result + i.ToString() + " ";
            }
        }

        //4. Clump finding problem
        // Usage: WeekOne.FindClums("CGGACTCGACAGATGTGAAGAAATGTGAAGACTGAGTGAAGAGAAGAGGAAACACGACACGACATTGCGACATAATGTACGAATGTAATGTGCCTATGGC", 5, 75, 4);
        public static void FindClums(string s, int k, int l, int t)
        {
            string result = string.Empty;
            for (int i = 0; i < s.Length - l; i++)
            {
                string test = s.Substring(i, l);
                result = FindClumpsInSmallString(result, test, k, t);
            }
        }

        public static string FindClumpsInSmallString(string result, string test, int k, int t)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < test.Length - k; i++)
            {
                string kmer = test.Substring(i, k);
                if (dict.ContainsKey(kmer)) dict[kmer]++;
                else dict.Add(kmer, 1);
            }

            foreach (KeyValuePair<string, int> kvp in dict)
            {
                if (kvp.Value >= t)
                {
                    if (!result.Contains(kvp.Key)) result = result + kvp.Key + " ";
                }
            }

            return result;
        }

        //5. Minimum skew problem
        public static void MinimizeSkew(string s)
        {
            string result = string.Empty;
            Dictionary<int, int> dSkew = new Dictionary<int, int>();
            int skew = 0;
            for (int i = 1; i <= s.Length; i++)
            {
                char ch = s[i - 1];
                if (ch == 'C')
                {
                    skew--;
                }
                if (ch == 'G')
                {
                    skew++;
                }
                dSkew.Add(i, skew);
            }

            int min = 10000;
            foreach (KeyValuePair<int, int> kvp in dSkew)
            {
                if (kvp.Value < min) min = kvp.Value;
            }

            foreach (KeyValuePair<int, int> kvp in dSkew)
            {
                if (kvp.Value == min) result = result + kvp.Key + " ";
            }
        }

        //6. Approximate pattern matching problem
        //Usage: WeekOne.ApproximatePatternMatching("CGCCCGAATCCAGAACGCATTCCCATATTTCGGGACCACTGGCCTCCACGGTACGGACGTCAATCAAATGCCTAGCGGCTTGTGGTTTCTCCTACGCTCC", "ATTCTGGA", 3);
        public static void ApproximatePatternMatching(string s, string test, int iMis)
        {
            string result = string.Empty;
            int tLen = test.Length;
            for (int i = 0; i < s.Length - tLen + 1; i++)
            {
                if (CheckMismatch(s.Substring(i, tLen), test, iMis)) result = result + i + " ";
            }
        }

        public static bool CheckMismatch(string s1, string s2, int nMis)
        {
            int count = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (s1[i] != s2[i]) count++;
                if (count > nMis) return false;
            }
            return true;
        }

        //7, 8. Frequent word with mismatch problem
        //Usage: WeekOne.FrequentWordWithMismatch("AAAGTTTATAAAGTTTATGATGGACGACGGTGTGCGGTGTGGATGGACGAAAGGTTCCGATGGACGAACTTCACGATGGACGACGGTGTGCGGTGTGACTTCACAAAGTTTATGATGGACGAAAAGTTTATACTTCACCGGTGTGGATGGACGACGGTGTGAAAGTTTATAAGGTTCCACTTCACAAGGTTCCACTTCACAAGGTTCCAAGGTTCCAAGGTTCCAAAGTTTATAAAGTTTATCGGTGTGACTTCACCGGTGTGAAAGTTTATCGGTGTGACTTCACCGGTGTGGATGGACGAAAAGTTTATCGGTGTGAAAGTTTATACTTCACAAGGTTCCCGGTGTGCGGTGTGAAGGTTCCAAGGTTCCCGGTGTGAAAGTTTATCGGTGTGAAGGTTCCAAAGTTTATAAAGTTTATAAGGTTCCAAAGTTTATGATGGACGAGATGGACGAACTTCACAAGGTTCCGATGGACGAGATGGACGAAAAGTTTATCGGTGTGAAGGTTCCCGGTGTGCGGTGTGAAGGTTCCCGGTGTGCGGTGTGAAAGTTTATACTTCACGATGGACGAACTTCACAAAGTTTATAAAGTTTATAAAGTTTATCGGTGTGCGGTGTGGATGGACGACGGTGTGACTTCACAAGGTTCCGATGGACGAACTTCACAAAGTTTATCGGTGTGAAAGTTTATAAGGTTCCCGGTGTGAAAGTTTATAAAGTTTATACTTCACACTTCACAAAGTTTATGATGGACGAAAGGTTCCCGGTGTGACTTCACACTTCACACTTCAC", 11, 3);
        public static void FrequentWordWithMismatch(string s, int len, int iMis)
        {
            List<string> lst = GetAllKMers(len);
            Dictionary<string, int> matches = new Dictionary<string, int>();

            foreach (string kmer in lst)
            {
                int count = 0;
                for (int i = 0; i <= s.Length - len; i++)
                {
                    string testkmer = s.Substring(i, len);
                    if (CheckMismatch(kmer, testkmer, iMis)) count++;
                    //Uncomment the next line to solve number 8. Keep commented to solve number 7
                    //if (CheckMismatch(ReverseComplement(kmer), testkmer, iMis)) count++;
                }
                matches.Add(kmer, count);
            }

            int maxmatches = 0;

            foreach (KeyValuePair<string, int> kvp in matches)
            {
                if (kvp.Value > maxmatches) maxmatches = kvp.Value;
            }

            string result = string.Empty;

            foreach (KeyValuePair<string, int> kvp in matches)
            {
                if (kvp.Value == maxmatches) result = result + kvp.Key + " ";
            }

            Helper.WriteStringsToTextFile(new List<string> { result });
        }

        public static List<string> GetAllKMers(int k)
        {
            IEnumerable<string> letters = new[] { "A", "C", "G", "T" };

            var result = Enumerable.Range(0, k - 1)
                            .Aggregate(letters, (curr, i) => curr.SelectMany(s => letters, (s, c) => s + c));

            return result.ToList<string>();
        }
    }
}
