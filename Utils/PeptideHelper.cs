using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class PeptideHelper
    {
        public static List<string> SubPeptides(string peptide, int n)
        {
            List<string> result = new List<string>();
            for (int i = 0; i <= peptide.Length - n; i++)
            {
                result.Add(peptide.Substring(i, n));
            }

            for (int i = 0; i < n - 1; i++)
            {
                result.Add(peptide.Substring(peptide.Length - i - 1, i + 1) + peptide.Substring(0, n - i - 1));
            }

            return result;
        }

        public static int IntProteinMass(string s)
        {
            int result = 0;

            foreach (var ch in s)
            {
                result += MassTable[ch];
            }
            return result;
            //return result + 18.01056;
        }

        public static bool IntOccurence(List<int> candidate, List<int> matrix)
        {
            foreach (int val in candidate)
            {
                //var g = matrix.GroupBy(i => val);

                int ocInCand = candidate.Where(s => s == val).Count();
                int ocInMatr = matrix.Where(s => s == val).Count();
                if (ocInCand > ocInMatr) return false;
            }
            return true;
        }

        public static bool IsValidSpectrum(List<int> candidate, List<int> spectrum, bool full)
        {
            //List<int> uniques = new List<int>();
            //foreach (int i in candidate)
            //{
            //    if (!uniques.Contains(i)) uniques.Add(i);
            //}
            List<int> fullSp = PeptideSpectrum(candidate, full);
            foreach (int val in fullSp)
            {
                if (!spectrum.Contains(val)) return false;

                int ocInCand = fullSp.Where(s => s == val).Count();
                int ocInMatr = spectrum.Where(s => s == val).Count();
                if (ocInCand > ocInMatr) return false;
            }
            return true;
        }

        public static List<int> PeptideSpectrum(List<int> acids, bool full)
        {
            List<List<int>> result = new List<List<int>>();

            for (int i = 1; i < acids.Count; i++)
            {
                List<List<int>> sp = SubPeptides(acids, i, full);
                result.AddRange(sp);
            }
            result.Add(acids);

            List<int> spectrum = new List<int>();

            foreach (List<int> lst in result)
            {
                int val = lst.Sum();
                if (!spectrum.Contains(val)) spectrum.Add(val);
            }

            spectrum.Sort();

            return spectrum;
        }

        public static List<List<int>> SubPeptides(List<int> peptide, int n, bool full)
        {
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i <= peptide.Count - n; i++)
            {
                int[] newList = new int[n];
                peptide.CopyTo(i, newList, 0, n);
                result.Add(newList.ToList());
            }

            if (full)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    int[] newList = new int[n];
                    peptide.CopyTo(peptide.Count - i - 1, newList, 0, i + 1);
                    peptide.CopyTo(0, newList, i + 1, n - i - 1);
                    result.Add(newList.ToList());
                }
            }
            return result;
        }

        public static Dictionary<char, int> MassTable = new Dictionary<char, int>
                       {
                           {'A', 71},
                           {'C', 103},
                           {'D', 115},
                           {'E', 129},
                           {'F', 147},
                           {'G', 57},
                           {'H', 137},
                           {'I', 113},
                           {'K', 128},
                           {'L', 113},
                           {'M', 131},
                           {'N', 114},
                           {'P', 97},
                           {'Q', 128},
                           {'R', 156},
                           {'S', 87},
                           {'T', 101},
                           {'V', 99},
                           {'W', 186},
                           {'Y', 163} 
                       };

    }
}
