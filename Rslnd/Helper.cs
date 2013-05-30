using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Diagnostics;
using System.Net;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Rslnd
{
    public static class Helper
    {
        //public const string INPUT_FILE = "C:\\Users\\exr\\Documents\\GitHub\\Rosalind\\input.txt";
        //public const string OUTPUT_FILE = "C:\\Users\\exr\\Documents\\GitHub\\Rosalind\\output.txt";

        public const string INPUT_FILE = "C:\\Users\\Administrator\\Documents\\GitHub\\Rosalind\\input.txt";
        public const string OUTPUT_FILE = "C:\\Users\\Administrator\\Documents\\GitHub\\Rosalind\\output.txt";

        public static decimal TransitionTransversionRation(string s1, string s2)
        {
            int transition = 0;
            int transversion = 0;

            for (int i = 0; i < s1.Length; i++)
            {
                char ch1 = s1[i];
                char ch2 = s2[i];

                if ((ch1 == 'A' && ch2 == 'G') ||
                    (ch1 == 'G' && ch2 == 'A') ||
                    (ch1 == 'C' && ch2 == 'T') ||
                    (ch1 == 'T' && ch2 == 'C'))
                    transition++;
                if ((ch1 == 'A' && (ch2 == 'C' || ch2 == 'T')) ||
                    (ch1 == 'C' && (ch2 == 'A' || ch2 == 'G')) ||
                    (ch1 == 'G' && (ch2 == 'C' || ch2 == 'T')) ||
                    (ch1 == 'T' && (ch2 == 'A' || ch2 == 'G')))
                    transversion++;
            }

            return (decimal)transition / (decimal)transversion;
        }

        public static List<int> SplicedMotif(string seq, string subseq)
        {
            List<int> result = new List<int>();
            int cut = 0;
            for (int i = 0; i < subseq.Length; i++)
            { 
                char test = subseq[i];
                int val = seq.IndexOf(test);
                result.Add(val + cut + 1);

                cut = cut + val + 1;
                seq = seq.Substring(val + 1, seq.Length - val - 1);
            }
            return result;
        }

        public static string ShortestSuperstring(List<string> input)
        {
            input = input.OrderByDescending(x => x.Length).ToList();

            string superstring = input[0];

            for (int i = 1; i < input.Count; i++)
            {
                if (!superstring.Contains(input[i]))
                {
                    superstring = CombineIntoSuper(superstring, input[i]);
                }
            }

            return superstring;
        }

        private static string CombineIntoSuper(string superstring, string candidate)
        {
            int i = 1;
            while (candidate.Length > i)
            {
                int testlen = candidate.Length - i;
                string leftcan = candidate.Substring(0, testlen);
                string rightcan = candidate.Substring(i, testlen);

                string leftsuper = superstring.Substring(0, testlen);
                string rightsuper = superstring.Substring(superstring.Length - testlen, testlen);

                if (leftcan == rightsuper)
                {
                    string toappend = candidate.Substring(leftcan.Length, candidate.Length - leftcan.Length);
                    return superstring + toappend;
                }

                if (rightcan == leftsuper)
                {
                    string toappend = candidate.Substring(0, candidate.Length - rightcan.Length);
                    return toappend + superstring;
                }

                i++;
            }

            return superstring + candidate;
        }

        public static List<int> LongesIncreasingSubsequence(int[] ints)
        {
            int n = ints.Length;

            int maxi = 0;

            int j = 0;
            int maxj = 1;
            int end = 1;

            int[] L = new int[n];
            int[] b = new int[n];

            L[0] = 1;

            for (j = 1; j < n; j++)
            {
                b[j] = j;
                for (int i = 0; i < j; i++)
                {
                    if (ints[i] < ints[j] && L[i] > maxi)
                    {
                        maxi = L[i];
                        b[j] = i;
                    }
                }
                L[j] = 1 + maxi;
                maxi = 0;

                if (L[j] >= maxj)
                {
                    maxj = L[j];
                    end = j;
                }
            }

            List<int> results = new List<int>();
            int next = end;
            results.Add(ints[next]);
            while (next > 0 && b[next] != next)
            {
                next = b[next];
                results.Add(ints[next]);
            }
            return results;
        }

        public static BigInteger BinomialCoeff(int x, int y)
        {
            BigInteger xfact = Fact(x);
            BigInteger yfact = Fact(y);
            BigInteger xminusyfact = Fact(x - y);
            return xfact/(yfact*xminusyfact);
        }

        public static List<string> FastaStrings()
        {
            List<string> values = new List<string>();
            string line = string.Empty;
            string s = string.Empty;
            using (StreamReader reader = new StreamReader(INPUT_FILE))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith(">"))
                    {
                        if (!String.IsNullOrEmpty(s))
                        {
                            values.Add(s);
                        }
                        s = string.Empty;
                    }
                    else
                    {
                        s = s + line;
                    }
                }

                if (!String.IsNullOrEmpty(s))
                {
                    values.Add(s);
                }
            }
            return values;
        }

        public static string ReverseComplement(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            string rev = new string(arr);
            string revcomp = string.Empty;
            for(int i=0;i<rev.Length;i++)
            {
                switch (rev[i])
                {
                    case 'A':
                        revcomp += "T";
                        break;
                    case 'C':
                        revcomp += "G";
                        break;
                    case 'G':
                        revcomp += "C";
                        break;
                    case 'T':
                        revcomp += "A";
                        break;
                }
            }
            return revcomp;
        }

        public static string DNAtoRNA(string s)
        {
            return s.Replace('T', 'U');
        }

        public static void OpenReadingFrames()
        {
            string s = "CGCAGTGGGAGGCAATGACGCTCAAATGCTCAGTTCTCGGCAACCAGCGCCCTGAAGACATAATAGCGATTCACTATAACTGTCTAACTCCCATAGGCCAGAATACTGTACGCTTAGACCCCTTAAGCATAATGTATTTGCCATGCCATGCGCTGATTATTTATTACCGGGACCATTCTATGAAGTCGAAGTCACCCGAATTTGTCCTCGCGCAATGGACACACTCAAGAGAATAGGGGTAGACGGTTGTGAGACGCTTGGACGATCGATCTAAACCGGGGCAAACATTGCTTCCCTCCCAGTATCAAGGCACTTCCTTATACGTGTAAGTACCAGAATTACGTATTCTTCTGCGTTCGGAGTAAGGGTGCCGTCCCAGAGTGCCGACATACTAAAGCGTGGGCTAAAATTGTCACGTCTAATGATAGACATTTCGTATACCCCTGGAGACAAGGAAAAAACATAACTAGTATGCAAGCGAACCGTGGGTAGCTACCCACGGTTCGCTTGCATTCGTGCGAAGCCGGATACAAGCTTTATTGTGGACTACGCCTACACCTAGCTAACGCTACTTGATAATTAATCGACCTTACACAACTTAAGCCAGCCAGATTGTCTGAGAGGCGGGACCGTTCTATCTACCACGGCAGTGATTGCTGCTGTCCGTGAAGAGACTTCCAGCATAGATGTTACAGATGACTTGCGGTTAGTGTCTCGATTTTGTATTGTGCAACATATTATGTACAGTTGATTTCTGCGGCGAGCTTCATTATCCACCATCAGCATCCTGAGAGTTACATACTAGTGTACTAGTCTTGCTGGTAACGGCGGCGTGGAGCTGAACCTCGGCAAACGCAAAGGCGTTTGTCGTGGTTTCGCCGAAGGGCGATCGTACATAAAAACAGATTGACTTATATATGAGTCTAATATCCTACATGACTCCCATCCTCCTTCCTTTCGACGCTATCAAATAAGTGTATCCAA";

            string sc = Helper.ReverseComplement(s);

            List<String> source = new List<string>();
            List<String> orfs = new List<string>();

            source.Add(s);
            source.Add(s.Substring(1, s.Length - 1));
            source.Add(s.Substring(2, s.Length - 2));
            source.Add(sc);
            source.Add(sc.Substring(1, sc.Length - 1));
            source.Add(sc.Substring(2, sc.Length - 2));

            foreach (var str in source)
            {
                List<string> orffen = Helper.ORF(str);

                foreach (string orf1 in orffen)
                {
                    string orf = orf1;
                    if (orf != string.Empty && !orfs.Contains(orf))
                    {
                        orfs.Add(orf);

                        while (true)
                        {
                            if (orf.StartsWith("M"))
                            {
                                orf = orf.Substring(1, orf.Length - 1);
                                int indexofm = orf.IndexOf("M");
                                if (indexofm > 0)
                                {
                                    string subs = orf.Substring(indexofm, orf.Length - indexofm);
                                    orfs.Add(subs);
                                    orf = subs;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                }
            }

            using (StreamWriter writer = new StreamWriter(OUTPUT_FILE))
            {
                foreach (var orf in orfs)
                {
                    writer.WriteLine(orf);
                }
            }
        }

        public static List<string> ORF(string s)
        {
            List<string> results = new List<string>();

            s = DNAtoRNA(s);
            string result = string.Empty;
            int l = s.Length;
            int cur = 0;
            bool startfound = false;
            int index = 0;
            while (cur + 3 <= l)
            {
                string acid = s.Substring(cur, 3);

                if (startfound)
                {
                    switch (acid)
                    {
                        case "UUC":
                        case "UUU":
                            result = result + "F";
                            break;
                        case "CUU":
                        case "CUC":
                        case "UUA":
                        case "UUG":
                        case "CUA":
                        case "CUG":
                            result = result + "L";
                            break;
                        case "AUU":
                        case "AUC":
                        case "AUA":
                            result = result + "I";
                            break;
                        case "GUU":
                        case "GUC":
                        case "GUA":
                        case "GUG":
                            result = result + "V";
                            break;
                        case "AUG":
                            result = result + "M";
                            break;
                        case "UCU":
                        case "UCC":
                        case "UCA":
                        case "UCG":
                        case "AGU":
                        case "AGC":
                            result = result + "S";
                            break;
                        case "CCU":
                        case "CCC":
                        case "CCA":
                        case "CCG":
                            result = result + "P";
                            break;
                        case "ACU":
                        case "ACC":
                        case "ACA":
                        case "ACG":
                            result = result + "T";
                            break;
                        case "GCU":
                        case "GCC":
                        case "GCA":
                        case "GCG":
                            result = result + "A";
                            break;
                        case "UAU":
                        case "UAC":
                            result = result + "Y";
                            break;
                        case "CAU":
                        case "CAC":
                            result = result + "H";
                            break;
                        case "AAU":
                        case "AAC":
                            result = result + "N";
                            break;
                        case "GAU":
                        case "GAC":
                            result = result + "D";
                            break;
                        case "GGA":
                        case "GGG":
                        case "GGU":
                        case "GGC":
                            result = result + "G";
                            break;
                        case "CAA":
                        case "CAG":
                            result = result + "Q";
                            break;
                        case "AAA":
                        case "AAG":
                            result = result + "K";
                            break;
                        case "GAA":
                        case "GAG":
                            result = result + "E";
                            break;
                        case "UGG":
                            result = result + "W";
                            break;
                        case "UGU":
                        case "UGC":
                            result = result + "C";
                            break;
                        case "CGU":
                        case "CGC":
                        case "CGA":
                        case "AGA":
                        case "CGG":
                        case "AGG":
                            result = result + "R";
                            break;
                        case "UAA":
                        case "UAG":
                        case "UGA":
                            results.Add(result);
                            result = string.Empty;
                            startfound = false;
                            break;
                            //return result;
                        default:
                            break;
                    }
                }
                else
                {
                    if (acid == "AUG")
                    {
                        startfound = true;
                        result += "M";
                    }
                }

                cur += 3;
                index++;
            }
            return results;
        }

        public static BigInteger Fact(BigInteger n)
        {
            if (n == 0) return 1;
            else return n*Fact(n - 1);
        }

        public static string DNAtoAA(string dna)
        {
            string result = string.Empty;
            int l = dna.Length;
            int cur = 0;
            while (cur < l)
            {
                string acid = dna.Substring(cur, 3);

                char a = RNAtoProtein[acid];
                if(a == 'Z')
                {
                    return result;
                }
                else
                {
                    result = result + a;    
                }
                
                cur = cur + 3;
            }
            return result;
        }

        public static IEnumerable<string> getAllSubstrings(this string word)
        {
            return from charIndex1 in Enumerable.Range(0, word.Length)
                   from charIndex2 in Enumerable.Range(0, word.Length - charIndex1 + 1)
                   where charIndex2 > 0
                   select word.Substring(charIndex1, charIndex2);
        }

        static IEnumerable<string> SortByLength(IEnumerable<string> e)
        {
            // Use LINQ to sort the array received and return a copy.
            var sorted = from s in e
                         orderby s.Length ascending
                         select s;
            return sorted;
        }

        public static string PrintLongestCommonSubstring(string str1, string str2)
        {
            int[,] l = new int[str1.Length, str2.Length];
            int lcs = -1;
            string substr = string.Empty;
            int end = -1;

            for (int i = 0; i < str1.Length; i++)
            {
                for (int j = 0; j < str2.Length; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        if (i == 0 || j == 0)
                        {
                            l[i, j] = 1;
                        }
                        else
                            l[i, j] = l[i - 1, j - 1] + 1;
                        if (l[i, j] > lcs)
                        {
                            lcs = l[i, j];
                            end = i;
                        }

                    }
                    else
                        l[i, j] = 0;
                }
            }

            for (int i = end - lcs + 1; i <= end; i++)
            {
                substr += str1[i];
            }

            return substr;
        } 

        private static void swap (ref char a, ref char b)
                 {
                        if(a==b)return;
                        a^=b;
                        b^=a;
                        a^=b;
                  }

        public static List<string> StringPermutations(char[] list)
        {
            List<string> result = new List<string>();
            int x=list.Length-1;
            go(list,0,x, result);
            return result;
        }

        private static void go (char[] list, int k, int m, List<string> result)
        {
            int i;
            if (k == m)
                {
                    Debug.Print(new string(list));
                    Debug.Print(" ");
                    result.Add(new string(list));
                }
            else
                for (i = k; i <= m; i++)
                {
                    swap (ref list[k],ref list[i]);
                    go (list, k+1, m, result);
                    swap (ref list[k],ref list[i]);
                }
        }

        /// <summary>
        /// Gets all permutations (of a given size) of a given list, either with or without reptitions.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the list.</typeparam>
        /// <param name="list">The list of which to get permutations.</param>
        /// <param name="action">The action to perform on each permutation of the list.</param>
        /// <param name="resultSize">The number of elements in each resulting permutation; or <see langword="null"/> to get
        /// premutations of the same size as <paramref name="list"/>.</param>
        /// <param name="withRepetition"><see langword="true"/> to get permutations with reptition of elements;
        /// <see langword="false"/> to get permutations without reptition of elements.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is <see langword="null"/>. -or-
        /// <paramref name="action"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="resultSize"/> is less than zero.</exception>
        /// <remarks>
        /// The algorithm performs permutations in-place. <paramref name="list"/> is however not changed.
        /// </remarks>
        public static List<string> GetPermutations<T>(this IList<T> list, Action<IList<T>> action, int? resultSize = null,
            bool withRepetition = false)
        {
            List<string> toreturn = new List<string>();

            var result = new T[resultSize.HasValue ? resultSize.Value : list.Count];
            var indices = new int[result.Length];
            for (int i = 0; i < indices.Length; i++)
                indices[i] = withRepetition ? -1 : i - 1;

            int curIndex = 0;
            while (curIndex != -1)
            {
                indices[curIndex]++;
                if (indices[curIndex] == list.Count)
                {
                    indices[curIndex] = withRepetition ? -1 : curIndex - 1;
                    curIndex--;
                }
                else
                {
                    result[curIndex] = list[indices[curIndex]];
                    if (curIndex < indices.Length - 1)
                        curIndex++;
                    else
                    {
                        action(result);
                        toreturn.Add(new string(result as char[]));
                    }
                        
                }
            }
            return toreturn;
        }

        public static double ProteinMass(string s)
        {
            double result = 0;
            
            foreach (var ch in s)
            {
                result += MassTable[ch];
            }
            return result;
            //return result + 18.01056;
        }

        public static Dictionary<char, double> MassTable = new Dictionary<char, double>
                       {
                           {'A', 71.03711},
                           {'C', 103.00919},
                           {'D', 115.02694},
                           {'E', 129.04259},
                           {'F', 147.06841},
                           {'G', 57.02146},
                           {'H', 137.05891},
                           {'I', 113.08406},
                           {'K', 128.09496},
                           {'L', 113.08406},
                           {'M', 131.04049},
                           {'N', 114.04293},
                           {'P', 97.05276},
                           {'Q', 128.05858},
                           {'R', 156.10111},
                           {'S', 87.03203},
                           {'T', 101.04768},
                           {'V', 99.06841},
                           {'W', 186.07931},
                           {'Y', 163.06333} 
                       };

        public static Dictionary<string, char> RNAtoProtein = new Dictionary<string, char>
        {
            {"UUC", 'F'},   {"UUU", 'F'},   
            {"CUU", 'L'},   {"CUC", 'L'},   {"UUA", 'L'},   {"UUG", 'L'},   {"CUA", 'L'},   {"CUG", 'L'},
            {"AUU", 'I'},   {"AUC", 'I'},   {"AUA", 'I'},
            {"GUU", 'V'},   {"GUC", 'V'},   {"GUA", 'V'},   {"GUG", 'V'},
            {"AUG", 'M'},
            {"UCU", 'S'},   {"UCC", 'S'},   {"UCA", 'S'},   {"UCG", 'S'},   {"AGU", 'S'},   {"AGC", 'S'},
            {"CCU", 'P'},   {"CCC", 'P'},   {"CCA", 'P'},   {"CCG", 'P'},   {"ACU", 'T'},   
            {"ACC", 'T'},   {"ACA", 'T'},   {"ACG", 'T'},
            {"GCU", 'A'},   {"GCC", 'A'},   {"GCA", 'A'},   {"GCG", 'A'},
            {"UAU", 'Y'},   {"UAC", 'Y'},
            {"CAU", 'H'},   {"CAC", 'H'},
            {"AAU", 'N'},   {"AAC", 'N'},
            {"GAU", 'D'},   {"GAC", 'D'},
            {"GGA", 'G'},   {"GGG", 'G'},   {"GGU", 'G'},   {"GGC", 'G'},
            {"CAA", 'Q'},   {"CAG", 'Q'},
            {"AAA", 'K'},   {"AAG", 'K'},
            {"GAA", 'E'},   {"GAG", 'E'},
            {"UGG", 'W'},
            {"UGU", 'C'},   {"UGC", 'C'},
            {"CGU", 'R'},   {"CGC", 'R'},   {"CGA", 'R'},   {"AGA", 'R'},   {"CGG", 'R'},   {"AGG", 'R'},
            {"UAA", 'Z'},   {"UAG", 'Z'},   {"UGA", 'Z'}
        };

        public static List<SubString> AllSubstrings(string s, int l1, int l2)
        {
            List<SubString> result = new List<SubString>();
            for (int i = 0; i < s.Length; i++) //i is starting position
            {
                for (int j = l1; j <= l2; j++) //j is number of characters to get
                {
                    if((i + j) <= s.Length)
                        result.Add(new SubString(s.Substring(i, j), i+1, j));
                }
            }
            return result;
        }

        public static IEnumerable<String> GetWords(Int32 length, List<string> dictionary)
        {
            if (length <= 0)
                yield break;

            foreach (string s in dictionary)
            {
                if (length > 1)
                {
                    foreach (String restWord in GetWords(length - 1, dictionary))
                        yield return s + restWord;
                }
                else
                    yield return "" + s;
            }
        }

        public static void FindProteinMotif()
        {
            List<string> proteins = new List<string>();

            string line;
            using (StreamReader reader = new StreamReader(INPUT_FILE))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    proteins.Add(line);
                }
            }

            WebClient client = new WebClient();
            Dictionary<string, string> proteinsDict = new Dictionary<string, string>();
            foreach (string id in proteins)
            {
                Stream stream = client.OpenRead("http://www.uniprot.org/uniprot/" + id + ".fasta");

                if (stream != null)
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string protein = string.Empty;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (!line.StartsWith(">"))
                            {
                                protein += line;
                            }
                        }

                        proteinsDict.Add(id, protein);
                    }
            }

            const string pattern = @"N[^P][ST][^P]";

            using (StreamWriter writer = new StreamWriter(OUTPUT_FILE))
            {
                foreach (KeyValuePair<string, string> kvp in proteinsDict)
                {
                    string val = kvp.Value;
                    List<int> matches = new List<int>();
                    int removed = 0;
                    bool done = false;
                    while (done == false)
                    {
                        Match match = Regex.Match(val, pattern);
                        if (match.Success)
                        {
                            int index = val.IndexOf(match.Value);
                            matches.Add(index + removed + 1);
                            removed += index + 1;
                            val = val.Substring(index + 1, val.Length - (index + 1));
                        }
                        else
                        {
                            done = true;
                        }
                    }

                    if (matches.Count > 0)
                    {
                        string indices = string.Empty;
                        writer.WriteLine(kvp.Key);
                        indices = matches.Aggregate(indices, (current, index) => current + index + " ");
                        writer.WriteLine(indices);
                    }
                }
            }
        }

        internal static List<int[]> SignedPermutations(int[] s)
        {
            List<int[]> result = new List<int[]>();
            foreach (int i in s)
            {
                result = AddOneSignedPermutation(result, i);
            }
            return result;
        }

        internal static List<int[]> AddOneSignedPermutation(List<int[]> input, int intToAdd)
        {
            List<int[]> result = new List<int[]>();

            if (input.Count == 0)
            {
                result.Add(new int[] { intToAdd });
                result.Add(new int[] { -intToAdd });
                return result;
            }

            foreach (int[] i in input)
            { 
                int[] newi = new int[i.Length + 1];
                int[] newineg = new int[i.Length + 1];
                Array.Copy(i, newi, i.Length);
                Array.Copy(i, newineg, i.Length);
                newi[i.Length] = intToAdd;
                newineg[i.Length] = -intToAdd;
                result.Add(newi);
                result.Add(newineg);
            }
            return result;
        }

        internal static int[] StringToIntArray(string s)
        {
            int[] result = new int[s.Length];
            for(int i = 0; i < s.Length; i++)
            {
                result[i] = int.Parse(s[i].ToString());
            }
            return result;
        }
    }

    public struct SubString
    {
        public string substring;
        public int index;
        public int lenght;

        public SubString(string s, int i, int l)
        {
            substring = s;
            index = i;
            lenght = l;
        }
    }

}
