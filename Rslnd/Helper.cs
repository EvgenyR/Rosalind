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
        public static BigInteger BinomialCoeff(int x, int y)
        {
            BigInteger xfact = Fact(x);
            BigInteger yfact = Fact(y);
            BigInteger xminusyfact = Fact(x - y);
            return xfact/(yfact*xminusyfact);
        }

        public static List<string> FastaStrings(string file)
        {
            file = "C:\\Evgeny\\Development\\Rslnd\\input.txt";
            List<string> values = new List<string>();
            string line = string.Empty;
            string s = string.Empty;
            using (StreamReader reader = new StreamReader(file))
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

            using (StreamWriter writer = new StreamWriter("C:\\Users\\exr\\Documents\\GitHub\\Rosalind\\output.txt"))
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

        public static List<string> setper(char[] list)
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
            using (StreamReader reader = new StreamReader("C:\\Evgeny\\Development\\Rslnd\\input.txt"))
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

            using (StreamWriter writer = new StreamWriter("C:\\Evgeny\\Development\\Rslnd\\output.txt"))
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
