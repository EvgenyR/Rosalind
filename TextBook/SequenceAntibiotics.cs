using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace TextBook
{
    public static class SequenceAntibiotics
    {
        public static string ProteinTranslation(string dna)
        {
            return Helper.DNAtoAA(dna);
        }

        public static List<string> PeptideEncoding(string dna, string peptide)
        {
            int peplen = peptide.Length;
            //dna = DNAtoRNA(dna);

            List<string> result = new List<string>();

            for (int i = 0; i <= dna.Length - peplen * 3; i++)
            {
                string test = dna.Substring(i, peplen * 3);
                string testRC = Helper.ReverseComplement(test);

                string pep1 = Helper.DNAtoAA(test.Replace("T", "U"));
                string pep2 = Helper.DNAtoAA(testRC.Replace("T", "U"));

                if ((pep1 == peptide) || (pep2 == peptide)) result.Add(test);
            }
            return result;
        }
    }
}
