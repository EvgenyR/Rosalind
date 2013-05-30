using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Numerics;

namespace Rslnd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void makeperm(int i)
        {

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> fasta = Helper.FastaStrings();
            string input = fasta[0];
            //input = @"CTTCGAAAGTTTGGGCCGAGTCTTACAGTCGGTCTTGAAGCAAAGTAACGAACTCCACGGCCCTGACTACCGAACCAGTTGTGAGTACTCAACTGGGTGAGAGTGCAGTCCCTATTGAGTTTCCGAGACTCACCGGGATTTTCGATCCAGCCTCAGTCCAGTCTTGTGGCCAACTCACCAAATGACGTTGGAATATCCCTGTCTAGCTCACGCAGTACTTAGTAAGAGGTCGCTGCAGCGGGGCAAGGAGATCGGAAAATGTGCTCTATATGCGACTAAAGCTCCTAACTTACACGTAGACTTGCCCGTGTTAAAAACTCGGCTCACATGCTGTCTGCGGCTGGCTGTATACAGTATCTACCTAATACCCTTCAGTTCGCCGCACAAAAGCTGGGAGTTACCGCGGAAATCACAG";
            string final = string.Empty;
            List<string> alphabet = Helper.GetPermutations(new char[] { 'A', 'C', 'G', 'T' }, a => { Console.WriteLine(a.ToArray()); }, 4, true);
            int[] counts = Enumerable.Repeat(0, alphabet.Count).ToArray();

            for (int i = 0; i <= input.Length - 4; i++)
            {
                string word = input.Substring(i, 4);
                counts[alphabet.IndexOf(word)]++;
            }

            for (int i=0; i<counts.Length; i++)
                final = final + counts[i].ToString() + " ";

            //List<string> alphabet = Helper.StringPermutations(new char[] { 'A', 'B', 'C', 'D' });

            int z = 0;

            //IOrderedEnumerable<string> input = Enumerable.Empty<string>().OrderBy(x => 1);

            //List<string> input = new List<string> 
            //{ 
            //    "CACGTCATTTATTATCCAACTTGCTGGGAGTATTCAACTATAGAAAAAACTATTATTTAGATGTGACCAGCCCACTAACTTGGTCTCTACAGCAAGGTCCGCCTTATTGAACGTTTTATTGAGGTTTACGCATGCGGCACGGTTGTCACTCGCCTTTCCTAAACGTCCAGCTGAGGGCTCTGGAACACTGCGTCGTAGTCGTATCGATATCCGTCGCCAAACCCCCCGGTAGAGCTTGCCCCTCGACCACAGGCTAGACCGGGAGCCCTGGTGAAGAGGGTCGAGCTAGTACATTATTCTCACTAACGCCACCTCGCACATGCATGTATCTGTGTAAAGGTTCCGAATGAACACAGCCTATATAATAGTCGACGTGTGTTTGGACGGATCCGAGAGTAAAGTAGGTACTATGTAAACGATTTGCACCCGTTATGGATAATCAGGATTATGAATCCTAGCAGTGGCCTGACCAAGTAAAATAGAGATCATCAAAACAAGGCTATATCGACGGGAATCGAGAGGGGAAGCTCGGAGCTCAGGGAAGATCCACACTCGTGCTACAGGCCTCTCTTAGTGGAGCGTGTACTGATTCCAGACAAATCAACTAGTTGCGGGAAAGCGCTGAGCACTAATCGTGCGCCGAATCGAATAACTCTATCGAACACGATACAGGAGGCGTAGGCTTTGAACCCATTTATCATGCGGGCGGACCGGCAATCATGCTATGTTAGAGAAATTTTAAGCGAACAGCGCAAAATAGGAGATTACTTAAAATGGTAGTGCCAGAAACTGACTGAAGTGGTATTGAGGGCCCGCGCCAAGACAACAGGGTTCATCCAATCGCCGATAGATCAACGTTAGCCGGGTCTATGTAGCATAGACTGTCAATCATGTCCAGGAAGGGACGATCAGTGTGCACTGCAGGTGCCGGACCGAAGAAGTCTGTGCCTCCTCCATACTATCTTAGGCTCATGGTTGCGAATCCCGTAGTTACCGCTTC",
            //    "GATGATCGTCTAACCCCCGAGCAAGAAACCGCAGTAGGTTCTTTTACCGTGACAGCGCGCCCACCGTTCCCTCCCCCAGGCTCAGGGCTTGGAGCACTTTAGCGAGTTGTTCAGCTATTCCCGGATTCAGCTAACTTTATTTCTCCTGTCAGGAGCCACAGCAGCTACTGCAGTTGGTCATTGGTGTGGCCTGTCGCACAAAAGAATGGAGGGCTAACTCGTGATCCATGTTAGTTTGGCCTCGTGTAAGGCACTGCAGTCATCCACCTAGGGTCTGCGGATGATCATTCGATTTATACCGCTGAGGCGGGGTAAAAACGCGCTGTCTTCACTAGGATAGGCCTTACACGACGCTTTAGAACCGTAAATCGGTTGAGTTCGCCCGAACTTGCGACTACGTCAGTACGAGGCCATCCGTTAAGGTCGACGCGGCGGAACATCTAAATAGTGCAGCGATCAATCCGCCTTAAAGCTATGGCGAGGTGGGGCAGTTTGCAAAAAATAAAACTTCACTATCGGCTCTCTTCGGCTCTCTGTTGAGCTGAGGGAACGTTTTCGTTGATAGCAAATCGCAAAAACGGAGGGTTCGGAGCTTGCGAACGCCAGACTCGTATGTCCGGGACTTCGGGTTTTATTGCCCATTCACGCAGTAGTGTCTGTACGTTGACTTATTATGGCGCCGGGGTGGAGAGGCCGTTAGCCATAGTGGAGCTATTTACCTTGGTGAGTACTAATAACAGCGAACTTAACCGTGCTCCGTTGCCGTCGATGTCAGTGATACTACACGTCATTTATTATCCAACTTGCTGGGAGTATTCAACTATAGAAAAAACTATTATTTAGATGTGACCAGCCCACTAACTTGGTCTCTACAGCAAGGTCCGCCTTATTGAACGTTTTATTGAGGTTTACGCATGCGGCACGGTTGTCACTCGCCTTTCCTAAACGTCCAGCTGAGGGCTCTGGAACACTGCGTCGTAGTCGTATCGATATCCGTCGC",
            //    "GTCGACGCGGCGGAACATCTAAATAGTGCAGCGATCAATCCGCCTTAAAGCTATGGCGAGGTGGGGCAGTTTGCAAAAAATAAAACTTCACTATCGGCTCTCTTCGGCTCTCTGTTGAGCTGAGGGAACGTTTTCGTTGATAGCAAATCGCAAAAACGGAGGGTTCGGAGCTTGCGAACGCCAGACTCGTATGTCCGGGACTTCGGGTTTTATTGCCCATTCACGCAGTAGTGTCTGTACGTTGACTTATTATGGCGCCGGGGTGGAGAGGCCGTTAGCCATAGTGGAGCTATTTACCTTGGTGAGTACTAATAACAGCGAACTTAACCGTGCTCCGTTGCCGTCGATGTCAGTGATACTACACGTCATTTATTATCCAACTTGCTGGGAGTATTCAACTATAGAAAAAACTATTATTTAGATGTGACCAGCCCACTAACTTGGTCTCTACAGCAAGGTCCGCCTTATTGAACGTTTTATTGAGGTTTACGCATGCGGCACGGTTGTCACTCGCCTTTCCTAAACGTCCAGCTGAGGGCTCTGGAACACTGCGTCGTAGTCGTATCGATATCCGTCGCCAAACCCCCCGGTAGAGCTTGCCCCTCGACCACAGGCTAGACCGGGAGCCCTGGTGAAGAGGGTCGAGCTAGTACATTATTCTCACTAACGCCACCTCGCACATGCATGTATCTGTGTAAAGGTTCCGAATGAACACAGCCTATATAATAGTCGACGTGTGTTTGGACGGATCCGAGAGTAAAGTAGGTACTATGTAAACGATTTGCACCCGTTATGGATAATCAGGATTATGAATCCTAGCAGTGGCCTGACCAAGTAAAATAGAGATCATCAAAACAAGGCTATATCGACGGGAATCGAGAGGGGAAGCTCGGAGCTCAGGGAAGATCCACACTCGTGCTACAGGCCTCTCTTAGTGGAGCGTGTACTGATTCCAGACAAATCAACTAGTTGCGGGAAAGCGCTGAGCACTAATCGTGCG"

            //};

            //List<string> input = new List<string> 
            //{ 
            //    "ATTAGACCTG",
            //    "CCTGCCGGAA",
            //    "AGACCTGCCG",
            //    "GCCGGAATAC",
            //    "GCATTAGACC"
            //};

            //List<string> input = Helper.FastaStrings();

            //string result = Helper.ShortestSuperstring(input);

            /*
            string one = "CAGGACGCTGAACTTCATAGCTGTTTTGCTATTGTATTTGAGATACACGGTGCTCGTTGAGGTCGACAACCTTTGCCTCGAGCTTGATGGCAATAAGCTTGGGTCTGAAGGTAGGAGTCACCCTGGACGATGGGGACTGCCAGGATCTTTGTCCACGGAAGCTGAGCCGGGGAGATCCTGAGCATCACCCCATTAAGTAACCGTTTACTCTCTCGCGTACGGTCGGCTAGGGCTGTAGAGGTGGGTATCGCATGCTGACTGGCGTACGGCCTCCAATGGACCACTGATAATCTCCGCAGTAAGTTGACCGATCGGCCAGTTACTGCAATGCATTTGCGACTGGGTGGCTGCGCGAACGGAAAAATAAGTGCTGAGCTGGCCTGGTCATACTTGGTAATCTTGTCGAATGATGGCGCCCTGCTAAAATGCGTCATACGAATACCAGGACTTCTCTGCTATATTATCATGAACAGACGCCCGTTACACATAGCTAGATACCTATAAGATCAGTTATAGTGTAGCTATACTGCCTGTCATCTGAAAAACACTACCTATAGGCCCCTCTAGCCATTGCCATGGGTGCGCTTTGTCAAGAGCATGATCATACCGCCTGTTGAGCGCGGCGGCAACATAGGCAGTCAATCGCCATCTTCGCTTATAGGGTGTGGTAGCGGTGTGTACATGTGAAGTCAAAAAAATACTAGTCGTTCCGCCCATGTCAAGGGCCATGTCACGTAGAAGTGAACGGCCATAGGCTCCTCACCTTTGTGATCGATAGGTATATATATGTATGTTTAGCCCTCGCGGGCAGACACTCGGTGCCTGACCATGCAGAAACCAGGGGACTAAGTGGGGATTTCTG";
            string two = "GACCGGTAGAGGGCTAACGATCACAATTGTTGAGGGGCTTATTTAGGTCACGTG";

            int index = 0;

            List<int> indices = new List<int>();
            foreach (char ch in two)
            {
                int value = 0;
                int current = 0;
                string temp = one;
                while(true)
                {
                    value = temp.IndexOf(ch);
                    if(value >= index)
                    {
                        indices.Add(value + current);
                        index = value;
                        break;
                    }
                    else
                    {
                        current = current + value + 1;
                        temp = one.Substring(value + 1, temp.Length - value - 1);
                    }
                }
            }

            string s = string.Empty;
            foreach(int i in indices)
            {
                s = s + (i + 1).ToString() + " ";
            }
            */

            //Helper.SignedPermutations(3);


            //longest increasing subsequence starts
            /*
            string input;

            using (StreamReader reader = new StreamReader(Helper.INPUT_FILE))
            {
                input = reader.ReadToEnd();
            }

            //input = "5 1 4 2 3";
            //input = "9 11 2 13 7 15";

            string[] inputs = input.Split(' ');
            //List<int> ints = new List<int>();
            int[] ints = new int[inputs.Length];
            
            //foreach (var s in inputs)
            //{
            //    ints.Add(int.Parse(s));
            //}

            for(int i = 0; i < inputs.Length; i++)
            {
                ints[i] = int.Parse(inputs[i]);
            }

            List<int> results = Helper.LongesIncreasingSubsequence(ints);
            Array.Reverse(ints);
            List<int> results2 = Helper.LongesIncreasingSubsequence(ints);

            results.Reverse();
            results2.Reverse();

            string one = string.Empty;
            string two = string.Empty;

            foreach (int value in results)
            {
                one = one + value + " ";
            }

            foreach (int value in results2)
            {
                two = two + value + " ";
            }
            */
            //longest increasing subsequence ends

            //List<string> s = Helper.GetWords(4, new List<string> { "L", "I", "W", "O" }).ToList();

            //using (StreamWriter writer = new StreamWriter("C:\\Evgeny\\Development\\Rslnd\\output.txt"))
            //{
            //    foreach (var orf in s)
            //    {
            //        writer.WriteLine(orf);
            //    }
            //}

            //string s = "ATGGTCTACATAGCTGACAAACAGCACGTAGCAATCGGTCGAATCTCGAGAGGCATATGGTCACATGATCGGTCGAGCGTGTTTCAAAGTTTGCGCCTAG";
            //string i1 = "ATCGGTCGAA";
            //string i2 = "ATCGGTCGAGCGTGT";

            //s = s.Replace(i1, "");
            //s = s.Replace(i2, "");

            //s = Helper.DNAtoRNA(s);

            //s = Helper.DNAtoAA(s);

            //string s = textBox1.Text.Trim();

            //List<SubString> result = Helper.AllSubstrings(s, 4, 12);

            //List<SubString> endresult = new List<SubString>();
            //foreach (var str in result)
            //{
            //    string strc = Helper.ReverseComplement(str.substring);
            //    if(str.substring == strc)
            //        endresult.Add(str);
            //}

            //using (StreamWriter writer = new StreamWriter("C:\\Evgeny\\Development\\Rslnd\\output.txt"))
            //{
            //    foreach (var orf in endresult)
            //    {
            //        writer.WriteLine(orf.index + " " + orf.lenght);
            //    }
            //}

        }
    }
}
