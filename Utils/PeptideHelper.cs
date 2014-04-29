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
