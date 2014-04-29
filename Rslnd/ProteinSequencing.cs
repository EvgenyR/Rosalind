using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rslnd
{
    class ProteinSequencing
    {
        public static void CyclopeptideSequencing(List<int> spectrum)
        {
            List<int> acids = new List<int>();

            foreach (int value in spectrum)
            {
                if (value > 0 && value <= 186)
                {
                    if (!acids.Contains(value)) acids.Add(value);
                }
            }

            List<List<int>> originalList = new List<List<int>>();

            foreach (int value in acids)
            {
                List<int> newList = new List<int>();
                newList.Add(value);
                originalList.Add(new List<int>(newList));
            }

            string test = string.Empty;

            while (true)
            {
                int sum = originalList[0].Sum();
                if (sum == spectrum.Max()) break;

                List<List<int>> newList = new List<List<int>>();

                foreach (List<int> lst in originalList)
                {
                    foreach (int value in acids)
                    {
                        List<int> toAdd = new List<int>(lst);
                        toAdd.Add(value);
                        newList.Add(toAdd);
                    }
                }

                List<List<int>> trimmedList = ProteinSequencing.TrimList(newList, spectrum, false);

                test = ProteinSequencing.ListToString(trimmedList);

                originalList = new List<List<int>>(trimmedList);
            }
        }

        private static string ListToString(List<List<int>> trimmedList)
        {
            string result = string.Empty;
            foreach (List<int> lst in trimmedList)
            {
                int count = 0;
                foreach (int i in lst)
                {
                    result = result + i.ToString();
                    if (count < lst.Count() - 1) result = result + "-";
                    count++;
                }
                result = result + " ";
            }
            return result;
        }

        private static List<List<int>> TrimList(List<List<int>> originalList, List<int> spectrum, bool cyclic)
        {
            List<List<int>> trimmedList = new List<List<int>>();

            foreach (List<int> lst in originalList)
            {
                if (IsValidSpectrum(lst, spectrum)) trimmedList.Add(lst);
            }

            return trimmedList;
        }

        private static bool IsValidSpectrum(List<int> candidate, List<int> spectrum)
        {
            List<int> peptideSpectrum = PeptideSpectrum(candidate, false);

            foreach (int i in peptideSpectrum)
            {
                if (!spectrum.Contains(i)) return false;
            }

            foreach (int i in peptideSpectrum)
            {
                int inCand = peptideSpectrum.Where(s => s == i).Count();
                int inSpect = spectrum.Where(s => s == i).Count();

                if (inCand > inSpect) return false;
            }   

            //foreach (int i in candidate)
            //{
            //    if (!spectrum.Contains(i)) return false;

            //    if(!spectrum.Contains(candidate.Sum())) return false;

            //    int inCand = candidate.Where(s => s == i).Count();
            //    int inSpect = spectrum.Where(s => s == i).Count();

            //    if (inCand > inSpect) return false;

            //    //if (!peptideSpectrum.Contains(i)) return false;
            //}
            return true;
        }

        public static List<int> PeptideSpectrum(List<int> acids, bool cyclic)
        {
            List<List<int>> result = new List<List<int>>();

            for (int i = 1; i < acids.Count; i++)
            {
                List<List<int>> sp = SubPeptides(acids, i, cyclic);
                result.AddRange(sp);
            }
            result.Add(acids);

            List<int> spectrum = new List<int>();

            foreach (List<int> lst in result)
            {
                int val = lst.Sum();
                //if (!spectrum.Contains(val)) spectrum.Add(val);
                spectrum.Add(val);
            }

            spectrum.Sort();

            return spectrum;
        }

        public static List<List<int>> SubPeptides(List<int> peptide, int n, bool cyclic)
        {
            List<List<int>> result = new List<List<int>>();
            for (int i = 0; i <= peptide.Count - n; i++)
            {
                int[] newList = new int[n];
                peptide.CopyTo(i, newList, 0, n);
                result.Add(newList.ToList());
            }

            if (cyclic)
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

        public static List<int> ListOfUniques(List<int> input)
        {
            List<int> result = new List<int>();

            foreach (int val in input)
            {
                if (!result.Contains(val)) result.Add(val);
            }
            return result;
        }
    }
}
