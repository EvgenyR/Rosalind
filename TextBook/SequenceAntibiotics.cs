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
    }
}
