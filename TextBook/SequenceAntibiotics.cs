using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace TextBook
{
    //Problems from Week 2: How Do We Sequence Antibiotics?
    public static class SequenceAntibiotics
    {
        //1. Protein Translation problem
        public static string ProteinTranslation(string dna)
        {
            return Helper.DNAtoAA(dna);
        }

        //2. Peptide encoding problem
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

        //3. Generating theoretical spectrum problem
        public static void PeptideSpectrum(string peptide)
        {
            string rslt = string.Empty;
            List<string> result = new List<string>();
            for (int i = 1; i < peptide.Length; i++)
            {
                result.AddRange(PeptideHelper.SubPeptides(peptide, i));
            }
            result.Add(peptide);

            List<KeyValuePair<string, int>> masses = new List<KeyValuePair<string, int>>();

            foreach (string ppt in result)
            {
                int mass = PeptideHelper.IntProteinMass(ppt);
                masses.Add(new KeyValuePair<string, int>(ppt, mass));
            }
            masses.Add(new KeyValuePair<string, int>("", 0));

            var sortedDict = from entry in masses orderby entry.Value ascending select entry;

            foreach (KeyValuePair<string, int> kvp in sortedDict)
            {
                rslt = rslt + kvp.Value + " ";
            }
        }

        //Spectrum convolution problem

        // ### Solve spectrum convolution start
        //List<int> spectrum = Helper.ParseIntString("1092 1515 524 71 210 1140 1375 1090 544 982 709 1583 1997 2052 711 632 71 645 1885 1698 1084 2056 1329 740 743 525 1042 1785 1585 675 2040 2016 1313 450 1722 726 816 1385 1069 831 1830 1541 1221 1197 1515 1943 1990 1882 840 1386 1442 612 1613 882 358 932 544 562 268 97 1084 388 1680 131 1859 1512 294 1631 431 1700 482 2016 131 681 596 1478 268 1953 1997 202 641 811 1242 1939 1591 1352 610 1219 1061 1997 909 874 699 568 1866 769 1521 1342 1866 1435 1384 2022 131 101 257 271 1542 1896 1473 911 0 163 244 1069 156 113 1410 1508 1255 409 1557 541 1221 1171 1413 1765 366 287 2066 1444 570 1244 1885 1500 1699 1772 1543 1995 473 1808 1065 1384 934 1377 1356 424 1313 953 1472 977 824 1672 300 1013 287 1880 869 2040 680 769 855 115 1722 1454 587 1908 1069 2066 158 1250 1547 1040 767 156 1200 932 801 1628 345 297 2082 339 1629 200 1284 1856 1341 273 932 253 1909 1809 495 903 1337 1787 370 1814 1945 906 1179 1793 1652 1671 1744 1743 1113 898 522 1322 137 368 1880 1609 2153 1198 137 1612 653 2038 1182 214 1063 974 1544 1247 501 1221 638 956 968 1658 2022 697 1703 1995 245 431 638 1951 2022 1088 778 2082 87 797 703 1355 381 453 360 1841 1456 812 323 609 1065 455 1900 1111 1279 1566 186 1176 344 87 113 273 1795 611 606 1298 1200 312 955 1084 540 1722 431 798 1166 1967 768 1271 1710 1185 840 454 1609 410 1652 971 718 776 481 208 1729 501 443 1427 156 158 953 1088 1450 1783 1853 987");

        //List<int> result = SequenceAntibiotics.SpectrumConvolution(spectrum);
        //result = SequencingHelper.SortByFrequency(result);
        //string res = string.Empty;

        //for (int i = 0; i < result.Count(); i++)
        //{
        //    res = res + result[i] + " ";
        //}
        // ### Solve spectrum convolution end

        public static List<int> SpectrumConvolution(List<int> spectrum)
        {
            List<int> result = new List<int>();

            //spectrum.Sort();

            int len = spectrum.Count();
            int iStart = len - 1;

            for (int i = iStart; i > 0; i--)
            {
                int jStart = i - 1;
                for (int j = jStart; j >= 0; j--)
                {
                    int val = Math.Abs(spectrum[i] - spectrum[j]);
                    if (val > 0) result.Add(val);
                }
            }

            return result;
        }
    }
}
